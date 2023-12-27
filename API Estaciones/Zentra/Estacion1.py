import requests
import json
import pandas as pd
import datetime
import time
import pymssql

# Configuración de la base de datos
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Configuración de la solicitud
device_sn = "z6-19634"
token = "91eeb5ba240a9941e2cece62dc48ce0fc2b7798c"
headers = {'content-type': 'application/json', 'Authorization': f'Token {token}'}
url = "https://zentracloud.com/api/v3/get_readings/"
end_date = datetime.datetime.today()
start_date = end_date - datetime.timedelta(days=60)

# Crear un diccionario para almacenar los datos
all_data = {}

# Función para obtener datos de la API
def get_sensor_data(page_num):
    params = {
        'device_sn': device_sn, 
        'start_date': start_date, 
        'end_date': end_date,
        'page_num': page_num, 
        'per_page': 500
    }

    # Realizar la solicitud
    response = requests.get(url, params=params, headers=headers)
    content1 = json.loads(response.content)['data']
    return content1

# Paginación
page_num = 1
while True:
    print('Espere...', page_num, flush=True)
    time.sleep(60)
    try:
        content = get_sensor_data(page_num)
        if not content:
            break
        
        for sensor, readings in content.items():
            for reading in readings[0]['readings']:
                datetime_key = reading['datetime']
                if datetime_key not in all_data:
                    all_data[datetime_key] = {}
                all_data[datetime_key][sensor] = reading['value']

    except Exception as e:
        print(f"Ocurrió un error en la página {page_num}: {e}", flush=True)

    page_num += 1

# Convertir el diccionario a DataFrame
df = pd.DataFrame.from_dict(all_data, orient='index')

# Reordenar las columnas para tener la fecha y hora como una columna, no como índice
df.reset_index(inplace=True)
df.rename(columns={'index': 'Datetime'}, inplace=True)
df = df.fillna(0)

df.to_excel('Estacion.xlsx', index=False)

# Conexión a la base de datos
with pymssql.connect(server, username, password, database) as conn:
    cursor = conn.cursor()

    # Insertar los datos en la base de datos
    for index, row in df.iterrows():
        print("ingresando", index, flush=True)
        cursor.execute("""
        IF NOT EXISTS (SELECT * FROM ZentraVar WHERE datetime = %s)
        BEGIN
            INSERT INTO ZentraVar (Datetime, AirTemperature, AtmosphericPressure, BatteryPercent, BatteryVoltage, GustSpeed, LightningActivity, LightningDistance, LoggerTemperature, MaxPrecipRate, Precipitation, RHSensorTemp, ReferencePressure, SolarRadiation, VPD, VaporPressure, WindDirection, WindSpeed, XaxisLevel, YaxisLevel, SensorOutput)
            VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)
        END
        """, (
            row['Datetime'], row['Datetime'], row['Air Temperature'], row['Atmospheric Pressure'], row['Battery Percent'],
            row['Battery Voltage'], row['Gust Speed'], row['Lightning Activity'], row['Lightning Distance'],
            row['Logger Temperature'], row['Max Precip Rate'], row['Precipitation'], row['RH Sensor Temp'],
            row['Reference Pressure'], row['Solar Radiation'], row['VPD'], #row['Vapor Pressure'],
            row['Wind Direction'], row['Wind Speed'], row['X-axis Level'], row['Y-axis Level'], row['Sensor Output']
        ))
    conn.commit()