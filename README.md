# webApiEF
Aplicacion webAPI en C# y .Net 7, con postgres

Puedes correr el contenedor utilizando
$ docker-compose up --build

Para obtener informacion puedes utilizar el metodo Get
http://localhost:8088/api/usuarios/

Para guardar informacion puedes utilizar el metodo Post y mandar el json
http://localhost:8088/api/usuarios/
{
    "Nombre":"Daniel",
    "Correo":"daniel@123.com",
    "Edad":30
}

Para obtener respuestas paginadas debes enviar los parametros 
http://localhost:8088/api/usuarios?pagina=1&elementosPorPagina=5
por default envia 5 elementos por pagina
