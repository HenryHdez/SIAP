# !/usr/bin/env python 
# -*- coding: utf-8 -*-
"""----Definición de las librerías requeridas para la ejecución de la aplicación---"""
import pymssql 
import requests
import threading
from flask import Flask, request, render_template 
import pandas as pd 
import json
from time import sleep                                           #Suspensión temporal
from requests.auth import AuthBase
from datetime import datetime
from datetime import date
from datetime import timedelta
from dateutil.tz import tzlocal
from shapely import wkt
from Crypto.Hash import HMAC #Instalar pycryptodome==3.16.0
from Crypto.Hash import SHA256
from requests.auth import AuthBase

import requests
import pandas as pd
#import datetime
import json
import time
#python-dateutil==2.7.2
#pycrypto==2.6.1
#requests==2.18.4

app = Flask(__name__)

global str1
global str2
global str3
global str4
global str5
global estado 
estado = "Activo"
str1 = "No hay registros nuevos."
str2 = "No hay registros nuevos." 
str3 = "No hay registros nuevos." 
str4 = "No hay registros nuevos." 
str5 = "No hay registros nuevos." 
# Configuración de la base de datos
#host='COMOSDSQL08\MSSQL2016DEX'
server = '172.16.11.44\MSSQL2016DEX'
database = 'SEMapa'
username = 'WebSeMapa'
password = 'rdTGWjLYWIH6e0PKeXYl'

# Configuración de la solicitud
#Serial de la estación 
device_sn = "z6-19634"
#Clave generada en la plataforma ZentraCloud
token = "91eeb5ba240a9941e2cece62dc48ce0fc2b7798c"
#Formato de salida de la consulta
headers = {'content-type': 'application/json', 'Authorization': f'Token {token}'}
#URL lectura de variables
url_readings = "https://zentracloud.com/api/v3/get_readings/"
#URL lectura de ET0
url_env_model = "https://zentracloud.com/api/v3/get_env_model_data/"
end_date = datetime.today()
#Fecha de inicio de la consulta
start_date = end_date - timedelta(days=60)

# Clase para leer usando la HMAC
# Librería proporcionada por el fabricante
class AuthHmacMetosGet(AuthBase):
    # Creates HMAC authorization header for Metos REST service GET request.
    def __init__(self, apiRoute, publicKey, privateKey):
        self._publicKey = publicKey
        self._privateKey = privateKey
        self._method = 'GET'
        self._apiRoute = apiRoute

    def __call__(self, request):
        dateStamp = datetime.utcnow().strftime('%a, %d %b %Y %H:%M:%S GMT')
        request.headers['Date'] = dateStamp
        msg = (self._method + self._apiRoute + dateStamp + self._publicKey).encode(encoding='utf-8')
        h = HMAC.new(self._privateKey.encode(encoding='utf-8'), msg, SHA256)
        signature = h.hexdigest()
        request.headers['Authorization'] = 'hmac ' + self._publicKey + ':' + signature
        return request

# Función para obtener datos de la API
def get_sensor_data1(page_num):
    params = {
        'device_sn': device_sn, 
        'start_date': start_date, 
        'end_date': end_date,
        'page_num': page_num, 
        'per_page': 500
    }
    # Realizar la solicitud
    response = requests.get(url_readings, params=params, headers=headers)
    content1 = json.loads(response.content)['data']
    return content1

# Función para obtener datos de la API
def get_sensor_data2():
    params = {
        "device_sn": device_sn,
        "model_type": "ETo",
        "port_num": 1,
        "inputs": '{"elevation": 1580, "latitude": 8.1751913, "wind_measurement_height": 2}'
    }
    try:
        response = requests.get(url_env_model, params=params, headers=headers)
        response.raise_for_status()
        content = response.json()
        return content
    except requests.RequestException as e:
        print(f"Error al realizar la solicitud: {e}")
        return None

#Actualizar la información de la tabla ZentraVar de la DB
def Read_Var():
    # Crear un diccionario para almacenar los datos
    all_data = {}
    page_num = 1
    while True:
        print('Espere...', page_num, flush=True)
        time.sleep(60)
        try:
            content = get_sensor_data1(page_num)
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
    df.reset_index(inplace=True)
    df.rename(columns={'index': 'Datetime'}, inplace=True)
    df = df.fillna(0)
    #Guardar archivo en formato excel
    df.to_excel('static/Estacion.xlsx', index=False)
    # Conexión a la base de datos
    with pymssql.connect(server, username, password, database) as conn:
        cursor = conn.cursor()
        # Insertar los datos en la base de datos
        for index, row in df.iterrows():
            print("ingresando", index, flush=True)
            # Verificar y asignar un valor de cero si el campo no existe en la fila
            air_temperature = row['Air Temperature'] if 'Air Temperature' in row else 0
            atmospheric_pressure = row['Atmospheric Pressure'] if 'Atmospheric Pressure' in row else 0
            battery_percent = row['Battery Percent'] if 'Battery Percent' in row else 0
            battery_voltage = row['Battery Voltage'] if 'Battery Voltage' in row else 0
            gust_speed = row['Gust Speed'] if 'Gust Speed' in row else 0
            lightning_activity = row['Lightning Activity'] if 'Lightning Activity' in row else 0
            lightning_distance = row['Lightning Distance'] if 'Lightning Distance' in row else 0
            logger_temperature = row['Logger Temperature'] if 'Logger Temperature' in row else 0
            max_precip_rate = row['Max Precip Rate'] if 'Max Precip Rate' in row else 0
            precipitation = row['Precipitation'] if 'Precipitation' in row else 0
            rh_sensor_temp = row['RH Sensor Temp'] if 'RH Sensor Temp' in row else 0
            reference_pressure = row['Reference Pressure'] if 'Reference Pressure' in row else 0
            solar_radiation = row['Solar Radiation'] if 'Solar Radiation' in row else 0
            vpd = row['VPD'] if 'VPD' in row else 0
            relative_humidity = row['Relative Humidity'] if 'Relative Humidity' in row else 0
            wind_direction = row['Wind Direction'] if 'Wind Direction' in row else 0
            wind_speed = row['Wind Speed'] if 'Wind Speed' in row else 0
            x_axis_level = row['X-axis Level'] if 'X-axis Level' in row else 0
            y_axis_level = row['Y-axis Level'] if 'Y-axis Level' in row else 0
            sensor_output = row['Sensor Output'] if 'Sensor Output' in row else 0
            #Ejecutar el cursor
            cursor.execute("""
            IF NOT EXISTS (SELECT * FROM ZentraVar WHERE datetime = %s)
            BEGIN
                INSERT INTO ZentraVar (Datetime, AirTemperature, AtmosphericPressure, BatteryPercent, BatteryVoltage, GustSpeed, LightningActivity, LightningDistance, LoggerTemperature, MaxPrecipRate, Precipitation, RHSensorTemp, ReferencePressure, SolarRadiation, VPD, VaporPressure, WindDirection, WindSpeed, XaxisLevel, YaxisLevel, SensorOutput)
                VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)
            END
            """, (
                row['Datetime'], row['Datetime'], air_temperature, atmospheric_pressure, battery_percent,
                battery_voltage, gust_speed, lightning_activity, lightning_distance,
                logger_temperature, max_precip_rate, precipitation, rh_sensor_temp,
                reference_pressure, solar_radiation, vpd, relative_humidity,
                wind_direction, wind_speed, x_axis_level, y_axis_level, sensor_output
            ))
        conn.commit()

#Actualizar la información de la tabla ZentraET0 de la DB
def Read_ET0():
    # Obtener datos de la API
    content = get_sensor_data2()
    if content:
        # Extraer la lista de lecturas
        readings = content['data']['readings']
        # Preparar los datos para el DataFrame
        data = [{'Fecha': reading['datetime'], 'ETo': reading['value']} for reading in readings]
        # Crear el DataFrame
        df = pd.DataFrame(data)
        df = df.fillna(0)
        #Guardar archivo en formato excel
        df.to_excel('static/Estacion2.xlsx', index=False)        
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
        conn.commit()
        cursor.close()
        conn.close()

def Crear_Tabla(etiquetas, estacion):
    Texto=""
    for i in range(len(etiquetas)):
        if i==0:
            Texto="CREATE TABLE dbo.SITB_Estacion_"+str(estacion)+" (Est"+str(estacion)+"_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, "
        elif(i==1):    
            Texto=Texto+"Est_Id VARCHAR(50), "+etiquetas[i]+"  VARCHAR(50), "
        elif(i==len(etiquetas)-1):
            Texto=Texto+etiquetas[i]+" NUMERIC(10,2));"
        else:
            Texto=Texto+etiquetas[i]+" NUMERIC(10,2), "
    operardb(0, Texto, 0 ,"Crear")
    
def Consultar_Estacion(Ser_e,Fecha_unix_1,Fecha_unix_2):
    apiURI = 'https://api.fieldclimate.com/v1'
    # Autenticación o HMAC
    publicKey = '302ead2262739c6e79253adf70ca808da9d956488f380b67'
    privateKey = '6fc194ada406785b9e58b8c23b8a0d60da4f23ec373dfe20'
    # Definición del servicio
    apiRoute = '/data/normal/'+Ser_e+'/hourly/from/'+Fecha_unix_1+'/to/'+Fecha_unix_2
    auth = AuthHmacMetosGet(apiRoute, publicKey, privateKey)
    response = requests.get(apiURI+apiRoute, headers={'Accept': 'application/json'}, auth=auth)
    try:
        json_temp=response.json()
        return json_temp
    except:
        return []
    
def Consultar_API(accion, estacion):
    #002056BF Inicio 2019-01-10 12:00:00 Finca Casateja Facatativá 1547121600 hasta 2020 12 10 12 0 0 1607601600 2021 9 8 12 00 00 1631102400
    #00206878 Inicio 2018-08-24 07:00:00 C.I. Tibaitatá 1535112000
    #31017600 al año
    #Consultar sensor
    Sensor=operardb(0, "dbo.SITB_SenEst"+str(estacion), 0 ,"Consulta")
    llaves=list(Sensor['Sen'+str(estacion)+'_Columnas'].values)
    llaves.insert(0,'Est_Id')
    llaves.insert(1,'Est'+str(estacion)+'_Fecha')
    nombres_sens=list(Sensor['Sen'+str(estacion)+'_Direccion'].values)
    nombres_sens.insert(0,'date') 
    tam_lista=0
    global str1
    global str2
    global str3       
    try:
        tabla=operardb(0, "dbo.SITB_Estacion_"+str(estacion), 0 ,"Consulta")
        Ser_e="002056BF"
        if(estacion==1):
            Ser_e="002056BF"
        elif(estacion==2):
            Ser_e="00206878"
        elif(estacion==3):
            Ser_e="0020687D"
        if(len(tabla)!=0):
            TT=tabla['Est'+str(estacion)+'_Fecha'].values 
            Ultima_Fecha = datetime.strptime(TT[len(TT)-1], '%Y-%m-%d %H:%M:%S')
            Ultima_Fecha = Ultima_Fecha.timestamp()+3600    
        else:
            Ultima_Fecha = 1514808000
        hoy=datetime.now()
        Fecha_actual = hoy.strftime("%Y-%m-%d %H:%M:00")
        Fecha_actual = datetime.strptime(Fecha_actual, '%Y-%m-%d %H:%M:%S')
        Fecha_actual = int(Fecha_actual.timestamp())
        
        print(datetime.fromtimestamp(Fecha_actual))
        print(datetime.fromtimestamp(Ultima_Fecha))

        if(estacion==1):
            str1 = "No hay registros nuevos. Desde: "+str(datetime.fromtimestamp(Ultima_Fecha))
            print(str1)
        elif(estacion==2):
            str2 = "No hay registros nuevos. Desde: "+str(datetime.fromtimestamp(Ultima_Fecha))
            print(str2)
        else:
            str3 = "No hay registros nuevos. Desde: "+str(datetime.fromtimestamp(Ultima_Fecha))
            print(str3)

        json_est=Consultar_Estacion(Ser_e,str(Ultima_Fecha),str(Fecha_actual))
        try:
            datos=json_est['data']
            extra=json_est['extra']['model']
        except:
            datos=[]
            extra=[]
        diferencia=Fecha_actual-Ultima_Fecha
        print(diferencia)
        tam_lista=len(datos)
        
        while(tam_lista>8000):
            print("Mayores")
            print(Fecha_actual)
            Fecha_actual=Fecha_actual-int(diferencia/10)
            json_est=Consultar_Estacion(Ser_e,str(Ultima_Fecha),str(Fecha_actual))
            try:
                datos=json_est['data']
                extra=json_est['extra']['model']
            except:
                datos=[]
                extra=[]
            tam_lista=len(datos)
         
        diferencia=Fecha_actual-Ultima_Fecha  
        while(31536000<=diferencia and tam_lista<100):
            #Ultima_Fecha=Ultima_Fecha+int(diferencia/4)
            #diferencia=Fecha_actual-Ultima_Fecha
            print("Menores")
            print(Fecha_actual)
            Fecha_actual=Fecha_actual-int(diferencia/4)
            diferencia=Fecha_actual-Ultima_Fecha
            json_est=Consultar_Estacion(Ser_e,str(Ultima_Fecha),str(Fecha_actual))
            try:
                datos=json_est['data']
                extra=json_est['extra']['model']
            except:
                datos=[]
                extra=[]
            tam_lista=len(datos) 
        print(tam_lista)
    except:
        print("Creando tabla")
    
    if(accion==0):
        Crear_Tabla(llaves, estacion)     
        
    elif(accion==1 and 2<int(tam_lista)):  
        #Crear vector de inicio
        aux=['Est_Id', 'Est'+str(estacion)+'_Fecha']
        dfg=pd.DataFrame(columns=llaves)
        for i in range(1,len(nombres_sens)):
            aux.append(0) 
        mem=aux
        for i in datos:
            aux=None
            aux=mem
            for ind, j in enumerate(nombres_sens):
                aux[0]=Ser_e
                try:
                    temp=i[j]
                except:
                    temp=0
                if(temp!=None):
                    aux[ind+1]=temp
                else:
                    aux[ind+1]=0
            for w in extra:
                if(w['date']==aux[1]):
                    if(estacion==1):
                        aux[39]=w['ETo[mm]']
                    else:
                        aux[35]=w['ETo[mm]']
                    break
            dfg.loc[len(dfg)]=aux
        operardb(dfg, "dbo.SITB_Estacion_"+str(estacion), 0 ,"Actualizar")  

def Actualizar_pag():
    #0 Crear Estacion
    #1 Actualizar Estacion
    global estado
    global str4
    global str5
    
    conta=1
    while True:
        estado="Estacion "+str(conta)+" "+ str(datetime.now())+"\n"
        print(estado, flush=True)
        
        if(conta<4):
            try:
                Consultar_API(0, conta)
            except:
                estado=estado+"Tabla existente " + str(datetime.now())+"\n"
                print(estado, flush=True)
            try:
                Consultar_API(1, conta)
                estado=estado+"Finalizado " + str(datetime.now())+"\n"
                print(estado, flush=True)          
            except: 
                estado=estado+"No hay registros que actualizar " + str(datetime.now())+"\n"
                print(estado, flush=True)       
        elif(conta==4):  
            try:
                estado=estado+"ZentraVar... " + str(datetime.now())+"\n"
                str4="ZentraVar... " + str(datetime.now())+"\n"
                print(estado, flush=True)   
                Read_Var()
                sleep(60)
                estado=estado+"ZentraET0... " + str(datetime.now())+"\n"
                str5="ZentraET0... " + str(datetime.now())+"\n"
                print(estado, flush=True)                   
                Read_ET0()
            except:
                estado=estado+"No hay registros que actualizar " + str(datetime.now())+"\n"
                print(estado, flush=True)  

            try:
                estado=estado+"Registrando... " + str(datetime.now())+"\n"
                print(estado, flush=True)   
                operardb(0, 0, 0 ,"RegEstacion")
            except:   
                estado=estado+"Error actualizando " + str(datetime.now())+"\n"
                print(estado, flush=True)   
            sleep(33200)
            sleep(10000)
            sleep(10)
            estado = " "
            conta=0
        conta=conta+1

def textsal(table,avi):
    global str1
    global str2
    global str3
    if(table=="dbo.SITB_Estacion_1"):
        str1=avi
    elif(table=="dbo.SITB_Estacion_2"):
        str2=avi
    else:
        str3=avi

#Función para operar la base de datos utilizando otras funciones
def operardb(df, tabla, geom ,accion):
    global str1
    global str2
    global str3
    global str4
    global str5
    #Conexión con la base de datos
    cnxn = pymssql.connect(server, username, password, database)

    if(accion=="Actualizar"):
        cursor = cnxn.cursor()
        cols = ", ".join([str(i) for i in df.columns.tolist()])
        textsalavi=""
        for i,row in df.iterrows():
            sql = "INSERT INTO "+tabla+" (" +cols + ") VALUES (" + "%s,"*(len(row)-1) + "%s)"
            try:
                cursor.execute(sql, tuple(row))
                cnxn.commit()
                textsalavi=textsalavi+" Actualizado "+str(i)
                print("Actualizado "+str(i), flush=True)
                textsal(tabla,"Actualizado "+str(i))
            except:
                textsalavi=textsalavi+" No actualizado" + str(tuple(row))
                print("No actualizado" + str(tuple(row)), flush=True)
        textsal(tabla,textsalavi)
        return[]
    
    elif(accion=="Consulta"):
        df1=pd.read_sql('SELECT * FROM '+tabla+';',cnxn)
        return df1

    elif(accion=="Crear"):
        try:
            cursor = cnxn.cursor()
            cursor.execute(tabla)
            cnxn.commit()
            textsal(tabla,"Historial reiniciado.")
        except:
            cursor = cnxn.cursor()
            print("No hay registros nuevos", flush=True)
            #textsal(tabla,"No hay registros nuevos")
        return 0
    elif(accion=="RegEstacion"):
            fecha_actual = datetime.today()
            # Insertar datos en la base de datos
            cursor = cnxn.cursor()
            query = "INSERT INTO SITB_RegEst (Fecha, SIAP01, SIAP02, SIAP03, ZentraVar, ZentraET0) VALUES (%s, %s, %s, %s, %s, %s)"
            values = (fecha_actual, str1, str2, str3, str4, str5)
            cursor.execute(query, values)
            cnxn.commit()
            print('Exito', flush=True)
    
    cnxn.close()

#Directorio raíz (página principal)
@app.route('/')
def index():
    global estado
    return render_template('index.html', titulo=estado)

def correr_pag():
    app.run(host='0.0.0.0', port='8001')

#Función principal    
if __name__ == '__main__':
    hilo1 = threading.Thread(target=correr_pag)
    hilo1.start() 
    hilo2 = threading.Thread(target=Actualizar_pag)
    hilo2.start() 
