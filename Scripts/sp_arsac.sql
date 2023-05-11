
DROP PROCEDURE IF EXISTS INSERTAR_EMPLEADO;
DROP PROCEDURE IF EXISTS ACTUALIZAR_EMPLEADO;
DROP PROCEDURE IF EXISTS ELIMINAR_EMPLEADO;
DROP PROCEDURE IF EXISTS LISTAR_EMPLEADOS;
DROP PROCEDURE IF EXISTS OBTENER_EMPLEADO;
DROP PROCEDURE IF EXISTS BUSCAR_EMPLEADO;
DROP PROCEDURE IF EXISTS VERIFICAR_EMPLEADO;

DROP PROCEDURE IF EXISTS INSERTAR_VENDEDOR;

DROP PROCEDURE IF EXISTS LISTAR_PRODUCTOS;
DROP PROCEDURE IF EXISTS ACTUALIZAR_PRODUCTO;
DROP PROCEDURE IF EXISTS OBTENER_PRODUCTO;
DROP PROCEDURE IF EXISTS INSERTAR_PRODUCTO;
DROP PROCEDURE IF EXISTS MODIFICAR_PRODUCTO;
DROP PROCEDURE IF EXISTS ELIMINAR_PRODUCTO;
DROP PROCEDURE IF EXISTS REGISTRAR_VENTA;

DROP PROCEDURE IF EXISTS INSERTAR_SEDE;
DROP PROCEDURE IF EXISTS BUSCAR_SEDE_POR_DIRECCION;

DROP PROCEDURE IF EXISTS INSERTAR_FACTURA;
DROP PROCEDURE IF EXISTS INSERTAR_BOLETA;

DELIMITER $
-- Empleado

CREATE PROCEDURE INSERTAR_EMPLEADO(
    OUT _id_empleado INT,
    IN _DNI VARCHAR(8),
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _cargo VARCHAR(70),
    IN _fechaContratacion DATE,
    IN _salario DECIMAL(10,2),
    IN _direccion VARCHAR(100),
    IN _contrasena VARCHAR(50)
)
BEGIN
    INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo) VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, 1);
    SET _id_empleado = LAST_INSERT_ID();
    INSERT INTO empleado(idEmpleado,cargo,fechaContratacion,salario,direccion, contrasena) 
            VALUES(_id_empleado,_cargo,_fechaContratacion,_salario,_direccion, _contrasena);
END $

CREATE PROCEDURE ELIMINAR_EMPLEADO(IN _idEmpleado INT)
BEGIN
    DECLARE empCount INT DEFAULT 0;
    SELECT COUNT(*) INTO empCount FROM empleado WHERE idEmpleado = _idEmpleado;
    IF empCount = 0 THEN
        SELECT 'Error: Empleado no encontrado.' AS 'Mensaje';
    ELSE
        UPDATE persona p
        INNER JOIN empleado e ON p.idUsuario = e.idEmpleado
        SET p.activo = false
        WHERE e.idEmpleado = _idEmpleado;
    END IF;
END $

CREATE PROCEDURE LISTAR_EMPLEADOS()
BEGIN
    SELECT idUsuario, nombre, apellidos, DNI, correo, telefono, cargo, fechaContratacion, salario, direccion
    FROM persona p 
    INNER JOIN empleado e ON p.idUsuario = e.idEmpleado
    WHERE p.activo = true
    UNION
    SELECT idUsuario, nombre, apellidos, DNI, correo, telefono, cargo, fechaContratacion, salario, direccion 
    FROM persona p 
    INNER JOIN empleado e ON p.idUsuario = e.idEmpleado 
    INNER JOIN vendedor v ON v.idVendedor = e.idEmpleado
    WHERE p.activo = true;
END $

CREATE PROCEDURE OBTENER_EMPLEADO(IN _idEmpleado INT)
BEGIN
    SELECT p.idUsuario, p.nombre, p.apellidos, p.DNI, p.correo, p.telefono, e.cargo, e.fechaContratacion, e.salario, e.direccion
    FROM persona p
    INNER JOIN empleado e ON p.idUsuario = e.idEmpleado
    WHERE p.activo = true AND p.idUsuario = _idEmpleado;
END $

CREATE PROCEDURE BUSCAR_EMPLEADO(IN nombre VARCHAR(50))
BEGIN
    SELECT e.idEmpleado, p.nombre, p.apellidos, p.DNI, p.correo, e.contrasena, p.telefono, e.cargo, e.fechaContratacion, e.salario, e.direccion
    FROM persona p
    INNER JOIN empleado e ON p.idUsuario = e.idEmpleado
    WHERE p.nombre LIKE CONCAT('%', nombre, '%') AND p.activo = 1;
END $


CREATE PROCEDURE VERIFICAR_EMPLEADO(
    IN email VARCHAR(50),
    IN _password VARCHAR(50),
    OUT empleadoEncontrado BOOLEAN
)
BEGIN
    DECLARE empleadoID INT;
    DECLARE empleadoPassword VARCHAR(50);
    DECLARE empleadoActivo BOOLEAN;
    
    SELECT idEmpleado, contrasena, activo
    INTO empleadoID, empleadoPassword, empleadoActivo
    FROM empleado e
    JOIN persona p ON e.idEmpleado = p.idUsuario
    WHERE p.correo = email;
    
    IF empleadoID IS NOT NULL AND empleadoPassword = _password AND empleadoActivo THEN
        SET empleadoEncontrado = TRUE;
    ELSE
        SET empleadoEncontrado = FALSE;
    END IF;
END $


-- Vendedor
CREATE PROCEDURE INSERTAR_VENDEDOR(
	OUT _id_empleado INT,
    IN _nombre VARCHAR(70),
    IN _apellidos VARCHAR(70),
    IN _DNI VARCHAR(8),
    IN _correo VARCHAR(70),
    IN _telefono VARCHAR(70),
    IN _cargo varchar(70),
    IN _fechaContratacion DATE,
    IN _salario decimal(10,2),
	IN _direccion VARCHAR(100),
    IN _contrasena VARCHAR(50),
    IN _cantidadVentas INT,
    IN _totalVendido decimal(10,2)
)
BEGIN
	INSERT INTO persona(nombre, apellidos, DNI, correo, telefono, activo) VALUES(_nombre,_apellidos,_DNI,_correo, _telefono, 1);
    SET _id_empleado = @@last_insert_id;
    INSERT INTO empleado(idEmpleado,cargo,fechaContratacion,salario,direccion, contrasena) 
			VALUES(_id_empleado,_cargo,_fechaContratacion,_salario,_direccion, _contrasena);
	INSERT INTO vendedor(idVendedor, cantVentas, totalVendido) values(_id_empleado, _cantidadVentas, _totalVendido);
END $


-- Producto
CREATE PROCEDURE INSERTAR_PRODUCTO(
    IN _marca VARCHAR(50),
    IN _nombreProducto VARCHAR(50),
    IN _descripcion VARCHAR(100),
    IN _tipoProducto VARCHAR(50),
    IN _precioUnit DECIMAL(10, 2),
    IN _precioPorMayor DECIMAL(10, 2),
    IN _stockBase INT,
    IN _stock INT
)
BEGIN
    INSERT INTO producto(marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
    VALUES(_marca, _nombreProducto, _descripcion, _tipoProducto, _precioUnit, _precioPorMayor, _stockBase, _stock, false);
END $

CREATE PROCEDURE ACTUALIZAR_PRODUCTO(
    IN _idProducto INT,
    IN _marca VARCHAR(50),
    IN _nombreProducto VARCHAR(50),
    IN _descripcion VARCHAR(100),
    IN _tipoProducto VARCHAR(50),
    IN _precioUnit DECIMAL(10, 2),
    IN _precioPorMayor DECIMAL(10, 2),
    IN _stockBase INT,
    IN _stock INT,
    IN _agotado BOOLEAN
)
BEGIN
    UPDATE producto
    SET marca = _marca,
        nombreProducto = _nombreProducto,
        descripcion = _descripcion,
        tipoProducto = _tipoProducto,
        precioUnit = _precioUnit,
        precioPorMayor = _precioPorMayor,
        stockBase = _stockBase,
        stock = _stock,
        agotado = _agotado
    WHERE idProducto = _idProducto;
END $

CREATE PROCEDURE ELIMINAR_PRODUCTO(IN _idProducto INT)
BEGIN
    UPDATE producto
    SET activo = false
    WHERE idProducto = _idProducto;
END $

CREATE PROCEDURE LISTAR_PRODUCTOS()
BEGIN
    SELECT idProducto, marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado
    FROM producto
    WHERE activo = true;
END $

CREATE PROCEDURE OBTENER_PRODUCTO(IN _idProducto INT)
BEGIN
    SELECT idProducto, marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado
    FROM producto
    WHERE activo = true AND idProducto = _idProducto;
END $

CREATE PROCEDURE REGISTRAR_VENTA(
    IN _idProducto INT,
    IN _cantidad INT,
    OUT _ventaRegistrada BOOLEAN
)
BEGIN
    DECLARE _stockActual INT;
    
    SELECT stock INTO _stockActual FROM producto WHERE idProducto = _idProducto AND activo = true;
    
    IF _stockActual >= _cantidad THEN
        UPDATE producto SET stock = _stockActual - _cantidad WHERE idProducto = _idProducto;
        SET _ventaRegistrada = true;
    ELSE
        SET _ventaRegistrada = false;
    END IF;
END $

-- SEDE
CREATE PROCEDURE INSERTAR_SEDE(
    IN _direccion VARCHAR(50),
    IN _telefono VARCHAR(20),
    IN _correo VARCHAR(50),
    IN _horaIniAtencion TIME,
    IN _horaFinAtencion TIME,
    IN _descripcion VARCHAR(100),
    IN _esPrincipal BOOLEAN
)
BEGIN
    INSERT INTO sede(direccion, telefono, correo, horaIniAtencion, horaFinAtencion, descripcion, esPrincipal) 
    VALUES(_direccion, _telefono, _correo, _horaIniAtencion, _horaFinAtencion, _descripcion, _esPrincipal);
END $

CREATE PROCEDURE BUSCAR_SEDE_POR_DIRECCION(IN nombre_sede VARCHAR(50))
BEGIN
    SELECT idSede, direccion, telefono, correo, horaIniAtencion, horaFinAtencion, descripcion, esPrincipal
    FROM sede
    WHERE activo = true AND direccion LIKE CONCAT('%', nombre_sede, '%');
END $

-- FACTURA Y BOLETA

CREATE PROCEDURE INSERTAR_FACTURA(
	IN _idPedido INT,
	IN _idCliente INT,
	IN _direccionFacturacion VARCHAR(200),
	IN _tipoMoneda VARCHAR(3),
	IN _totalVenta DECIMAL(10,2),
	IN _igv DECIMAL(10,2),
	IN _numSerie VARCHAR(4),
	IN _numCorrelativo VARCHAR(8)
)
BEGIN
	DECLARE _totalFactura DECIMAL(10,2);
	SET _totalFactura = _totalVenta + _igv;
	
	INSERT INTO factura(idFactura, idCliente, direccioFacturacion, tipoMoneda, totalVenta, igv, totalFactura, numSerie, numCorrelativo)
	VALUES (_idPedido, _idCliente, _direccionFacturacion, _tipoMoneda, _totalVenta, _igv, _totalFactura, _numSerie, _numCorrelativo);
END $

CREATE PROCEDURE INSERTAR_BOLETA(
	IN _idPedido INT,
	IN _nombreCliente VARCHAR(100),
	IN _tipoDocumentoCliente VARCHAR(3),
	IN _numDocumentoCliente VARCHAR(20),
	IN _tipoMoneda VARCHAR(3),
	IN _totalVenta DECIMAL(10,2),
	IN _igv DECIMAL(10,2),
	IN _descripcion VARCHAR(100)
)
BEGIN
	DECLARE _totalBoleta DECIMAL(10,2);
	SET _totalBoleta = _totalVenta + _igv;
	
	INSERT INTO boleta(idBoleta, nombreCliente, tipoDocumentoCliente, numDocumentoCliente, tipoMoneda, totalVenta, igv, totalBoleta, descripcion)
	VALUES (_idPedido, _nombreCliente, _tipoDocumentoCliente, _numDocumentoCliente, _tipoMoneda, _totalVenta, _igv, _totalBoleta, _descripcion);
END $

