DROP procedure IF exists INSERTAR_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_SEDES;
DROP PROCEDURE IF EXISTS ACTUALIZAR_SEDE;
DROP PROCEDURE IF EXISTS ELIMINAR_SEDE;

DROP PROCEDURE IF EXISTS INSERTAR_PRODUCTO_EN_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_DE_SEDE;
DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_DE_SEDE_POR_NOMBRE_MARCA_CATEGORIA;
DROP PROCEDURE IF EXISTS ELIMINAR_PRODUCTOS_DE_SEDE;

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS ENTREGAR_ORDEN_DE_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS CANCELAR_ORDEN_DE_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS LISTAR_ORDENES_DE_ABASTECIMIENTO_DE_EMPLEADO;

DROP PROCEDURE IF EXISTS INSERTAR_LINEA_DE_ORDEN_DE_ABASTECIMIENTO;
DROP PROCEDURE IF EXISTS LISTAR_LINEAS_DE_ORDEN_DE_ABASTECIMIENTO;

DROP PROCEDURE IF EXISTS OBTENER_STOCK_DE_PRODUCTO_EN_SEDE_PRINCIPAL;
DROP PROCEDURE IF EXISTS OBTENER_STOCK_DE_PRODUCTO_EN_SEDE;
DROP PROCEDURE IF EXISTS ACTUALIZAR_STOCK_DE_PRODUCTO;

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

CREATE PROCEDURE LISTAR_PRODUCTOS_DE_SEDE(
	IN _id_sede INT
)
BEGIN
	SELECT
		p.id_producto,
        p.nombre,
		c.descripcion as categoria,
        m.descripcion as marca,
        sxp.stock
	FROM
		producto p
	INNER JOIN
		categoria c
			ON
            c.id_categoria = p.fid_categoria
	INNER JOIN
		marca m
			ON
            p.fid_marca = m.id_marca
	INNER JOIN
		sedeXproducto sxp
			ON
            sxp.fid_sede = _id_sede and sxp.fid_producto = p.id_producto and sxp.activo = 1;
END $

CREATE PROCEDURE LISTAR_PRODUCTOS_DE_SEDE_POR_NOMBRE_MARCA_CATEGORIA(
	IN _id_sede INT,
    IN _nombre VARCHAR(255),
    IN _id_categoria INT,
    IN _id_marca INT
)
BEGIN
	SELECT
		p.id_producto,
        p.nombre,
		c.descripcion as categoria,
        m.descripcion as marca,
        sxp.stock
	FROM
		producto p
	INNER JOIN
		categoria c
			ON
            c.id_categoria = p.fid_categoria and (c.id_categoria = _id_categoria or _id_categoria = -1)
	INNER JOIN
		marca m
			ON
            p.fid_marca = m.id_marca and (m.id_marca = _id_marca or _id_marca = -1)
	INNER JOIN
		sedeXproducto sxp
			ON
            sxp.fid_sede = _id_sede and sxp.fid_producto = p.id_producto and sxp.activo = 1
	WHERE p.nombre LIKE CONCAT('%',_nombre,'%');
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

CREATE PROCEDURE INSERTAR_ORDEN_DE_ABASTECIMIENTO(
  OUT _id_orden_de_abastecimiento INT,
  IN _fid_empleado INT,
  IN _fid_sede INT
)
BEGIN
  INSERT INTO
  ordenDeAbastecimiento
  (fid_empleado, fid_sede, fecha_registro, fecha_entrega, fecha_cancelacion, estado, activo)
  VALUES
  (_fid_empleado, _fid_sede, localtime(), NULL, NULL, 'Pendiente', 1);
  SET _id_orden_de_abastecimiento = @@last_insert_id;
END $	

CREATE PROCEDURE ENTREGAR_ORDEN_DE_ABASTECIMIENTO(
  IN _id_orden_de_abastecimiento INT
)
BEGIN
    UPDATE ordenDeAbastecimiento
	SET fecha_entrega = localtime(), estado = 'Entregado'
	WHERE id_orden_de_abastecimiento = _id_orden_de_abastecimiento;
END $

CREATE PROCEDURE CANCELAR_ORDEN_DE_ABASTECIMIENTO(
	IN _id_orden_de_abastecimiento INT
)
BEGIN
	UPDATE ordenDeAbastecimiento
	SET fecha_cancelacion = localtime(), estado = 'Cancelado'
	WHERE id_orden_de_abastecimiento = _id_orden_de_abastecimiento;
END$

CREATE PROCEDURE LISTAR_ORDENES_DE_ABASTECIMIENTO_DE_EMPLEADO(
	IN _id_empleado INT,
    IN _estado VARCHAR(255)
)
BEGIN
	SELECT
		oa.id_orden_de_abastecimiento,
        s.id_sede,
        s.direccion,
		oa.fecha_registro,
        oa.fecha_entrega,
        oa.fecha_cancelacion,
        oa.estado
	FROM
		ordenDeAbastecimiento oa
	INNER JOIN
		sede s ON s.id_sede = oa.fid_sede
	WHERE
		oa.fid_empleado = _id_empleado and oa.estado LIKE CONCAT('%',_estado,'%');
END $

CREATE PROCEDURE INSERTAR_LINEA_DE_ORDEN_DE_ABASTECIMIENTO(
	OUT _id_linea_orden_abastecimiento INT,
    IN _fid_orden_de_abastecimiento INT,
    IN _fid_producto INT,
    IN _cantidad INT
)
BEGIN
	INSERT INTO lineaOrdenDeAbastecimiento(fid_orden_de_abastecimiento,fid_producto,cantidad) 
	VALUES(_fid_orden_de_abastecimiento,_fid_producto,_cantidad);
    SET _id_linea_orden_abastecimiento = @@last_insert_id;
END$

CREATE PROCEDURE LISTAR_LINEAS_DE_ORDEN_DE_ABASTECIMIENTO(
	IN _id_orden_de_abastecimiento INT
)
BEGIN
	SELECT
		loa.id_linea_orden_abastecimiento,
		p.id_producto,
        p.nombre,
		c.descripcion as categoria,
        m.descripcion as marca,
        loa.cantidad 
	FROM
		producto p 
	INNER JOIN
		lineaOrdenDeAbastecimiento loa
			ON
			loa.fid_producto = p.id_producto and
            loa.fid_orden_de_abastecimiento = _id_orden_de_abastecimiento
	INNER JOIN
		categoria c
			ON
            c.id_categoria = p.fid_categoria
	INNER JOIN
		marca m
			ON
            p.fid_marca = m.id_marca;
END$

CREATE PROCEDURE OBTENER_STOCK_DE_PRODUCTO_EN_SEDE_PRINCIPAL(
	IN _id_producto INT
)
BEGIN
	SELECT
		sxp.stock
	FROM
		sedeXproducto sxp
	INNER JOIN
		sede s ON s.id_sede = sxp.fid_sede and s.es_principal = 1
	WHERE sxp.fid_producto = _id_producto and sxp.activo = 1;
END $

CREATE PROCEDURE OBTENER_STOCK_DE_PRODUCTO_EN_SEDE(
	IN _id_producto INT,
    IN _id_sede INT
)
BEGIN
	SELECT
		sxp.stock
	FROM
		sedeXproducto sxp
	WHERE sxp.fid_sede = _id_sede and sxp.fid_producto = _id_producto and sxp.activo = 1;
END $

CREATE PROCEDURE ACTUALIZAR_STOCK_DE_PRODUCTO(
	IN _id_producto INT,
    IN _id_sede INT,
    IN _cantidad INT
)
BEGIN
	UPDATE sedeXproducto
    SET stock = stock - _cantidad
    WHERE 	fid_producto = _id_producto and
			fid_sede = (SELECT s.id_sede from sede s where s.es_principal = 1) and
            activo = 1;

	UPDATE sedeXproducto
    SET stock = stock + _cantidad
    WHERE 	fid_producto = _id_producto and
			fid_sede = _id_sede and
            activo = 1;
END $