-- PROVEEDOR
DROP PROCEDURE IF EXISTS INSERTAR_PROVEEDOR;
DROP PROCEDURE IF EXISTS LISTAR_PROVEEDORES_POR_NOMBRE_RUC;

DROP PROCEDURE IF EXISTS ACTUALIZAR_PROVEEDOR;
DROP PROCEDURE IF EXISTS ELIMINAR_PROVEEDOR;

DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_POR_PROVEEDOR;

DROP PROCEDURE IF EXISTS LISTAR_TODAS_ORDENES_COMPRA_X_PROVEEDOR;

DELIMITER $
CREATE PROCEDURE LISTAR_TODAS_ORDENES_COMPRA_X_PROVEEDOR(
    IN _fid_proveedor int
)
BEGIN
	select c.id_orden_de_compra, c.fecha_orden, fid_proveedor,p.nombre, c.total, c.estado, c.activo AS 'Vigente'
		from ordenDeCompra c
			inner join proveedor p on p.id_proveedor = c.fid_proveedor
		where p.id_proveedor = _fid_proveedor;
END $

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
	SET _id_proveedor = @@last_insert_id;
END $

delimiter $
CREATE PROCEDURE LISTAR_PROVEEDORES_POR_NOMBRE_RUC(
	IN _nombre VARCHAR(1000)
)
BEGIN
	SELECT id_proveedor, nombre, direccion, RUC, telefono
    from proveedor
    where (nombre LIKE CONCAT('%',_nombre,'%') or RUC LIKE CONCAT('%',_nombre,'%'))and activo = 1;
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
delimiter $
CREATE PROCEDURE LISTAR_PRODUCTOS_POR_PROVEEDOR(
	IN _nombre VARCHAR(100),
    IN _fid_categoria int,
    IN _fid_marca int,
    IN _fid_proveedor int
)
BEGIN
	if (_fid_categoria = -1 and _fid_marca = -1) then
		
		SELECT p.id_producto,p.nombre ,c.id_categoria, c.descripcion AS nombre_categoria, 
			m.id_marca , m.descripcion AS nombre_marca, pxp.costo,
			p.precio_por_mayor,p.precio, p.foto
		FROM producto p
		INNER JOIN categoria c ON p.fid_categoria = c.id_categoria 
		INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN productoXproveedor pxp ON pxp.fid_producto = p.id_producto
        INNER JOIN proveedor prov ON prov.id_proveedor = pxp.fid_proveedor
		WHERE pxp.activo = 1 AND 
		p.nombre LIKE CONCAT('%',_nombre,'%') and _fid_proveedor = prov.id_proveedor;
	elseif (_fid_categoria = -1 and _fid_marca != -1) then
		SELECT p.id_producto,p.nombre ,c.id_categoria, c.descripcion AS nombre_categoria, 
			m.id_marca , m.descripcion AS nombre_marca, pxp.costo,
			p.precio_por_mayor,p.precio, p.foto
		FROM producto p
		INNER JOIN categoria c ON p.fid_categoria = c.id_categoria 
		INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN productoXproveedor pxp ON pxp.fid_producto = p.id_producto
        INNER JOIN proveedor prov ON prov.id_proveedor = pxp.fid_proveedor
		WHERE pxp.activo = 1 AND 
		p.nombre LIKE CONCAT('%',_nombre,'%') and _fid_proveedor = prov.id_proveedor and m.id_marca = _fid_marca;
		
    elseif (_fid_categoria != -1 and _fid_marca = -1) then
		SELECT p.id_producto,p.nombre ,c.id_categoria, c.descripcion AS nombre_categoria, 
			m.id_marca , m.descripcion AS nombre_marca, pxp.costo,
			p.precio_por_mayor,p.precio, p.foto
		FROM producto p
		INNER JOIN categoria c ON p.fid_categoria = c.id_categoria 
		INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN productoXproveedor pxp ON pxp.fid_producto = p.id_producto
        INNER JOIN proveedor prov ON prov.id_proveedor = pxp.fid_proveedor
		WHERE pxp.activo = 1 AND 
		p.nombre LIKE CONCAT('%',_nombre,'%') and _fid_proveedor = prov.id_proveedor and c.id_categoria= _fid_categoria;
    
    elseif (_fid_categoria != -1 and _fid_marca != -1) then
		SELECT p.id_producto,p.nombre ,c.id_categoria, c.descripcion AS nombre_categoria, 
			m.id_marca , m.descripcion AS nombre_marca, pxp.costo,
			p.precio_por_mayor,p.precio, p.foto
		FROM producto p
		INNER JOIN categoria c ON p.fid_categoria = c.id_categoria 
		INNER JOIN marca m ON p.fid_marca = m.id_marca
        INNER JOIN productoXproveedor pxp ON pxp.fid_producto = p.id_producto
        INNER JOIN proveedor prov ON prov.id_proveedor = pxp.fid_proveedor
		WHERE pxp.activo = 1 AND 
		p.nombre LIKE CONCAT('%',_nombre,'%') and _fid_proveedor = prov.id_proveedor and m.id_marca = _fid_marca and c.id_categoria = _fid_categoria;
    end if;
END $