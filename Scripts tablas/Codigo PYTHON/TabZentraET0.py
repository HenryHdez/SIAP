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
cursor.execute('SELECT * FROM ZentraET0')

# Abrir un archivo SQL para escribir los comandos INSERT
with open('I_ZentraET0.sql', 'w') as file:
    for row in cursor:
        Datetime, ETo = row  # Asegúrate de que estos sean los nombres correctos de las columnas o ajusta según tu estructura de tabla
        # Escribir el comando INSERT en el archivo
        file.write(f"INSERT INTO ZentraET0 VALUES ('{Datetime}', '{ETo}');\n")

# Cerrar conexión
cursor.close()
conn.close()

print("Archivo SQL generado exitosamente.")
