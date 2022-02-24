# ApiRestVacunaPersonal
ApiRestFull que contiene varios servicios CRUD


## Como desplegar la solución web ventana de Administrador
* Abrir la carpeta "farma_API_REST", ahí encontrará un archivo .sln llamado "farma_API_REST.sln"
* Doble clic en el archivo "farma_API_REST.sln", esto nos permitirá abrir la solución completa.
* Una vez abierta la solución ejecutamos (ctrl+F5), esta configurado para que por default se despliegue la App Web.
* Se abrirá la una ruta similar a la siguiente: "https://localhost:44383/Admin/IndexAdmin" que es la página del Administrador.
* Realizar las distintas pruebas.

## Como desplegar la solución web ventana de Empleado
* Para dirigirce a la ventana de empleados debe colocar la siguiente ruta: "https://localhost:44383/Empleado/IndexEmpleado?id=1805407226";
		cambié el puerto según su despliegue https://localhost:(44383->va a cambiar)
		lo que sigue de la url "Empleado/IndexEmpleado?id=1805407226" se mantendrá donde "id" es el número de cédula del cliente que quiera ingresar.
* Realizar las distintas pruebas.

## Verificar API REST expuesta
*Dirigirce a la siguiente url:http://jmpadillaj-001-site1.dtempurl.com/
*Dar clic en la opción "API".
*Verificar los distintos servicios expuestos.


## Como desplegar la solución API REST en local
* Abrir su gestor de base de datos de Microsoft SQL Server.
* Abrir el archivo "ScriptDataBase" que se encuentra en la carpeta inicial y ejecutar todo el script.
* Cambiar la cadena de conexión:
   --Dentro del proyecto "farma_API_REST" existe el archivo web.config, buscar la cadena de conexión.
   <connectionStrings>    
	<add name="DefaultConnectionlocal" connectionString="Data Source=ipmaquina,1434;Database=farma_prueba;User Id=sa;Password=****;" />
   <connectionStrings> 
	..Cambiar el  "Data Source=172.23.176.1,1434" (colocar la ip de su servidor de base de datos y el puerto respectivo, o en su defecto poner localhost)
	..Cambiar el "Id=sa" (colocar el nombre su usuario con el que se conecta a la base de datos.)
	..Cambiar el "Password=admin" (colocar la contraseña con la que ingresa a la base de datos.)
   
* Ejecutamos el proyecto (ctrl+F5).
* Verificamos los distintos servicios existentes al dar clic en la opción "API".


##Happy testing!

