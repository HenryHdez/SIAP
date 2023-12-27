import pymssql

# Configura la conexión a tu base de datos SQL Server
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Reemplaza 'TuTabla' con el nombre de la tabla que deseas respaldar
nombre_tabla = 'SITB_SenEst1'

# Establece la conexión
conexion = pymssql.connect(server=server, user=username, password=password, database=database)

try:
    with conexion.cursor() as cursor:
        # Consulta SQL para seleccionar todos los registros de la tabla
        consulta_sql = f"SELECT * FROM {nombre_tabla}"

        # Ejecuta la consulta
        cursor.execute(consulta_sql)

        # Recupera todos los resultados
        resultados = cursor.fetchall()

        # Genera un archivo .sql con comandos INSERT INTO
        archivo_sql = f'{nombre_tabla}.sql'
        with open(archivo_sql, 'w', encoding='utf-8') as file:
            for fila in resultados:
                valores = ", ".join([f"'{str(valor)}'" if valor is not None else "NULL" for valor in fila])
                insert_statement = f"INSERT INTO {nombre_tabla} VALUES ({valores});\n"
                file.write(insert_statement)

    print(f'Se ha creado el archivo {archivo_sql} con los comandos INSERT INTO.')

finally:
    conexion.close()
