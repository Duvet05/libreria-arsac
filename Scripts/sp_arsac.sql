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

-- ORDEN DE VENTA MAYORISTA
DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA_MAYORISTA;
DROP PROCEDURE IF EXISTS ACTUALIZAR_ORDEN_DE_VENTA_MAYORISTA;

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
CREATE PROCEDURE INSERTAR_MARCA(
	OUT _id_marca INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO marca(descripcion, activo)
    values(_descripcion, true);
	SET _id_marca = LAST_INSERT_ID();
END $

-- CATEGORIA
CREATE PROCEDURE INSERTAR_CATEGORIA(
	OUT _id_categoria INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO categoria(descripcion, activo) values(_descripcion, true);
	SET _id_categoria = LAST_INSERT_ID();
END $

-- PRODUCTO
CREATE PROCEDURE INSERTAR_PRODUCTO(
	OUT _id_producto int,
    IN _id_categoria INT,
    IN _id_marca INT,
    IN _nombre VARCHAR(50),
    IN _precio DECIMAL(10, 2),
    IN _precioPorMayor DECIMAL(10, 2)
)
BEGIN
    INSERT INTO producto(id_categoria, _id_marca, nombre, precio, precioPorMayor, activo)
    VALUES(_id_categoria, __id_marca, _nombre, _precio, _precioPorMayor, true);
    SET _id_producto = LAST_INSERT_ID();
END $


CREATE PROCEDURE LISTAR_PRODUCTOS()
BEGIN
    SELECT 	c.descripcion as categoria, m.descripcion as marca,
			p.nombre, p.precio, p.precioPorMayor
    FROM producto p
    INNER JOIN categoria c ON p.id_categoria = c.id_categoria
    INNER JOIN marca m ON p.id_marca = m.id_marca
    WHERE p.activo = 1;
END $

-- TIPO DE EMPLEADO
CREATE PROCEDURE INSERTAR_TIPO_EMPLEADO(
	OUT _id_tipo_empleado INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO tipoEmpleado(descripcion, activo)
    VALUES(_descripcion, true);
	SET _id_tipo_empleado = LAST_INSERT_ID();
END $

-- SEDE
CREATE PROCEDURE INSERTAR_SEDE(
	OUT _id_sede INT,
    IN _esAlmacen BOOLEAN,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	INSERT INTO sede(esAlmacen, direccion, telefono, correo, activo)
    VALUES(_esAlmacen, _direccion, _telefono, _correo, true);
	SET _id_sede = last_insert_id();
END $
CREATE PROCEDURE LISTAR_SEDES()
BEGIN
	SELECT id_sede, esAlmacen, direccion, telefono, correo from sede WHERE activo = true;
END $
CREATE PROCEDURE ACTUALIZAR_SEDE(
	IN _id_sede INT,
    IN _esAlmacen BOOLEAN,
	IN _direccion VARCHAR(100),
    IN _telefono VARCHAR(100),
    IN _correo VARCHAR(100)
)
BEGIN
	UPDATE sede set
    esAlmacen = _esAlmacen,
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


-- EMPLEADO
CREATE PROCEDURE INSERTAR_EMPLEADO(
    OUT _id_empleado INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _id_tipo_empleado INT,
    IN _fechaContratacion DATE,
    IN _salario DECIMAL(10,2),
    IN _direccion VARCHAR(100),
    IN _usuario VARCHAR(50),
    IN _contrasena VARCHAR(50),
    IN _id_sede INT
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo)
    VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, true);
    SET _id_empleado = LAST_INSERT_ID();
    INSERT INTO empleado(id_empleado,id_tipo_empleado,fechaContratacion,salario,direccion, contrasena,id_sede) 
            VALUES(_id_empleado,_id_tipo_empleado,_fechaContratacion,_salario,_direccion, _contrasena,_id_sede);
END $

-- CLIENTE MAYORISTA
CREATE PROCEDURE INSERTAR_CLIENTE_MAYORISTA(
	OUT _id_cliente_mayorista INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _RUC VARCHAR(50),
    IN _razonSocial VARCHAR(50)
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo)
    VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, true);
	SET _id_cliente_mayorista = last_insert_id();
    INSERT INTO clienteMayorista(RUC, razonSocial)
    VALUES(_RUC, _razonSocial);
END $

CREATE PROCEDURE LISTAR_CLIENTES_MAYORISTAS()
BEGIN
	SELECT 	p.nombre, p.apellidos, p.DNI, p.correo, p.telefono, c.RUC, c.razonSocial
			from persona p
            inner join clienteMayorista c on p.id_persona = c.id_cliente_mayorista
            where p.activo = 1;
END $

-- SEDE X PRODUCTO
CREATE PROCEDURE INSERTAR_SEDE_X_PRODUCTO(
	IN _id_sede INT,
    IN _id_producto INT,
    IN _stock INT,
    IN _stockBase INT,
    IN _stockMaximo INT
)
BEGIN
	INSERT INTO sedeXproducto(id_sede, id_producto, stock, stockBase, stockMaximo)
    VALUES(_id_sede, _id_producto, _stock, _stockBase, _stockMaximo);
END $

CREATE PROCEDURE LISTAR_PRODUCTOS_X_SEDE(
	IN _id_sede INT
)
BEGIN
	SELECT 	p.nombre, sp.stock, sp.stockMinimo, sp.stockMaximo
			from producto p
            inner join sedeXproducto sp on sp.id_producto = p.id_producto
            where sp.id_sede = _id_sede and sp.activo = 1;
END $

-- ORDEN DE VENTA
CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA(
	OUT _id_orden_de_venta INT,
    IN _id_empleado INT,
    IN _precioTotal DECIMAL(10, 2)
)
BEGIN
	INSERT INTO ordenDeVenta(id_empleado, fechaOrden, precioTotal, esMayorista, activo)
    VALUES(_id_empleado, current_date(), _precioTotal, false, true);
	SET _id_orden_de_venta = last_insert_id();
END $

-- ORDEN DE VENTA MAYORISTA
CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MAYORISTA(
	OUT _id_orden_de_venta INT,
    IN _id_empleado INT,
    IN _precioTotal DECIMAL(10, 2)
)
BEGIN
	INSERT INTO ordenDeVenta(id_empleado, fechaOrden, precioTotal, esMayorista, activo)
    VALUES(_id_empleado, current_date(), _precioTotal, false, true);

    SET _id_orden_de_venta = last_insert_id();

	INSERT INTO ordenDeVentaMayorista(_id_orden_de_venta, fechaEntrega, activo)
    VALUES(_id_orden_de_venta, null, true);
END $
CREATE PROCEDURE ACTUALIZAR_ORDEN_DE_VENTA_MAYORISTA(
	IN _id_orden_de_ventaMayorista INT
)
BEGIN
	UPDATE ordenDeVentaMayorista SET
    fechaEntrega = current_date()
    WHERE id_orden_de_ventaMayorista = _id_orden_de_ventaMayorista;
END $

-- LINEA DE ORDEN DE VENTA
CREATE PROCEDURE INSERTAR_LINEA_DE_ORDEN_DE_VENTA(
	IN _id_orden_de_venta INT,
    IN _id_producto INT,
    IN _cantidad INT,
    IN _descuento DECIMAL(10,2),
    IN _precio DECIMAL(10, 2)
)
BEGIN
	INSERT INTO lineaOrdenDeVenta(id_orden_de_venta, id_producto, cantidad, descuento, precio, activo)
    VALUES(_id_orden_de_venta, _id_producto, _cantidad, _descuento, _precio, true);
END $
CREATE PROCEDURE LISTAR_LINEAS_DE_ORDEN_DE_VENTA(
	IN _id_orden_de_venta int
)
BEGIN
	SELECT p.nombre, p.precio, p.precioPorMayor, lov.cantidad, lov.descuento, lov.precio as subtotal
    FROM lineaOrdenDeVenta lov
    inner join producto p on p.id_producto = lov.id_producto
    where lov.id_orden_de_venta = _id_orden_de_venta;
END $

-- PROVEEDOR

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

CREATE PROCEDURE LISTAR_PROVEEDORES()
BEGIN
	SELECT id_proveedor, nombre, direccion, RUC, telefono
    from proveedor where activo = 1;
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


