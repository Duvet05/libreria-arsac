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

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA_MINORISTA;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_DE_SEDE_VENTAS;
DROP PROCEDURE IF EXISTS VERIFICAR_STOCK_SUFICIENTE;
DROP PROCEDURE IF EXISTS INSERTAR_LINEA_ORDEN_VENTA;

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
END$

-- #######################################################################
-- ORDEN DE VENTA MAYORISTA- MODIFICAR
-- #######################################################################

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
END$


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
END$

-- #######################################################################
-- ORDEN DE VENTA MAYORISTA- CANCELAR
-- #######################################################################

CREATE PROCEDURE CANCELAR_VENTA_MAYORISTA(
	IN _id_orden_de_venta INT
)
BEGIN
    UPDATE ordenDeVenta
    SET activo = false
    WHERE id_orden_de_venta = _id_orden_de_venta;
END$

-- #######################################################################
-- lISTAR
-- #######################################################################

CREATE PROCEDURE LISTAR_PRODUCTOS_ORDEN_MAYORISTA (
IN _orden_venta_id INT
)
BEGIN
    SELECT fid_producto,cantidad,descuento,subtotal,activo as "estado" 
    FROM lineaOrdenDeVenta 
	WHERE fid_orden_de_venta = 1 AND activo = 1;
END$
-- #######################################################################
-- lISTAR FECHA
-- #######################################################################

CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_FECHA()
BEGIN
    SELECT *
    FROM ordenDeVenta
    ORDER BY fecha_orden DESC;
END$
-- #######################################################################
-- lISTAR CLIENTE
-- #######################################################################

CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_CLIENTES()
BEGIN
    SELECT *
    FROM ordenDeVenta
    ORDER BY fid_cliente_mayorista DESC;
END$

-- #######################################################################
-- lISTAR CLIENTE
-- #######################################################################

CREATE PROCEDURE LISTAR_ORDEN_MAYORISTA_POR_VENDEDOR(
IN _fid_empleado INT
)
BEGIN
    SELECT *
	FROM ordenDeVenta
	WHERE fid_empleado = _fid_empleado;
END$

-- VENTA MINORISTA

CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MINORISTA(
  OUT _id_orden_de_venta INT,
  IN _fid_empleado INT,
  IN _total DECIMAL(10,2),
  IN _fecha_orden DATE,
  IN _estado VARCHAR(50)
)
BEGIN
  -- Insertar en la tabla de órdenes de venta
    INSERT INTO ordenDeVenta (fid_empleado, total, fecha_orden, estado)
    VALUES (_fid_empleado, _total, _fecha_orden, _estado);
  -- Obtener el ID de la orden de venta insertada
  SET _id_orden_de_venta = LAST_INSERT_ID();
END$

CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MAYORISTA(
  OUT _id_orden_de_venta INT,
  IN _fid_empleado INT,
  IN _fid_cliente_mayorista INT,
  IN _total DECIMAL(10,2),
  IN _fecha_orden DATE,
  IN _fecha_envio DATE,
  IN _estado VARCHAR(50)
)
BEGIN
  -- Insertar en la tabla de órdenes de venta
    INSERT INTO ordenDeVenta (fid_empleado, fid_cliente_mayorista, total, fecha_orden, fecha_envio, estado)
    VALUES (_fid_empleado, _fid_cliente_mayorista, _total, _fecha_orden, _fecha_envio, _estado);
  -- Obtener el ID de la orden de venta insertada
  SET _id_orden_de_venta = LAST_INSERT_ID();
END$

CREATE PROCEDURE LISTAR_PRODUCTOS_DE_SEDE_VENTAS(
    IN _nombre VARCHAR(100),
    IN _fid_categoria INT,
    IN _fid_marca INT,
    IN _fid_sede INT
)
BEGIN
   	if (_fid_categoria = -1 and _fid_marca = -1) then
        SELECT p.id_producto, p.nombre, c.id_categoria, c.descripcion AS nombre_categoria,
            m.id_marca, m.descripcion AS nombre_marca, sxp.stock,
            p.precio_por_mayor, p.precio
        FROM producto p
        INNER JOIN categoria c ON p.fid_categoria = c.id_categoria
        INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN sedeXproducto sxp ON sxp.fid_producto = p.id_producto
        INNER JOIN sede sed ON sed.id_sede = sxp.fid_sede
        WHERE sxp.activo = 1
            AND p.nombre LIKE CONCAT('%', _nombre, '%')
            AND _fid_sede = sed.id_sede;
    elseif (_fid_categoria = -1 and _fid_marca != -1) then
        SELECT p.id_producto, p.nombre, c.id_categoria, c.descripcion AS nombre_categoria,
            m.id_marca, m.descripcion AS nombre_marca, sxp.stock,
            p.precio_por_mayor, p.precio
        FROM producto p
        INNER JOIN categoria c ON p.fid_categoria = c.id_categoria
        INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN sedeXproducto sxp ON sxp.fid_producto = p.id_producto
        INNER JOIN sede sed ON sed.id_sede = sxp.fid_sede
        WHERE sxp.activo = 1
            AND p.nombre LIKE CONCAT('%', _nombre, '%')
            AND _fid_sede = sed.id_sede
            AND m.id_marca = _fid_marca;
      elseif (_fid_categoria != -1 and _fid_marca = -1) then
        SELECT p.id_producto, p.nombre, c.id_categoria, c.descripcion AS nombre_categoria,
            m.id_marca, m.descripcion AS nombre_marca, sxp.stock,
            p.precio_por_mayor, p.precio
        FROM producto p
        INNER JOIN categoria c ON p.fid_categoria = c.id_categoria
        INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN sedeXproducto sxp ON sxp.fid_producto = p.id_producto
        INNER JOIN sede sed ON sed.id_sede = sxp.fid_sede
        WHERE sxp.activo = 1
            AND p.nombre LIKE CONCAT('%', _nombre, '%')
            AND _fid_sede = sed.id_sede
            AND c.id_categoria = _fid_categoria;
    ELSE
        SELECT p.id_producto, p.nombre, c.id_categoria, c.descripcion AS nombre_categoria,
            m.id_marca, m.descripcion AS nombre_marca, sxp.stock,
            p.precio_por_mayor, p.precio
        FROM producto p
        INNER JOIN categoria c ON p.fid_categoria = c.id_categoria
        INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN sedeXproducto sxp ON sxp.fid_producto = p.id_producto
        INNER JOIN sede sed ON sed.id_sede = sxp.fid_sede
        WHERE sxp.activo = 1
            AND p.nombre LIKE CONCAT('%', _nombre, '%')
            AND _fid_sede = sed.id_sede
            AND m.id_marca = _fid_marca
            AND c.id_categoria = _fid_categoria;
    END IF;
END$


CREATE PROCEDURE VERIFICAR_STOCK_SUFICIENTE(
    IN _fid_sede INT,
    IN _fid_producto INT,
    IN _cantidad DOUBLE,
    OUT _stock_suficiente INT
)
BEGIN
    DECLARE _stock_disponible DOUBLE;

    -- Obtener el stock disponible del producto en la sede
    SELECT stock
    INTO _stock_disponible
    FROM sedeXproducto
    WHERE fid_sede = _fid_sede AND fid_producto = _fid_producto;

    -- Verificar si hay suficiente stock para atender el pedido
    IF _stock_disponible >= _cantidad THEN
        SET _stock_suficiente = 1; -- Hay suficiente stock
    ELSE
        SET _stock_suficiente = 0; -- No hay suficiente stock
    END IF;
END $

CREATE PROCEDURE INSERTAR_LINEA_ORDEN_VENTA(
  IN _fid_orden_de_venta INT,
  IN _fid_producto INT,
  IN _cantidad INT,
  IN _descuento DECIMAL(10, 2),
  IN _subtotal DECIMAL(10, 2)
)
BEGIN
  DECLARE _fid_empleado INT;
  
  INSERT INTO lineaOrdenDeVenta (fid_orden_de_venta, fid_producto, cantidad, descuento, subtotal)
  VALUES (_fid_orden_de_venta, _fid_producto, _cantidad, _descuento, _subtotal);
  
  SELECT fid_empleado into _fid_empleado from ordenDeVenta where id_orden_de_venta = _fid_orden_de_venta;
  
  -- Restar la cantidad vendida a la cantidad actual del producto en la sede
  UPDATE sedeXproducto
  SET stock = stock - _cantidad
  WHERE fid_producto = _fid_producto AND
  fid_sede = (SELECT e.fid_sede FROM empleado e WHERE e.fid_empleado = _fid_empleado);

END $
