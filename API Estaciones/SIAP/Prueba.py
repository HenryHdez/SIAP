import pyodbc
import pandas as pd

# Establece la cadena de conexión a tu base de datos SQL Server
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Crear la cadena de conexión
connection_string = f'DRIVER={{SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'

# Establecer la conexión a la base de datos
connection = pyodbc.connect(connection_string)

# Consulta SQL para obtener información sobre las tablas, columnas y sus restricciones
query = """
SELECT t.name AS table_name, c.name AS column_name, 
       TYPE_NAME(c.system_type_id) AS data_type, 
       c.max_length, c.precision,
       CASE
           WHEN pkc.column_name IS NOT NULL THEN 'Primary Key'
           WHEN ccu.column_name IS NOT NULL THEN 'Foreign Key'
           ELSE 'None'
       END AS constraint_type
FROM sys.tables t
INNER JOIN sys.columns c ON t.object_id = c.object_id
LEFT JOIN (
    SELECT i.name AS index_name, ic.column_id, c.name AS column_name
    FROM sys.indexes i
    INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    WHERE i.is_primary_key = 1
) AS pkc ON t.object_id = pkc.column_id
LEFT JOIN (
    SELECT fk.name AS constraint_name, fkc.parent_column_id, c.name AS column_name
    FROM sys.foreign_keys fk
    INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
    INNER JOIN sys.columns c ON fkc.parent_object_id = c.object_id AND fkc.parent_column_id = c.column_id
) AS ccu ON t.object_id = ccu.parent_column_id
ORDER BY t.name, c.column_id
"""

# Ejecutar la consulta y almacenar los resultados en un DataFrame de Pandas
df = pd.read_sql(query, connection)

# Cerrar la conexión
connection.close()

# Ruta del archivo de Excel donde se guardará la información
excel_file_path = 'informe_tablas_atributos.xlsx'

# Crear un escritor de Excel y guardar el DataFrame en un archivo Excel
with pd.ExcelWriter(excel_file_path) as writer:
    df.to_excel(writer, sheet_name='Tablas_Atributos', index=False)

print(f"Se ha creado el archivo Excel: {excel_file_path}")
