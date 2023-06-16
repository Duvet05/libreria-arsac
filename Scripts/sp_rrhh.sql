DROP PROCEDURE IF EXISTS VERIFICAR_CUENTA_DE_USUARIO;
DROP PROCEDURE IF EXISTS EncryptPassword;
DROP PROCEDURE IF EXISTS DecryptPassword;
DROP PROCEDURE IF EXISTS LISTAR_TIPOS_DE_EMPLEADOS;
DROP PROCEDURE IF EXISTS INSERTAR_EMPLEADO;
DROP PROCEDURE IF EXISTS LISTAR_EMPLEADOS_POR_SEDE_NOMBRE_DNI;
DROP PROCEDURE IF EXISTS LISTAR_EMPLEADOS_POR_NOMBRE_DNI;
DROP PROCEDURE IF EXISTS ACTUALIZAR_EMPLEADO;
DROP PROCEDURE IF EXISTS ELIMINAR_EMPLEADO;
DROP PROCEDURE IF EXISTS INSERTAR_CLIENTE_MAYORISTA;
DROP PROCEDURE IF EXISTS LISTAR_CLIENTES_MAYORISTAS_POR_NOMBRE_DNI;
DROP PROCEDURE IF EXISTS ACTUALIZAR_CLIENTE_MAYORISTA;
DROP PROCEDURE IF EXISTS ELIMNAR_CLIENTE_MAYORISTA;

DELIMITER $

-- CUENTA DE USUARIO

CREATE PROCEDURE EncryptPassword(
	IN password VARCHAR(255), 
    OUT encrypted_password VARBINARY(255)
)
BEGIN
    SET @key = 'arsac';
    SET encrypted_password = AES_ENCRYPT(password, @key);
END $

CREATE PROCEDURE DecryptPassword(
	IN encrypted_password VARBINARY(255), 
    OUT decrypted_password VARCHAR(255)
)
BEGIN
    SET @key = 'arsac';
    SET decrypted_password = CAST(AES_DECRYPT(encrypted_password, @key) AS CHAR);
END $


CREATE PROCEDURE INSERTAR_CUENTA_USUARIO(
	OUT _id_cuenta_usuario INT,
    IN _fid_empleado INT,
    IN _username VARCHAR(100),
    IN _password VARCHAR(100)
)BEGIN
	INSERT INTO cuenta_usuario(fid_empleado,username,password,activo) 
    VALUES(_fid_empleado,_username,EncryptPassword(_password),1);
END$

CREATE PROCEDURE VERIFICAR_CUENTA_USUARIO(
	_username VARCHAR(100),
    _password VARCHAR(100)
)
BEGIN
	SELECT id_cuenta_usuario, fid_empleado, username, 
    password FROM cuenta_usuario WHERE username = _username AND password = 
    MD5(_password) AND activo = 1;
END$

-- EMPLEADO

CREATE PROCEDURE LISTAR_TIPOS_DE_EMPLEADOS(
)
BEGIN
	SELECT id_tipo_empleado, descripcion from tipoEmpleado where activo = 1;
END $


CREATE PROCEDURE INSERTAR_EMPLEADO(
    OUT _id_empleado INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _fid_sede INT,
    IN _fid_tipo_empleado INT,
    IN _fecha_contratacion DATE,
    IN _salario DECIMAL(10,2),
    IN _direccion VARCHAR(100)  
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo)
    VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, true);
    SET _id_empleado = LAST_INSERT_ID();
    INSERT INTO empleado(id_empleado, fid_sede, fid_tipo_empleado, fecha_contratacion, salario, direccion) 
	VALUES(_id_empleado, _fid_sede, _fid_tipo_empleado, _fecha_contratacion, _salario, _direccion);
END $


CREATE PROCEDURE LISTAR_EMPLEADOS_POR_SEDE_NOMBRE_DNI(
	IN _id_sede INT,
    IN _nombre_DNI VARCHAR(1000)
)
BEGIN
	SELECT e.id_empleado, p.nombre, p.apellidos, p.DNI, p.correo, p.telefono,
    s.id_sede, s.es_principal as trabaja_en_sede_principal,
    te.id_tipo_empleado, te.descripcion as tipo_empleado,
    e.fecha_contratacion, e.salario, e.direccion
    FROM empleado e
    inner join persona p on e.id_empleado = p.id_persona and p.activo = 1
    inner join tipoEmpleado te on te.id_tipo_empleado = e.fid_tipo_empleado
    inner join sede s on s.id_sede = e.fid_sede and s.id_sede = _id_sede
    where (CONCAT(p.nombre,' ',p.apellidos) LIKE CONCAT('%',_nombre_DNI,'%')) OR (p.DNI LIKE CONCAT('%',_nombre_DNI,'%'));
END $

CREATE PROCEDURE LISTAR_EMPLEADOS_POR_NOMBRE_DNI(
    IN _nombre_DNI VARCHAR(1000)
)
BEGIN
	SELECT e.id_empleado, p.nombre, p.apellidos, p.DNI, p.correo, p.telefono,
    s.id_sede, s.direccion as direccion_de_sede, s.es_principal as trabaja_en_sede_principal,
    te.id_tipo_empleado, te.descripcion as tipo_empleado,
    e.fecha_contratacion, e.salario, e.direccion
    FROM empleado e
    inner join persona p on e.id_empleado = p.id_persona and p.activo = 1
    inner join tipoEmpleado te on te.id_tipo_empleado = e.fid_tipo_empleado
    inner join sede s on s.id_sede = e.fid_sede
    where (CONCAT(p.nombre,' ',p.apellidos) LIKE CONCAT('%',_nombre_DNI,'%')) OR (p.DNI LIKE CONCAT('%',_nombre_DNI,'%'));
END $


CREATE PROCEDURE ACTUALIZAR_EMPLEADO(
	IN _id_empleado INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _fid_sede INT,
    IN _fid_tipo_empleado INT,
    IN _fecha_contratacion DATE,
    IN _salario DECIMAL(10,2),
    IN _direccion VARCHAR(100)
)
BEGIN
	UPDATE persona
    SET
    nombre = _nombre, apellidos = _apellidos, DNI = _DNI, correo = _correo, telefono = _telefono
    where id_persona = _id_empleado;
    
    UPDATE empleado
    SET
    fid_sede = _fid_sede, fid_tipo_empleado = _fid_tipo_empleado,
    fecha_contratacion = _fecha_contratacion, salario = _salario, direccion = _direccion
    where id_empleado = _id_empleado;
END $


CREATE PROCEDURE ELIMINAR_EMPLEADO(
	IN _id_empleado INT
)
BEGIN
	UPDATE persona
    SET activo = false
    where id_persona = _id_empleado;
END $

-- CLIENTE MAYORISTA

CREATE PROCEDURE INSERTAR_CLIENTE_MAYORISTA(
	OUT _id_cliente_mayorista INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _RUC VARCHAR(50),
    IN _razon_social VARCHAR(50)
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo)
	VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, true);
	
    SET _id_cliente_mayorista = last_insert_id();
    
    INSERT INTO clienteMayorista(RUC, razon_social)
    VALUES(_RUC, _razon_social);
END $

CREATE PROCEDURE LISTAR_CLIENTES_MAYORISTAS_POR_NOMBRE_DNI(
	IN _nombre_DNI varchar(1000)
)
BEGIN
	SELECT c.id_cliente_mayorista, p.nombre, p.apellidos, p.DNI, p.correo, p.telefono, c.RUC, c.razon_social
	from clienteMayorista c
	inner join persona p on p.id_persona = c.id_cliente_mayorista
	where p.activo = 1 and
    (CONCAT(p.nombre,' ',p.apellidos) LIKE CONCAT('%',_nombre_DNI,'%')) OR (p.DNI LIKE CONCAT('%',_nombre_DNI,'%'));
END $


CREATE PROCEDURE ACTUALIZAR_CLIENTE_MAYORISTA(
	IN _id_cliente_mayorista INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _RUC VARCHAR(50),
    IN _razon_social VARCHAR(50)
)
BEGIN

	UPDATE persona
    SET
    nombre = _nombre, apellidos = _apellidos, DNI = _DNI, correo = _correo, telefono = _telefono
    where id_persona = _id_cliente_mayorista;

	UPDATE clienteMayorista
    SET
    RUC = _RUC, razon_social = _razon_social
    WHERE id_cliente_mayorista = _id_cliente_mayorista;
END $


CREATE PROCEDURE ELIMNAR_CLIENTE_MAYORISTA(
	IN _id_cliente_mayorista INT
)
BEGIN
	UPDATE persona
    SET activo = false
    where id_persona = _id_cliente_mayorista;
END $





