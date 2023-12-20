#Sistema operativo
FROM ubuntu:18.04 as build
#Directorio de trabajo
WORKDIR /app
#Copiar todos los archivos ..
COPY .. /app/ 
# INSTALAR PIP
RUN apt update && apt install -y python3-pip
#INSTALACIÓN DE PAQUETES
RUN pip3 install --upgrade pip
RUN pip3 install --upgrade setuptools
RUN pip install -U pip
RUN apt update
#RUN apt install -y libpq-dev gdal-bin libgdal-dev
#Puerto definido por el usuario
COPY requirements.txt /app/requirements.txt
RUN pip3 install -r requirements.txt
EXPOSE 8001
#Ejecución del SCRIPT en el terminal
CMD ["python3", "index.py"]

# Usar una imagen base de Python
#FROM python:3.9

# Establecer el directorio de trabajo en el contenedor
#WORKDIR /app

#COPY .. .

#INSTALACIÓN DE PAQUETES
#RUN pip3 install --upgrade pip
#RUN pip3 install --upgrade setuptools
#RUN pip install -U pip
#RUN apt update
#RUN apt install -y libpq-dev gdal-bin libgdal-dev

#RUN pip install --no-cache-dir -r requirements.txt

# Comando para ejecutar el script de Python
#CMD ["python", "./index.py"]
