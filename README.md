## Docker Compose

* ```docker-compose -p application build --no-cache```
  * o parâmetro ```-p``` define o prefixo para criação dos volumes, redes e containers. Caso não informado, será utilizado o nome do diretório como prefixo
* ```docker-compose -p application up -d```
* ```docker container ps -a```
* ```docker container exec -it application_mysql_1 /bin/bash```
* ```mysql -u root -p```
* ```show databases;```
* ```docker-compose -p application down --rmi all -v```
  * ```--rmi all``` remove também as imagens que foram baixadas para o **host**

## Dockerfile

* ```FROM mcr.microsoft.com/dotnet/sdk:6.0```
  * imagem com base no **sdk** do dotnet 6.0
* ```LABEL version="4.0" description="Aplicacao ASP .NET MVC```
  * versão e descrição da imagem
* ```RUN mkdir /app```
  * o comando **RUN** executa ações dentro do container. Neste caso, criar o diretório **/app** na raiz do container
* ```WORKDIR /app```
  * o comando **WORKDIR** define o diretório de trabalho dentro do container. Isso faz as instruções abaixo serem executadas dentro do diretório estabalecido, até o final do arquivo, ou até outro comando com a sentença **WORKDIR**
* ```COPY . .```
  * copia todos os arquivos do **host** para a pasta **"/app - WORKDIR"** do container
* ```RUN dotnet restore```
  * executa o comando para restaurar as dependências do nuget dentro do container
* ```RUN dotnet publish -c Release -o dist```
  * executa o comando para publicar a aplicação dentro da pasta **dist** no **WORKDIR** do container
* ```EXPOSE 80/tcp```
  * expõe a porta **80** do container
* ```ENV ASPNETCORE_URLS=http://+:5000```
  * define também a porta **5000** para ser exposta. Configuração específica desta imagem do **dotnet/sdk**
* ```CMD [ "dotnet", "dist/mvc.dll" ]```
  * o **CMD** tem o mesmo efeito do **ENTRYPOINT**. Executar o **dotnet** sobre o arquivo **.dll** publicado no container

## Publicando a Imagem

* ```docker image build -t asp-net-mvc/app:4.0 .```
* ```docker image tag asp-net-mvc/app:4.0 username/mvc-produtos:4.0```
* ```docker login -u username```
* ```docker image push username/mvc-produtos:4.0```