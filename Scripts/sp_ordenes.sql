-- #######################################################################
-- ORDEN DE VENTA MAYORISTA- INSERTAR
-- #######################################################################
DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA_MAYORISTA;
DROP PROCEDURE IF EXISTS INSERTAR_LINEA_ORDEN_VENTA_MAYORISTA;

DROP PROCEDURE IF EXISTS ACTUALIZAR_ORDEN_DE_VENTA;
DROP PROCEDURE IF EXISTS ACTUALIZAR_LINEA_ORDEN_DE_VENTA;

DROP PROCEDURE IF EXISTS CANCELAR_VENTA_MAYORISTA;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_ORDEN_MAYORISTA;

DROP PROCEDURE IF EXISTS LISTAR_ORDEN_MAYORISTA_POR_FECHA;
DROP PROCEDURE IF EXISTS LISTAR_ORDEN_MAYORISTA_POR_CLIENTES;
DROP PROCEDURE IF EXISTS LISTAR_ORDEN_MAYORISTA_POR_VENDEDOR;

DELIMITER $
CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MAYORISTA(
  OUT _id_orden_de_venta INT,
  IN _fid_empleado INT,
  IN _fid_cliente_mayorista INT,
  IN _total DECIMAL(10, 2),
  IN _fecha_orden DATE,
  IN _activo BOOLEAN
)
BEGIN
  -- Insertar en la tabla de órdenes de venta
 INSERT INTO ordenDeVenta (fid_cliente_mayorista,fid_empleado, total, fecha_orden,activo)
  VALUES (_fid_cliente_mayorista,_fid_empleado, _total, _fecha_orden,_activo);
  
  -- Obtener el ID de la orden de venta insertada
  SET _id_orden_de_venta = LAST_INSERT_ID();
END;$




DELIMITER $
CREATE PROCEDURE INSERTAR_LINEA_ORDEN_VENTA_MAYORISTA(
  IN _fid_orden_de_venta INT,
  IN _fid_producto INT,
  IN _cantidad INT,
  IN _descuento DECIMAL(10, 2),
  IN _subtotal DECIMAL(10, 2)
)
BEGIN
  INSERT INTO lineaOrdenDeVenta (fid_orden_de_venta, fid_producto, cantidad, descuento, subtotal)
  VALUES (_fid_orden_de_venta, _fid_producto, _cantidad, _descuento, _subtotal);
END;$

-- #######################################################################
-- ORDEN DE VENTA MAYORISTA- MODIFICAR
-- #######################################################################

DELIMITER $
CREATE PROCEDURE ACTUALIZAR_ORDEN_DE_VENTA(
    IN _id_orden_de_venta INT,
    IN _fid_cliente_mayorista INT,
    IN _total DECIMAL(10, 2),
    IN _fecha_orden DATE
)
BEGIN
    -- Actualizar datos en la tabla ordenDeVenta
    UPDATE ordenDeVenta
    SET fid_cliente_mayorista = _fid_cliente_mayorista,
        total = _total,
        fecha_orden = _fecha_orden
    WHERE id_orden_de_venta = _id_orden_de_venta;
END;$


DELIMITER $
CREATE PROCEDURE ACTUALIZAR_LINEA_ORDEN_DE_VENTA (
    IN _fid_orden_de_venta INT,
    IN _fid_producto INT,
    IN _cantidad INT,
    IN _descuento DECIMAL(10, 2),
    IN _subtotal DECIMAL(10, 2),
    IN _activo BOOLEAN
)
BEGIN
    UPDATE lineaOrdenDeVenta
    SET cantidad = _cantidad,
        descuento = _descuento,
        subtotal = _subtotal,
        activo = _activo
    WHERE fid_orden_de_venta = _fid_orden_de_venta
        AND fid_producto = _fid_producto;
END;$

-- #######################################################################
-- ORDEN DE VENTA MAYORISTA- CANCELAR
-- #######################################################################
DELIMITER $
CREATE PROCEDURE CANCELAR_VENTA_MAYORISTA(
	IN _id_orden_de_venta INT
)
BEGIN
    UPDATE ordenDeVenta
    SET activo = false
    WHERE id_orden_de_venta = _id_orden_de_venta;
END;$

-- #######################################################################
-- lISTAR
-- #######################################################################
DELIMITER $
CREATE PROCEDURE LISTAR_PRODUCTOS_ORDEN_MAYORISTA (
IN _orden_venta_id INT
)
BEGIN
    SELECT fid_producto,cantidad,descuento,subtotal,activo as "estado" 
    FROM lineaOrdenDeVenta 
	WHERE fid_orden_de_venta = 1 AND activo = 1;
END;$
-- #######################################################################
-- lISTAR FECHA
-- #######################################################################
DELIMITER $
CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_FECHA()
BEGIN
    SELECT *
    FROM ordenDeVenta
    ORDER BY fecha_orden DESC;
END;$
-- #######################################################################
-- lISTAR CLIENTE
-- #######################################################################
DELIMITER $
CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_CLIENTES()
BEGIN
    SELECT *
    FROM ordenDeVenta
    ORDER BY fid_cliente_mayorista DESC;
END;$

-- #######################################################################
-- lISTAR CLIENTE
-- #######################################################################
DELIMITER $
CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_VENDEDOR(
IN _fid_empleado INT
)
BEGIN
    SELECT *
	FROM ordenDeVenta
	WHERE fid_empleado = _fid_empleado;
END;$

