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
	OUT _idProducto int,
    IN _idCategoria INT,
    IN _idMarca INT,
    IN _nombre VARCHAR(50),
    IN _precio DECIMAL(10, 2),
    IN _precioPorMayor DECIMAL(10, 2)
)
BEGIN
    INSERT INTO producto(idCategoria, idMarca, nombre, precio, precioPorMayor, activo)
    VALUES(_idCategoria, _idMarca, _nombre, _precio, _precioPorMayor, true);
    SET _idProducto = LAST_INSERT_ID();
END $
CREATE PROCEDURE LISTAR_PRODUCTOS()
BEGIN
    SELECT 	c.descripcion as categoria, m.descripcion as marca,
			p.nombre, p.precio, p.precioPorMayor
            from producto p
            inner join categoria c on p.idCategoria = c.idCategoria
            inner join marca m on p.idMarca = m.idMarca
            where p.activo = 1;
END $

-- TIPO DE EMPLEADO
CREATE PROCEDURE INSERTAR_TIPO_EMPLEADO(
	out _idTipoEmpleado INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO tipoEmpleado(descripcion, activo)
    VALUES(_descripcion, true);
	SET _idTipoEmpleado = LAST_INSERT_ID();
END $

-- SEDE
CREATE PROCEDURE INSERTAR_SEDE(
	OUT _idSede INT,
    IN _esAlmacen BOOLEAN,
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(50),
    IN _correo VARCHAR(50)
)
BEGIN
	INSERT INTO sede(esAlmacen, direccion, telefono, correo, activo)
    VALUES(_esAlmacen, _direccion, _telefono, _correo, true);
	SET _idSede = last_insert_id();
END $

-- EMPLEADO
CREATE PROCEDURE INSERTAR_EMPLEADO(
    OUT _id_empleado INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _idTipoEmpleado INT,
    IN _fechaContratacion DATE,
    IN _salario DECIMAL(10,2),
    IN _direccion VARCHAR(100),
    IN _usuario VARCHAR(50),
    IN _contrasena VARCHAR(50),
    IN _idSede INT
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo)
    VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, true);
    SET _id_empleado = LAST_INSERT_ID();
    INSERT INTO empleado(idEmpleado,idTipoEmpleado,fechaContratacion,salario,direccion, contrasena,idSede) 
            VALUES(_id_empleado,_idTipoEmpleado,_fechaContratacion,_salario,_direccion, _contrasena,_idSede);
END $

-- CLIENTE MAYORISTA
CREATE PROCEDURE INSERTAR_CLIENTE_MAYORISTA(
	OUT _idClienteMayorista INT,
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
	SET _idClienteMayorista = last_insert_id();
    INSERT INTO clienteMayorista(RUC, razonSocial)
    VALUES(_RUC, _razonSocial);
END $
CREATE PROCEDURE LISTAR_CLIENTES_MAYORISTAS()
BEGIN
	SELECT 	p.nombre, p.apellidos, p.DNI, p.correo, p.telefono, c.RUC, c.razonSocial
			from persona p
            inner join clienteMayorista c on p.idPersona = c.idClienteMayorista
            where p.activo = 1;
END $

-- SEDE X PRODUCTO
CREATE PROCEDURE INSERTAR_SEDE_X_PRODUCTO(
	IN _idSede INT,
    IN _idProducto INT,
    IN _stock INT,
    IN _stockBase INT,
    IN _stockMaximo INT
)
BEGIN
	INSERT INTO sedeXproducto(idSede, idProducto, stock, stockBase, stockMaximo)
    VALUES(_idSede, _idProducto, _stock, _stockBase, _stockMaximo);
END $
CREATE PROCEDURE LISTAR_PRODUCTOS_X_SEDE(
	IN _idSede INT
)
BEGIN
	SELECT 	p.nombre, sp.stock, sp.stockMinimo, sp.stockMaximo
			from producto p
            inner join sedeXproducto sp on sp.idProducto = p.idProducto
            where sp.idSede = _idSede and sp.activo = 1;
END $

-- ORDEN DE VENTA
CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA(
	OUT _idOrdenDeVenta INT,
    IN _idEmpleado INT,
    IN _precioTotal DECIMAL(10, 2)
)
BEGIN
	INSERT INTO ordenDeVenta(idEmpleado, fechaOrden, precioTotal, esMayorista, activo)
    VALUES(_idEmpleado, current_date(), _precioTotal, false, true);
	SET _idOrdenDeVenta = last_insert_id();
END $

-- ORDEN DE VENTA MAYORISTA
CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MAYORISTA(
	OUT _idOrdenDeVenta INT,
    IN _idEmpleado INT,
    IN _precioTotal DECIMAL(10, 2)
)
BEGIN
	INSERT INTO ordenDeVenta(idEmpleado, fechaOrden, precioTotal, esMayorista, activo)
    VALUES(_idEmpleado, current_date(), _precioTotal, false, true);

    SET _idOrdenDeVenta = last_insert_id();

	INSERT INTO ordenDeVentaMayorista(_idOrdenDeVenta, fechaEntrega, activo)
    VALUES(_idOrdenDeVenta, null, true);
END $
CREATE PROCEDURE ACTUALIZAR_ORDEN_DE_VENTA_MAYORISTA(
	IN _idOrdenDeVentaMayorista INT
)
BEGIN
	UPDATE ordenDeVentaMayorista SET
    fechaEntrega = current_date()
    WHERE idOrdenDeVentaMayorista = _idOrdenDeVentaMayorista;
END $

-- LINEA DE ORDEN DE VENTA
CREATE PROCEDURE INSERTAR_LINEA_DE_ORDEN_DE_VENTA(
	IN _idOrdenDeVenta INT,
    IN _idProducto INT,
    IN _cantidad INT,
    IN _descuento DECIMAL(10,2),
    IN _precio DECIMAL(10, 2)
)
BEGIN
	INSERT INTO lineaOrdenDeVenta(idOrdenDeVenta, idProducto, cantidad, descuento, precio, activo)
    VALUES(_idOrdenDeVenta, _idProducto, _cantidad, _descuento, _precio, true);
END $
CREATE PROCEDURE LISTAR_LINEAS_DE_ORDEN_DE_VENTA(
	IN _idOrdenDeVenta int
)
BEGIN
	SELECT p.nombre, p.precio, p.precioPorMayor, lov.cantidad, lov.descuento, lov.precio as subtotal
    FROM lineaOrdenDeVenta lov
    inner join producto p on p.idProducto = lov.idProducto
    where lov.idOrdenDeVenta = _idOrdenDeVenta;
END $



