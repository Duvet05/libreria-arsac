DROP procedure IF exists INSERTAR_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_SEDES;
DROP PROCEDURE IF EXISTS ACTUALIZAR_SEDE;
DROP PROCEDURE IF EXISTS ELIMINAR_SEDE;

DROP PROCEDURE IF EXISTS INSERTAR_PRODUCTO_EN_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_DE_SEDE;
DROP PROCEDURE IF EXISTS ELIMINAR_PRODUCTO_DE_SEDE;
DROP PROCEDURE IF EXISTS ELIMINAR_PRODUCTOS_DE_SEDE;

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_ABASTECIMIENTO ;
DROP PROCEDURE IF EXISTS ACTUALIZAR_ORDEN_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS ELIMINAR_ORDEN_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS LISTAR_ABASTECIMIENTO_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO;
DROP PROCEDURE IF EXISTS INSERTAR_LINEA_ORDEN_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS LISTAR_LINEAS_ORDEN_ABASTECIMIENTO_X_ID_ORDEN_ABASTECIMIENTO;

-- SEDE

DELIMITER $
CREATE PROCEDURE INSERTAR_SEDE(
	OUT _id_sede INT,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	INSERT INTO sede(es_principal, direccion, telefono, correo, activo)
    VALUES(false, _direccion, _telefono, _correo, true);
	SET _id_sede = @@last_insert_id;
END $
CREATE PROCEDURE LISTAR_SEDES()
BEGIN
	SELECT id_sede, es_principal, direccion, telefono, correo from sede WHERE activo = true;
END $
CREATE PROCEDURE ACTUALIZAR_SEDE(
	IN _id_sede INT,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	UPDATE sede set
    direccion = _direccion,
    telefono = _telefono,
	correo = _correo
    WHERE id_sede = _id_sede;
END $
CREATE PROCEDURE ELIMINAR_SEDE(
	IN _id_sede INT
)
BEGIN
	UPDATE sede set
	activo = false
    WHERE id_sede = _id_sede;
END $

-- SEDE X PRODUCTO

CREATE PROCEDURE INSERTAR_PRODUCTO_EN_SEDE(
	IN _id_sede INT,
    IN _id_producto INT
)
BEGIN
	INSERT INTO sedeXproducto(fid_sede, fid_producto, stock, activo)
    VALUES(_id_sede, _id_producto, 0, true);
END $

-- #######################################################################
-- lISTAR PRODUCTOS POR SEDES
-- #######################################################################


DELIMITER $
CREATE DEFINER=`admin`@`%` PROCEDURE `LISTAR_PRODUCTOS_DE_SEDE`(
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



CREATE PROCEDURE ELIMINAR_PRODUCTO_DE_SEDE(
	IN _id_sede INT,
    IN _id_producto INT
)
BEGIN
	UPDATE sedeXproducto SET
    activo = false
    where fid_sede = _id_sede and fid_producto = _id_producto;
END $

CREATE PROCEDURE ELIMINAR_PRODUCTOS_DE_SEDE(
	IN _id_sede INT
)
BEGIN
	UPDATE sedeXproducto SET
    activo = false
    where fid_sede = _id_sede;
END $


-- ORDEN DE ABASTECIMIENTO

CREATE PROCEDURE INSERTAR_ORDEN_ABASTECIMIENTO(
  OUT _id_orden_de_abastecimiento INT,
  IN _fid_empleado INT,
  IN _fid_sede INT,
  IN _fecha_orden DATE
)
BEGIN
  INSERT INTO ordenDeAbastecimiento(fid_empleado, fid_sede, fecha_orden)
  VALUES (_fid_empleado, _fid_sede, _fecha_orden);
  SET _id_orden_de_abastecimiento = @@last_insert_id;
END $	

CREATE PROCEDURE ACTUALIZAR_ORDEN_ABASTECIMIENTO(
  IN _id_orden_de_abastecimiento INT,
  IN _fid_empleado INT,
  IN _fid_sede INT,
  IN _fecha_orden DATE
)
BEGIN
  UPDATE ordenDeAbastecimiento
  SET fid_empleado = _fid_empleado,fid_sede = _fid_sede,fecha_orden = _fecha_orden 
  WHERE id_orden_de_abastecimiento = _id_orden_de_abastecimiento;
END $

DELIMITER $
CREATE PROCEDURE ELIMINAR_ORDEN_ABASTECIMIENTO(
	IN _id_orden_de_abastecimiento INT
)
BEGIN
	UPDATE ordenDeAbastecimiento SET activo = 0 where id_orden_de_abastecimiento = _id_orden_de_abastecimiento;
END$

DELIMITER $
CREATE PROCEDURE LISTAR_ABASTECIMIENTO_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO(
    IN _id_nombre_dni_empleado VARCHAR(140)
)
BEGIN
    SELECT oa.id_orden_de_abastecimiento,oa.fecha_orden, e.fid_empleado, p.id_persona,p.nombre,p.apellidos,p.DNI
    FROM ordenDeAbastecimiento oa
    INNER JOIN empleado e ON oa.fid_empleado = e.fid_empleado
    INNER JOIN persona p ON e.fid_empleado = p.id_persona
    WHERE
        oa.activo = 1
        AND ((CONCAT(p.nombre, ' ', p.apellidos) LIKE CONCAT('%', _id_nombre_dni_empleado, '%'))
		OR (CONVERT(oa.id_orden_de_abastecimiento, CHAR(140)) LIKE CONCAT('%', _id_nombre_dni_empleado, '%'))
		OR (p.DNI LIKE CONCAT('%', _id_nombre_dni_empleado, '%')));
END$

CREATE PROCEDURE INSERTAR_LINEA_ORDEN_ABASTECIMIENTO(
	OUT _id_linea_abastecimiento INT,
    IN _fid_orden_de_abastecimiento INT,
    IN _fid_producto INT,
    IN _cantidad INT
)
BEGIN
	INSERT INTO lineaOrdenDeAbastecimiento(fid_orden_venta,fid_producto,cantidad) 
	VALUES(_fid_orden_de_abastecimiento,_fid_producto,_cantidad);
    SET _id_linea_abastecimiento = @@last_insert_id;
END$

CREATE PROCEDURE LISTAR_LINEAS_ORDEN_ABASTECIMIENTO_X_ID_ORDEN_ABASTECIMIENTO(
	IN _id_orden_de_abastecimiento INT
)
BEGIN
	SELECT loa.id_linea_orden_abastecimiento, p.id_producto, p.nombre, p.precio_por_menor, p.precio_por_mayor, loa.cantidad 
	FROM lineaOrdenDeAbastecimiento loa 
	INNER JOIN producto p ON loa.fid_producto = p.id_producto 
	WHERE loa.fid_orden_de_abastecimiento = _id_orden_de_abastecimiento AND loa.activo = 1;	
END$
