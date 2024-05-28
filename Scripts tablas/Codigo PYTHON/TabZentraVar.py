import pyodbc

# Parámetros de conexión
server = '172.16.11.44\\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Cadena de conexión
conn_str = f'DRIVER={{SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

# Conexión a la base de datos
conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

# Consulta para leer datos de la tabla
cursor.execute('SELECT * FROM ZentraVar')

# Abrir un archivo SQL para escribir los comandos INSERT
with open('I_ZentraVar.sql', 'w') as file:
    for row in cursor:
        # Extraer todos los valores de la fila actual
        values = [f"'{str(item).replace('None', 'NULL')}'" if isinstance(item, str) else str(item) for item in row]
        # Formatear la fecha adecuadamente
        datetime_value = row.Datetime
        values[0] = f"'{datetime_value}'"
        # Crear la cadena de inserción
        insert_command = f"INSERT INTO ZentraVar VALUES ({', '.join(values)});\n"
        # Escribir el comando INSERT en el archivo
        file.write(insert_command)

# Cerrar conexión
cursor.close()
conn.close()

print("Archivo SQL generado exitosamente.")

