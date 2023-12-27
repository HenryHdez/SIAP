import requests
import pandas as pd
import pymssql
import datetime
import json

# Función para obtener datos de la API
def get_sensor_data():
    # Configuración de la solicitud
    device_sn = "z6-19634"
    token = "91eeb5ba240a9941e2cece62dc48ce0fc2b7798c"
    headers = {'content-type': 'application/json', 'Authorization': f'Token {token}'}
    url = "https://zentracloud.com/api/v3/get_env_model_data/"
    params = {
        "device_sn": device_sn,
        "model_type": "ETo",
        "port_num": 1,
        "inputs": '{"elevation": 1580, "latitude": 8.1751913, "wind_measurement_height": 2}'
    }

    try:
        response = requests.get(url, params=params, headers=headers)
        response.raise_for_status()
        content = response.json()
        return content
    except requests.RequestException as e:
        print(f"Error al realizar la solicitud: {e}")
        return None

# Obtener datos de la API
content = get_sensor_data()

if content:
    # Extraer la lista de lecturas
    readings = content['data']['readings']

    # Preparar los datos para el DataFrame
    data = [{'Fecha': reading['datetime'], 'ETo': reading['value']} for reading in readings]

    # Crear el DataFrame
    df = pd.DataFrame(data)
    df = df.fillna(0)
    df.to_excel('Estacion.xlsx', index=False)
    # Configuración de la base de datos
    server = '172.16.11.44\MSSQL2016DEX'
    database = 'SEMapa'
    username = 'WebSeMapa'
    password = 'rdTGWjLYWIH6e0PKeXYl'

    # Conexión a la base de datos
    conn = pymssql.connect(server, username, password, database)
    cursor = conn.cursor()

    # Insertar datos en la base de datos
    for index, row in df.iterrows():
        print('Leyendo', index, flush=True)
        timestamp = str(row['Fecha'])
        eto_value = str(row['ETo'])

        # Verificar si el registro ya existe
        cursor.execute("SELECT COUNT(*) FROM ZentraET0 WHERE Datetime = %s", (timestamp,))
        if cursor.fetchone()[0] == 0:
            # Si no existe, insertar el nuevo registro
            cursor.execute("INSERT INTO ZentraET0 (Datetime, ETo) VALUES (%s, %s)", (timestamp, eto_value))

    # Confirmar transacción y cerrar conexión
    conn.commit()
    cursor.close()
    conn.close()