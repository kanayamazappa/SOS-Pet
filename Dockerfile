FROM python:3.8-slim-buster

ENV PYTHONDONTWRITEBYTECODE 1
ENV PYTHONUNBUFFERED 1
ENV PATH="/scripts:${PATH}"

RUN pip install --upgrade pip

# Cria diretório onde vão ficar os fontes
RUN mkdir /code

# Define o diretório de trabalho
WORKDIR /code

# "Copia" arquivo requirements.txt para o diretorio code
ADD requirements.txt /code/

# Executa o pip
RUN apt-get update
RUN apt-get install -y --no-install-recommends gcc libc-dev python3-dev default-libmysqlclient-dev
RUN pip install --upgrade pip && pip install -r requirements.txt

# "Copia" os arquivos locais para o diretorio code no container 
ADD . /code/