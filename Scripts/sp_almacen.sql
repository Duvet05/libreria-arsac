DROP PROCEDURE IF EXISTS INSERTAR_PRODUCTO;
DROP PROCEDURE IF EXISTS ACTUALIZAR_PRODUCTO;
DROP PROCEDURE IF EXISTS ELIMINAR_PRODUCTO;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTO_POR_NOMBRE;
DROP PROCEDURE IF exists INSERTAR_ORDEN_COMPRA;
DROP PROCEDURE IF exists ACTUALIZAR_ORDEN_COMPRA;
DROP PROCEDURE IF exists ELIMINAR_ORDEN_COMPRA;
DROP PROCEDURE IF exists LISTAR_ORDENES_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO;
DROP PROCEDURE IF exists INSERTAR_LINEA_ORDEN_COMPRA;
DROP PROCEDURE IF exists LISTAR_LINEAS_ORDEN_COMPRA_X_ID_ORDEN_COMPRA;
DROP PROCEDURE IF exists LISTAR_CATEGORIA_TODAS;
DROP PROCEDURE IF exists LISTAR_MARCA_TODAS;

DELIMITER $
create procedure LISTAR_CATEGORIA_TODAS()
begin
	select id_categoria, descripcion
    from categoria
    where activo = 1;
end $

create procedure LISTAR_MARCA_TODAS()
begin
	select id_marca, descripcion
    from marca
    where activo = 1;
end $

CREATE PROCEDURE INSERTAR_PRODUCTO(
	OUT _id_producto INT,
    IN _fid_categoria INT,
    IN _fid_marca INT,
    IN _nombre VARCHAR(50),
    IN _precio DECIMAL(10, 2),
    IN _precio_por_mayor DECIMAL(10, 2),
    IN _foto LONGBLOB
)
BEGIN
    INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor, foto)
    VALUES (_fid_categoria, _fid_marca, _nombre, _precio, _precio_por_mayor, _foto);
END$
DELIMITER $

CREATE PROCEDURE ACTUALIZAR_PRODUCTO(
    IN _id_producto INT,
    IN _fid_categoria INT,
    IN _fid_marca INT,
    IN _nombre VARCHAR(50),
    IN _precio DECIMAL(10, 2),
    IN _precio_por_mayor DECIMAL(10, 2),
    IN _foto LONGBLOB
)
BEGIN
    UPDATE producto
    SET fid_categoria = _fid_categoria,fid_marca = _fid_marca,nombre = _nombre, precio = _precio,precio_por_mayor = _precio_por_mayor,foto = _foto
    WHERE id_producto = _id_producto;
END$

DELIMITER $
CREATE PROCEDURE ELIMINAR_PRODUCTO(
	IN _id_producto INT
)
BEGIN
	UPDATE producto SET activo = 0 where id_producto = _id_producto;
END$

DELIMITER $
CREATE PROCEDURE LISTAR_PRODUCTO_POR_NOMBRE(
	IN _nombre VARCHAR(100)
)
BEGIN
	SELECT p.id_producto,p.nombre ,c.id_categoria, c.descripcion AS nombre_categoria, m.id_marca , m.descripcion AS nombre_marca,
	p.precio_por_mayor,p.precio_por_menor
	FROM producto p
	INNER JOIN categoria c ON p.fid_categoria = c.id_categoria 
	INNER JOIN marca m ON p.fid_marca = m.id_marca
	WHERE p.activo = 1 AND 
    nombre LIKE CONCAT('%',_nombre,'%');
END$
-- ORDEN DE COMPRA
DELIMITER $
CREATE PROCEDURE INSERTAR_ORDEN_COMPRA(
	OUT _id_orden_de_compra INT,
    IN _fid_empleado INT,
    IN _fid_proveedor INT,
    IN _fecha_orden DATE,
    IN _total DECIMAL(10, 2)
)
BEGIN
    INSERT INTO ordenDeCompra (fid_empleado, fid_proveedor, fecha_orden, total)
    VALUES (_fid_empleado, _fid_proveedor, _fecha_orden, _total);
	SET _id_orden_de_compra = @@last_insert_id;
END$
DELIMITER $

CREATE PROCEDURE ACTUALIZAR_ORDEN_COMPRA(
    IN _id_orden_de_compra INT,
    IN _fid_empleado INT,
    IN _fid_proveedor INT,
    IN _fecha_orden DATE,
    IN _total DECIMAL(10, 2)
)
BEGIN
    UPDATE ordenDeCompra
    SET fid_empleado = _fid_empleado,fid_proveedor = _fid_proveedor,
        fecha_orden = _fecha_orden,total = _total
    WHERE id_orden_de_compra = _id_orden_de_compra;
END$

DELIMITER $
CREATE PROCEDURE ELIMINAR_ORDEN_COMPRA(
	IN _id_orden_de_compra INT
)
BEGIN
	UPDATE ordenDeCompra SET activo = 0 where id_orden_de_compra = _id_orden_de_compra;
END$


DELIMITER $
CREATE PROCEDURE LISTAR_ORDENES_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO(
    IN _id_nombre_dni_empleado VARCHAR(140)
)
BEGIN
    SELECT oc.id_orden_de_compra,oc.fecha_orden,oc.total, e.fid_empleado, p.id_persona,p.nombre,p.apellidos,p.DNI
    FROM ordenDeCompra oc
    INNER JOIN empleado e ON oc.fid_empleado = e.fid_empleado
    INNER JOIN persona p ON e.fid_empleado = p.id_persona
    WHERE
        oc.activo = 1
        AND ((CONCAT(p.nombre, ' ', p.apellidos) LIKE CONCAT('%', _id_nombre_dni_empleado, '%'))
		OR (CONVERT(oc.id_orden_de_compra, CHAR(140)) LIKE CONCAT('%', _id_nombre_dni_empleado, '%'))
		OR (p.DNI LIKE CONCAT('%', _id_nombre_dni_empleado, '%')));
END$






-- LINEA ORDEN DE COMPRA 

DELIMITER $
CREATE PROCEDURE INSERTAR_LINEA_ORDEN_COMPRA(
	OUT _id_linea_orden_compra INT,
	IN _fid_orden_de_compra INT,
	IN _fid_producto INT,
	IN _cantidad INT,
	IN _subtotal DECIMAL(10, 2)
)
BEGIN
  INSERT INTO lineaOrdenDeCompra (fid_orden_de_compra, fid_producto, cantidad,subtotal)
  VALUES (_fid_orden_de_compra,_fid_producto,_cantidad,_subtotal);
  SET _id_linea_orden_compra = @@last_insert_id;
END$


DELIMITER $
CREATE PROCEDURE LISTAR_LINEAS_ORDEN_COMPRA_X_ID_ORDEN_COMPRA(
	IN _id_orden_de_compra INT
)
BEGIN
	SELECT loc.id_linea_orden_compra, p.id_producto, p.nombre, p.precio_por_menor, p.precio_por_mayor , loc.cantidad, loc.subtotal
	FROM lineaOrdenDeCompra loc 
	INNER JOIN producto p ON loc.fid_producto = p.id_producto 
	WHERE loc.fid_orden_de_compra = _id_orden_de_compra AND loc.activo = 1;
END$



