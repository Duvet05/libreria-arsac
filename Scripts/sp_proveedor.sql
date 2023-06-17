-- PROVEEDOR
DROP PROCEDURE IF EXISTS INSERTAR_PROVEEDOR;
DROP PROCEDURE IF EXISTS LISTAR_PROVEEDORES_POR_NOMBRE;
DROP PROCEDURE IF EXISTS ACTUALIZAR_PROVEEDOR;
DROP PROCEDURE IF EXISTS ELIMINAR_PROVEEDOR;

DELIMITER $
CREATE PROCEDURE INSERTAR_PROVEEDOR(
	OUT _id_proveedor INT,
    IN _nombre VARCHAR(100),
    IN _direccion VARCHAR(100),
    IN _telefono VARCHAR(100),
    IN _RUC VARCHAR(100)
)
BEGIN
	INSERT INTO proveedor(nombre, direccion, telefono, RUC, activo)
    VALUES(_nombre, _direccion, _telefono, _RUC, true);
	SET _id_proveedor = last_insert_id();
END $

CREATE PROCEDURE LISTAR_PROVEEDORES_POR_NOMBRE(
	IN _nombre VARCHAR(1000)
)
BEGIN
	SELECT id_proveedor, nombre, direccion, RUC, telefono
    from proveedor where nombre = _nombre and activo = 1;
END $

CREATE PROCEDURE ACTUALIZAR_PROVEEDOR(
	IN _id_proveedor INT,
	IN _nombre VARCHAR(100),
    IN _direccion VARCHAR(100),
    IN _telefono VARCHAR(100),
    IN _RUC VARCHAR(100)
)
BEGIN
	UPDATE proveedor set
    nombre = _nombre,
    direccion = _direccion,
    telefono = _telefono,
    RUC = _RUC
    where id_proveedor = _id_proveedor;
END $

CREATE PROCEDURE ELIMINAR_PROVEEDOR(
	IN _id_proveedor INT
)
BEGIN
	UPDATE proveedor set
	activo = false
    where id_proveedor = _id_proveedor;
END $

-- PRODUCTO X PROVEEDOR
