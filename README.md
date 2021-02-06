# Dotnetcore5 Sample Application

The project is a sample .net Core 5 project.

 - Open Visual Studio and run with Docker

## TL;DR

Run with docker in any platform:

* create image `docker build -t dotnetcore5image .`
* run container `adocker run --name donetcore5-rest-api -d --memory=500m --cpus="1" -p 8086:80 --rm dotnetcore5image`
* You can find users on: `http://localhost:8086/users`

Mete  | Demirtas
------------- | -------------
DotNetCore5 | Sqlite
