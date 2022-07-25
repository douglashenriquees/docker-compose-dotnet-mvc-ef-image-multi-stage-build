FROM mcr.microsoft.com/dotnet/sdk:6.0
LABEL version="4.0" description="Aplicacao ASP .NET MVC"
RUN mkdir /app
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o dist
EXPOSE 80/tcp
ENV ASPNETCORE_URLS=http://+:5000
CMD [ "dotnet", "dist/mvc.dll" ]