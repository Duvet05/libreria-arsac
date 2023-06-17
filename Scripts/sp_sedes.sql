DROP procedure IF exists INSERTAR_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_SEDES;
DROP PROCEDURE IF EXISTS ACTUALIZAR_SEDE;
DROP PROCEDURE IF EXISTS ELIMINAR_SEDE;

DELIMITER $
CREATE PROCEDURE INSERTAR_SEDE(
	OUT _id_sede INT,
    IN _es_principal BOOLEAN,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	INSERT INTO sede(es_principal, direccion, telefono, correo, activo)
    VALUES(_es_principal, _direccion, _telefono, _correo, true);
	SET _id_sede = last_insert_id();
END $
CREATE PROCEDURE LISTAR_SEDES()
BEGIN
	SELECT id_sede, es_principal, direccion, telefono, correo from sede WHERE activo = true;
END $
CREATE PROCEDURE ACTUALIZAR_SEDE(
	IN _id_sede INT,
    IN _es_principal BOOLEAN,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	UPDATE sede set
    es_principal = _es_principal,
    direccion = _direccion,
    telefono = _telefono,
	correo = _correo
    WHERE idSede = _id_sede;
END $
CREATE PROCEDURE ELIMINAR_SEDE(
	IN _id_sede INT
)
BEGIN
	UPDATE sede set
	activo = false
    WHERE id_sede = _id_sede;
END $