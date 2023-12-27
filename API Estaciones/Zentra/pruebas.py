import pymssql

# Configura la conexión a tu base de datos SQL Server
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Reemplaza 'TuTabla' con el nombre de la tabla que deseas respaldar
nombre_tabla = 'SITB_Estacion_1'

# Establece la conexión
conexion = pymssql.connect(server=server, user=username, password=password, database=database)

# Configura el tamaño máximo de inserciones por archivo
max_inserciones_por_archivo = 9500

try:
    with conexion.cursor() as cursor:
        # Consulta SQL para seleccionar todos los registros de la tabla excluyendo la primera columna
        consulta_sql = f"SELECT * FROM {nombre_tabla}"

        # Ejecuta la consulta
        cursor.execute(consulta_sql)

        # Recupera los nombres de las columnas de la tabla
        nombres_columnas = [column[0] for column in cursor.description]

        # Excluye el nombre de la primera columna (columna autoincremental)
        nombres_columnas_sin_primera = nombres_columnas[1:]

        # Inicializa contadores
        contador_inserciones = 0
        contador_archivos = 1

        # Genera el primer archivo .sql
        archivo_sql = f'{nombre_tabla}_{contador_archivos}.sql'
        file = open(archivo_sql, 'w', encoding='utf-8')
        
        for fila in cursor:
            valores = ", ".join([f"'{str(valor)}'" if valor is not None else "NULL" for valor in fila[1:]])
            insert_statement = f"INSERT INTO {nombre_tabla} ({', '.join(nombres_columnas_sin_primera)}) VALUES ({valores});\n"
            file.write(insert_statement)

            contador_inserciones += 1

            # Si se alcanza el límite de inserciones por archivo, cierra el archivo actual y abre uno nuevo
            if contador_inserciones >= max_inserciones_por_archivo:
                file.close()
                contador_inserciones = 0
                contador_archivos += 1
                archivo_sql = f'{nombre_tabla}_{contador_archivos}.sql'
                file = open(archivo_sql, 'w', encoding='utf-8')
                
    print(f'Se han creado los archivos .sql divididos.')

finally:
    conexion.close()
