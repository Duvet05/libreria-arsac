-- MARCA

DROP PROCEDURE IF EXISTS INSERTAR_MARCA;

-- CATEGORIA

DROP procedure IF exists INSERTAR_CATEGORIA;

-- PRODUCTO

DROP procedure IF exists INSERTAR_PRODUCTO;

DROP procedure IF exists LISTAR_PRODUCTOS;

-- TIPO DE EMPLEADO

DROP procedure IF exists INSERTAR_TIPO_EMPLEADO;

-- SEDE

DROP procedure IF exists INSERTAR_SEDE;

DROP PROCEDURE IF EXISTS LISTAR_SEDES;

DROP PROCEDURE IF EXISTS ACTUALIZAR_SEDE;

DROP PROCEDURE IF EXISTS ELIMINAR_SEDE;

-- EMPLEADO

DROP PROCEDURE IF EXISTS INSERTAR_EMPLEADO;

-- CLIENTE MAYORISTA

DROP PROCEDURE IF EXISTS INSERTAR_CLIENTE_MAYORISTA;

DROP PROCEDURE IF EXISTS LISTAR_CLIENTES_MAYORISTAS;

-- SEDE X PRODUCTO

DROP PROCEDURE IF EXISTS INSERTAR_SEDE_X_PRODUCTO;

DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS_X_SEDE;

-- ORDEN DE VENTA

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA;

-- LINEA DE ORDEN DE VENTA

DROP PROCEDURE IF EXISTS INSERTAR_LINEA_DE_ORDEN_DE_VENTA;

DROP PROCEDURE IF EXISTS LISTAR_LINEAS_DE_ORDEN_DE_VENTA;

-- PROVEEDOR

DROP PROCEDURE IF EXISTS INSERTAR_PROVEEDOR;

DROP PROCEDURE IF EXISTS LISTAR_PROVEEDORES;

DROP PROCEDURE IF EXISTS ACTUALIZAR_PROVEEDOR;

DROP PROCEDURE IF EXISTS ELIMINAR_PROVEEDOR;

DELIMITER $

-- MARCA

CREATE PROCEDURE INSERTAR_MARCA(OUT _ID_MARCA INT, 
IN _DESCRIPCION VARCHAR(50)) BEGIN 
	INSERT INTO marca(descripcion, activo) VALUES (_descripcion, true);
	SET _id_marca = LAST_INSERT_ID();
	END 
$ 

-- CATEGORIA

CREATE PROCEDURE INSERTAR_CATEGORIA(OUT _ID_CATEGORIA 
INT, IN _DESCRIPCION VARCHAR(50)) BEGIN 
	INSERT INTO
	    categoria(descripcion, activo)
	VALUES (_descripcion, true);
	SET _id_categoria = LAST_INSERT_ID();
	END 
$ 

-- PRODUCTO

CREATE PROCEDURE INSERTAR_PRODUCTO(OUT _ID_PRODUCTO 
INT, IN _FID_CATEGORIA INT, IN _FID_MARCA INT, IN 
_NOMBRE VARCHAR(50), IN _PRECIO DECIMAL(10, 2), IN 
_PRECIO_POR_MAYOR DECIMAL(10, 2), IN _FOTO LONGBLOB
) BEGIN 
	INSERT INTO
	    producto(
	        fid_categoria,
	        fid_marca,
	        nombre,
	        precio,
	        precio_por_mayor,
	        foto,
	        activo
	    )
	VALUES (
	        _fid_categoria,
	        _fid_marca,
	        _nombre,
	        _precio,
	        _precio_por_mayor,
	        _foto,
	        true
	    );
	SET _id_producto = LAST_INSERT_ID();
	END 
$ 

CREATE PROCEDURE LISTAR_PRODUCTOS() BEGIN 
	SELECT
	    c.descripcion AS categoria,
	    m.descripcion AS marca,
	    p.nombre,
	    p.precio,
	    p.precio_por_mayor
	FROM producto p
	    INNER JOIN categoria c ON p.fid_categoria = c.id_categoria
	    INNER JOIN marca m ON p.fid_marca = m.id_marca
	WHERE p.activo = 1;
	END 
$ 

-- TIPO DE EMPLEADO

CREATE PROCEDURE INSERTAR_TIPO_EMPLEADO(OUT _ID_TIPO_EMPLEADO 
INT, IN _DESCRIPCION VARCHAR(50)) BEGIN 
	INSERT INTO
	    tipoEmpleado(descripcion, activo)
	VALUES (_descripcion, true);
	SET _id_tipo_empleado = LAST_INSERT_ID();
	END 
$ 

-- SEDE

CREATE PROCEDURE INSERTAR_SEDE(OUT _ID_SEDE INT, IN 
_ES_PRINCIPAL BOOLEAN, IN _DIRECCION VARCHAR(50), 
IN _TELEFONO VARCHAR(50), IN _CORREO VARCHAR(50)) 
BEGIN 
	INSERT INTO
	    sede(
	        es_principal,
	        direccion,
	        telefono,
	        correo,
	        activo
	    )
	VALUES (
	        _es_principal,
	        _direccion,
	        _telefono,
	        _correo,
	        true
	    );
	SET _id_sede = LAST_INSERT_ID();
	END 
$ 

CREATE PROCEDURE LISTAR_SEDES() BEGIN 
	SELECT
	    id_sede,
	    es_principal,
	    direccion,
	    telefono,
	    correo
	FROM sede
	WHERE activo = true;
	END 
$ 

CREATE PROCEDURE ACTUALIZAR_SEDE(IN _ID_SEDE INT, IN 
_ES_PRINCIPAL BOOLEAN, IN _DIRECCION VARCHAR(100), 
IN _TELEFONO VARCHAR(100), IN _CORREO VARCHAR(100)
) BEGIN 
	UPDATE sede
	SET
	    es_principal = _es_principal,
	    direccion = _direccion,
	    telefono = _telefono,
	    correo = _correo
	WHERE id_sede = _id_sede;
	END 
$ 

CREATE PROCEDURE ELIMINAR_SEDE(IN _ID_SEDE INT) BEGIN 
	UPDATE sede SET activo = false WHERE id_sede = _id_sede;
	END 
$ 

-- EMPLEADO

CREATE PROCEDURE INSERTAR_EMPLEADO(OUT _fid_empleado 
INT, IN _DNI CHAR(8), IN _NOMBRE VARCHAR(100), IN 
_APELLIDOS VARCHAR(100), IN _CORREO VARCHAR(50), IN 
_TELEFONO VARCHAR(20), IN _ID_TIPO_EMPLEADO INT, IN 
_FECHA_CONTRATACION DATE, IN _SALARIO DECIMAL(10, 
2), IN _DIRECCION VARCHAR(100), IN _USUARIO VARCHAR
(50), IN _CONTRASENA VARBINARY(255), IN _ID_SEDE INT
) BEGIN 
	INSERT INTO
	    persona(
	        nombre,
	        apellidos,
	        DNI,
	        correo,
	        telefono,
	        activo
	    )
	VALUES (
	        _nombre,
	        _apellidos,
	        _DNI,
	        _correo,
	        _telefono,
	        true
	    );
	SET _fid_empleado = LAST_INSERT_ID();
	INSERT INTO
	    empleado(
	        ffid_empleado,
	        fid_tipo_empleado,
	        fid_sede,
	        fecha_contratacion,
	        salario,
	        direccion,
	        foto
	    )
	VALUES (
	        _fid_empleado,
	        _id_tipo_empleado,
	        _id_sede,
	        _fecha_contratacion,
	        _salario,
	        _direccion,
	        NULL
	    );
	INSERT INTO
	    cuentaUsuario(
	        ffid_empleado,
	        usuario,
	        contrasena,
	        activo
	    )
	VALUES (
	        _fid_empleado,
	        _usuario,
	        _contrasena,
	        true
	    );
	END 
$ 

-- CLIENTE MAYORISTA

CREATE PROCEDURE INSERTAR_CLIENTE_MAYORISTA(OUT _ID_CLIENTE_MAYORISTA 
INT, IN _DNI CHAR(8), IN _NOMBRE VARCHAR(100), IN 
_APELLIDOS VARCHAR(100), IN _CORREO VARCHAR(50), IN 
_TELEFONO VARCHAR(20), IN _RUC VARCHAR(50), IN _RAZON_SOCIAL 
VARCHAR(50)) BEGIN 
	INSERT INTO
	    persona(
	        nombre,
	        apellidos,
	        DNI,
	        correo,
	        telefono,
	        activo
	    )
	VALUES (
	        _nombre,
	        _apellidos,
	        _DNI,
	        _correo,
	        _telefono,
	        true
	    );
	SET _id_cliente_mayorista = LAST_INSERT_ID();
	INSERT INTO
	    clienteMayorista(
	        fid_cliente_mayorista,
	        RUC,
	        razon_social
	    )
	VALUES (
	        _id_cliente_mayorista,
	        _RUC,
	        _razon_social
	    );
	END 
$ 

CREATE PROCEDURE LISTAR_CLIENTES_MAYORISTAS() BEGIN 
	SELECT
	    p.nombre,
	    p.apellidos,
	    p.DNI,
	    p.correo,
	    p.telefono,
	    cm.RUC,
	    cm.razon_social
	FROM persona p
	    INNER JOIN clienteMayorista cm ON p.id_persona = cm.fid_cliente_mayorista
	WHERE p.activo = 1;
	END 
$ 

-- SEDE X PRODUCTO

CREATE PROCEDURE INSERTAR_SEDE_X_PRODUCTO(IN _ID_SEDE 
INT, IN _ID_PRODUCTO INT, IN _STOCK INT, IN _STOCKBASE 
INT, IN _STOCKMAXIMO INT) BEGIN 
	INSERT INTO
	    sedeXproducto(
	        fid_sede,
	        fid_producto,
	        stock,
	        stockBase,
	        stockMaximo,
	        activo
	    )
	VALUES (
	        _id_sede,
	        _id_producto,
	        _stock,
	        _stockBase,
	        _stockMaximo,
	        true
	    );
	END 
$ 

CREATE PROCEDURE LISTAR_PRODUCTOS_X_SEDE(IN _ID_SEDE 
INT) BEGIN 
	SELECT
	    p.nombre,
	    sp.stock,
	    sp.stockBase,
	    sp.stockMaximo
	FROM producto p
	    INNER JOIN sedeXproducto sp ON sp.fid_producto = p.id_producto
	WHERE
	    sp.fid_sede = _id_sede
	    AND sp.activo = 1;
	END 
$ 

-- ORDEN DE VENTA

CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA(OUT _ID_ORDEN_DE_VENTA 
INT, IN _fid_empleado INT, IN _PRECIOTOTAL DECIMAL(
10, 2)) BEGIN 
	INSERT INTO
	    ordenDeVenta(
	        ffid_empleado,
	        fecha_orden,
	        total,
	        activo
	    )
	VALUES (
	        _fid_empleado,
	        CURDATE(),
	        _precioTotal,
	        true
	    );
	SET _id_orden_de_venta = LAST_INSERT_ID();
	END 
$ 

-- LINEA DE ORDEN DE VENTA

CREATE PROCEDURE INSERTAR_LINEA_DE_ORDEN_DE_VENTA(IN 
_ID_ORDEN_DE_VENTA INT, IN _ID_PRODUCTO INT, IN _CANTIDAD 
INT, IN _DESCUENTO DECIMAL(10, 2), IN _PRECIO DECIMAL
(10, 2)) BEGIN 
	INSERT INTO
	    lineaOrdenDeVenta(
	        fid_orden_de_venta,
	        fid_producto,
	        cantidad,
	        descuento,
	        precio,
	        activo
	    )
	VALUES (
	        _id_orden_de_venta,
	        _id_producto,
	        _cantidad,
	        _descuento,
	        _precio,
	        true
	    );
	END 
$ 

CREATE PROCEDURE LISTAR_LINEAS_DE_ORDEN_DE_VENTA(IN 
_ID_ORDEN_DE_VENTA INT) BEGIN 
	SELECT
	    p.nombre,
	    p.precio,
	    p.precio_por_mayor,
	    lov.cantidad,
	    lov.descuento,
	    lov.precio AS subtotal
	FROM lineaOrdenDeVenta lov
	    INNER JOIN producto p ON p.id_producto = lov.fid_producto
	WHERE
	    lov.fid_orden_de_venta = _id_orden_de_venta;
	END 
$ 

-- PROVEEDOR

CREATE PROCEDURE INSERTAR_PROVEEDOR(OUT _ID_PROVEEDOR 
INT, IN _NOMBRE VARCHAR(100), IN _DIRECCION VARCHAR
(100), IN _TELEFONO VARCHAR(20), IN _RUC VARCHAR(50
)) BEGIN 
	INSERT INTO
	    proveedor(
	        nombre,
	        direccion,
	        telefono,
	        RUC,
	        activo
	    )
	VALUES (
	        _nombre,
	        _direccion,
	        _telefono,
	        _RUC,
	        true
	    );
	SET _id_proveedor = LAST_INSERT_ID();
	END 
$ 

CREATE PROCEDURE LISTAR_PROVEEDORES() BEGIN 
	SELECT
	    id_proveedor,
	    nombre,
	    direccion,
	    RUC,
	    telefono
	FROM proveedor
	WHERE activo = 1;
	END 
$ 

CREATE PROCEDURE ACTUALIZAR_PROVEEDOR(IN _ID_PROVEEDOR 
INT, IN _NOMBRE VARCHAR(100), IN _DIRECCION VARCHAR
(100), IN _TELEFONO VARCHAR(20), IN _RUC VARCHAR(50
)) BEGIN 
	UPDATE proveedor
	SET
	    nombre = _nombre,
	    direccion = _direccion,
	    telefono = _telefono,
	    RUC = _RUC
	WHERE
	    id_proveedor = _id_proveedor;
	END 
$ 

CREATE PROCEDURE ELIMINAR_PROVEEDOR(IN _ID_PROVEEDOR 
INT) BEGIN 
	UPDATE proveedor
	SET activo = false
	WHERE
	    id_proveedor = _id_proveedor;
	END 
$ 