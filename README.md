# webApiEF
Aplicacion webAPI en C# y .Net 7, con postgres

Se debe descargar docker en postgres para revisar el funcionamiento

$ docker pull postgres
$ docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres

$ psql --command "CREATE USER useredbrow WITH SUPERUSER PASSWORD 'redbrow2111';" && \
    createdb -O useredbrow redbrow

Posteriormente realizar las migraciones necesarias para crear los esquemas

$ dotnet-ef migrations add

$ dotnet-ef migrations update

