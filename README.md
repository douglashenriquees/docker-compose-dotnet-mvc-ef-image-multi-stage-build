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

* ```FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base```
  * utiliza a imagem do **aspnet 6.0** e atribui a ela o alias **base**
* ```WORKDIR /app```
  * cria e define a pasta **/app** como diretório de trabalho
* ```EXPOSE 80```
  * expõe a porta 80

* ```FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build```
  * utiliza a imagem do **dotnet sdk 6.0** e atribui a ela o alias **build**
* ```WORKDIR /src```
  * cria e define a pasta **/src** como diretório de trabalho
* ```COPY . .```
  * copia todos os arquivos do **host** para a pasta de trabalho dentro do container
* ```RUN dotnet restore```
  * executa o comando para restaurar as dependências do nuget dentro do container
* ```RUN dotnet publish -c Release -o app```
  * executa o comando para publicar a aplicação dentro da pasta **/src/app** do container

* ```FROM base AS final```
  * cria uma nova imagem apartir da imagem **base** e atribui a ela o alias **final**
* ```WORKDIR /app```
  * cria e define a pasta **/app** como diretório de trabalho
* ```COPY --from=build /app .```
  * copia o conteúdo da pasta **/src/app** da imagem **build** para o pasta de trabalho da imagem **final**
* ```ENTRYPOINT [ "dotnet", "mvc.dll" ]```
  * executa a aplicação de dentro da pasta de trabalho da imagem **final**

## Publicando a Imagem

* ```docker image build -t asp-net-mvc/app:5.0 .```
* ```docker image tag asp-net-mvc/app:5.0 username/mvc-produtos:5.0```
* ```docker login -u username```
* ```docker image push username/mvc-produtos:5.0```