-- #######################################################################
-- PROVEEDOR - INSERTAR
-- #######################################################################
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
END; $

-- #######################################################################
-- PROVEEDOR - LISTAR POR NOMBRE
-- #######################################################################
DELIMITER $
CREATE PROCEDURE ORDENAR_PROVEEDOR_ALFABETICAMENTE()
BEGIN
    SELECT * FROM proveedor
    ORDER BY nombre;
END;$

-- #######################################################################
-- PROVEEDOR - LISTAR POR categoria
-- #######################################################################
DELIMITER $
CREATE PROCEDURE ORDENAR_PROVEEDOR_CATEGORIA_PRODUCTO(
IN _id_categoria INT
)
BEGIN
    SELECT DISTINCT proveedor.*
    FROM proveedor
    JOIN productoXproveedor ON proveedor.id_proveedor = productoXproveedor.fid_proveedor
    JOIN producto ON productoXproveedor.fid_producto = producto.id_producto
    WHERE producto.fid_categoria = _id_categoria;
END;$
-- #######################################################################
-- PROVEEDOR - ACTUALIZAR/MODIFICAR
-- #######################################################################
DELIMITER $
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
END; $
-- #######################################################################
-- PROVEEDOR -ELIMINAR
-- #######################################################################
DELIMITER $
CREATE PROCEDURE ELIMINAR_PROVEEDOR(
	IN _id_proveedor INT
)
BEGIN
	UPDATE proveedor set
	activo = false
    where id_proveedor = _id_proveedor;
END; $

-- #######################################################################
-- INSERTAR PRODUCTO X PROVEEDOR
-- #######################################################################
DELIMITER $
CREATE PROCEDURE INSERTAR_PRODUCTO_DE_PROVEEDOR(
    IN _fid_producto INT,
    IN _fid_proveedor INT,
    IN _costo DECIMAL(10, 2)
)
BEGIN
    INSERT INTO productoXproveedor (fid_producto, fid_proveedor, costo)
    VALUES (_fid_producto, _fid_proveedor, _costo);
END;$
