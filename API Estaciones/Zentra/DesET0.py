import pandas as pd
import pymssql

# Configuración de la base de datos
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Leer el archivo de Excel
file_path = 'ETo.xlsx'  # Actualiza con la ruta a tu archivo de Excel
df = pd.read_excel(file_path)
df = df.fillna(0)
# Convertir y formatear la columna de fecha
df['timestamp'] = pd.to_datetime(df['timestamp'])
df['timestamp'] = df['timestamp'].apply(lambda x: x.replace(second=59))
df['timestamp'] = df['timestamp'].dt.tz_localize(None).dt.strftime('%Y-%m-%d %H:%M:%S%z')

# Conexión a la base de datos
conn = pymssql.connect(server, username, password, database)
cursor = conn.cursor()

# Insertar datos en la base de datos
for index, row in df.iterrows():
    timestamp = str(row['timestamp'])+'-05:00'
    eto_value = row['ETo - Port 1 mm']  # Asegúrate de que este es el nombre correcto de la columna
    # Suponiendo que tienes una tabla llamada 'TuTabla' con columnas 'timestamp' y 'eto_value'
    cursor.execute("INSERT INTO ZentraET0(Datetime, ETo) VALUES (%s, %s)", (timestamp, str(eto_value)))

# Confirmar transacción y cerrar conexión
conn.commit()
cursor.close()
conn.close()
