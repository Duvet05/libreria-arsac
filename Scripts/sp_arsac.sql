DROP PROCEDURE IF EXISTS INSERTAR_MARCA;
DROP procedure IF exists INSERTAR_CATEGORIA;

DROP procedure IF exists INSERTAR_PRODUCTO;
DROP procedure IF exists LISTAR_PRODUCTOS;

DROP procedure IF exists INSERTAR_TIPO_EMPLEADO;
DROP procedure IF exists INSERTAR_SEDE;

DROP PROCEDURE IF EXISTS INSERTAR_EMPLEADO;

DROP PROCEDURE IF EXISTS INSERTAR_CLIENTE_MAYORISTA;
DROP PROCEDURE IF EXISTS LISTAR_CLIENTES_MAYORISTAS;

DROP PROCEDURE IF EXISTS INSERTAR_SEDE_X_PRODUCTO;
DROP PROCEDURE IF EXISTS LISTAR_SEDE_X_PRODUCTO;

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA;
DROP PROCEDURE IF EXISTS INSERTAR_LINEA_ORDEN_DE_VENTA;
DROP PROCEDURE IF EXISTS LISTAR_LINEA_ORDEN_DE_VENTA;

DROP PROCEDURE IF EXISTS INSERTAR_ORDEN_DE_VENTA_MAYORISTA;

DELIMITER $

-- Producto
CREATE PROCEDURE INSERTAR_MARCA(
	OUT _id_marca INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO marca(descripcion, activo)
    values(_descripcion, true);
	SET _id_marca = LAST_INSERT_ID();
END $

CREATE PROCEDURE INSERTAR_CATEGORIA(
	OUT _id_categoria INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO categoria(descripcion, activo) values(_descripcion, true);
	SET _id_categoria = LAST_INSERT_ID();
END $

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
    SELECT *
    FROM producto
    WHERE activo = true;
END $

-- Empleado
CREATE PROCEDURE INSERTAR_TIPO_EMPLEADO(
	out _idTipoEmpleado INT,
    IN _descripcion VARCHAR(50)
)
BEGIN
	INSERT INTO tipoEmpleado(descripcion, activo)
    VALUES(_descripcion, true);
	SET _idTipoEmpleado = LAST_INSERT_ID();
END $

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
	SELECT * FROM clienteMayorista;
END $

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

CREATE PROCEDURE LISTAR_SEDE_X_PRODUCTO()
BEGIN
	SELECT * FROM sedeXproducto;
END $

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

CREATE PROCEDURE INSERTAR_LINEA_ORDEN_DE_VENTA(
	IN _idOrdenDeVenta INT,
    IN _idProducto INT,
    IN _cantidad INT,
    IN _descuento DECIMAL(10,2),
    IN _precio DECIMAL(10, 2)
)
BEGIN
	DECLARE _esMayorista BOOLEAN;
    DECLARE _idSede INT;
    
    INSERT INTO lineaOrdenDeVenta(idOrdenDeVenta,idProducto,cantidad,descuento,precio)
    VALUES(_idOrdenDeVenta,_idProducto,_cantidad,_descuento,_precio);
    
	SELECT esMayorista INTO _esMayorista FROM ordenDeVenta o
	WHERE o.idOrdenDeVenta = _idOrdenDeVenta;
    
    IF _esMayorista = false THEN
    
		SELECT idSede INTO _idSede FROM empleado e INNER JOIN ordenDeVenta o
		WHERE o.idEmpleado =  e.idEmpleado and o.idOrdenDeVenta = _idOrdenDeVenta;
    
		UPDATE sedeXproducto SET stock = stock - _cantidad
        WHERE idProducto = _idProducto and idSede = _idSede;
        
    END IF;
    
END $

CREATE PROCEDURE LISTAR_LINEA_ORDEN_DE_VENTA(
	IN _idOrdenDeVenta int
)
BEGIN
	SELECT * FROM lineaOrdenDeVenta WHERE idOrdenDeVenta = _idOrdenDeVenta;
END $

CREATE PROCEDURE INSERTAR_ORDEN_DE_VENTA_MAYORISTA(
	OUT _idOrdenDeVenta INT,
    IN _idEmpleado INT,
    IN _precioTotal DECIMAL(10, 2),
    IN _idClienteMayorista INT
)
BEGIN
	INSERT INTO ordenDeVenta(idEmpleado, fechaOrden, precioTotal, esMayorista, activo)
    VALUES(_idEmpleado, current_date(), _precioTotal, true, true);
	SET _idOrdenDeVenta = last_insert_id();
    INSERT INTO ordenDeVentaMayorista(idOrdenDeVenta, idClienteMayorista, fechaEntrega)
    VALUES(_idOrdenDeVenta, _idClienteMayorista, null);
END $

