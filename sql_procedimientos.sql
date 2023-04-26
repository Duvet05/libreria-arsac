
DROP PROCEDURE IF EXISTS INSERTAR_EMPLEADO;
DROP PROCEDURE IF EXISTS INSERTAR_VENDEDOR;
DROP PROCEDURE IF EXISTS LISTAR_EMPLEADOS_TODOS;

DROP PROCEDURE IF EXISTS MODIFICAR_EMPLEADO;
DROP PROCEDURE IF EXISTS ELIMINAR_EMPLEADO;
DELIMITER $
CREATE PROCEDURE INSERTAR_EMPLEADO(
	OUT _id_empleado INT,
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _DNI VARCHAR(8),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _cargo varchar(70),
    IN _fechaContratacion DATE,
    IN _salario decimal(10,2),
	IN _direccion VARCHAR(100),
    IN _contrasena VARCHAR(50)
)
BEGIN
	INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo) VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, 1);
    SET _id_empleado = @@last_insert_id;
    INSERT INTO empleado(idEmpleado,cargo,fechaContratacion,salario,direccion, contrasena) 
			VALUES(_id_empleado,_cargo,_fechaContratacion,_salario,_direccion, _contrasena);
END$

/*call INSERTAR_EMPLEADO(@aea,"JORGE", "GUZMAN MERCURI", "45852158", "jorge.guzman@upc.edu.pe", "985625621",
		"GERENTE", "2019-04-12", 3500.00, "0x0007777B", "84851596200");
*/

delimiter $
CREATE PROCEDURE LISTAR_EMPLEADOS_TODOS()
BEGIN
	select idUsuario, nombre, apellidos, DNI, correo, telefono, cargo, fechaContratacion, salario, direccion
    from persona p inner join empleado e on p.idUsuario = e.idEmpleado
    where p.activo = 1
    union
    select idUsuario, nombre, apellidos, DNI, correo, telefono, cargo, fechaContratacion, salario, direccion 
    from persona p inner join empleado e on p.idUsuario = e.idEmpleado inner join vendedor v on v.idVendedor = e.idEmpleado
    where p.activo = 1;
END$


delimiter $
CREATE PROCEDURE INSERTAR_VENDEDOR(
	OUT _id_empleado INT,
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _DNI VARCHAR(8),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _cargo varchar(70),
    IN _fechaContratacion DATE,
    IN _salario decimal(10,2),
	IN _direccion VARCHAR(100),
    IN _contrasena VARCHAR(50),
    IN _cantidadVentas INT,
    IN _totalVendido decimal(10,2)
)
BEGIN
	INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo) VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, 1);
    SET _id_empleado = @@last_insert_id;
    INSERT INTO empleado(idEmpleado,cargo,fechaContratacion,salario,direccion, contrasena) 
			VALUES(_id_empleado,_cargo,_fechaContratacion,_salario,_direccion, _contrasena);
	INSERT INTO vendedor(idVendedor, cantVentas, totalVendido) values(_id_empleado, _cantidadVentas, _totalVendido);
END$

call INSERTAR_EMPLEADO(@aea,"JORGE", "GUZMAN MERCURI", "45852158", "jorge.guzman@upc.edu.pe", "985625621",
		"GERENTE", "2019-04-12", 3500.00, "0x0007777B", "84851596200");
call INSERTAR_VENDEDOR(@aea, "MAURICIO", "ARENALES AQUINO", "60977821", "arenales.mauriciol@upc.edu.pe", "987654321",
		"VENDEDOR", "2023-01-20", 2500.00, "0x0000123B", "10203040ESX", 253, 15263.00);
        
call LISTAR_EMPLEADOS_TODOS();



