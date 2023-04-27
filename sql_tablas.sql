DROP TABLE IF EXISTS sedeXproveedor;
DROP TABLE IF EXISTS sedeXproducto;
DROP TABLE IF EXISTS lote;
DROP TABLE IF EXISTS ordenDeCompra;
DROP TABLE IF EXISTS lineaPedido;
DROP TABLE IF EXISTS factura;
DROP TABLE IF EXISTS boleta;
DROP TABLE IF EXISTS pedido;
DROP TABLE IF EXISTS producto;
DROP TABLE IF EXISTS vendedor;
DROP TABLE IF EXISTS empleado;
DROP TABLE IF EXISTS proveedor;
DROP TABLE IF EXISTS sede;
DROP TABLE IF EXISTS empresa;
DROP TABLE IF EXISTS clienteMayorista;
DROP TABLE IF EXISTS persona;

CREATE TABLE persona (
	idUsuario INT AUTO_INCREMENT,
    nombre VARCHAR(50),
    apellidos VARCHAR(100),
    DNI VARCHAR(8),
    correo VARCHAR(50),
    telefono VARCHAR(20),
    activo tinyint,
    PRIMARY KEY(idUsuario)
)ENGINE=InnoDB;

CREATE TABLE empleado (
	idEmpleado INT,
    cargo VARCHAR(50),
    fechaContratacion DATE,
    salario DECIMAL(10, 2),
    direccion VARCHAR(100),
    contrasena VARCHAR(50),
    PRIMARY KEY (idEmpleado),
    FOREIGN KEY (idEmpleado) REFERENCES persona(idUsuario)
)ENGINE=InnoDB;

CREATE TABLE vendedor (
	idVendedor INT,
    cantVentas INT,
    totalVendido DECIMAL(10, 2),
    PRIMARY KEY (idVendedor),
    FOREIGN KEY (idVendedor) REFERENCES empleado(idEmpleado)
)ENGINE=InnoDB;

CREATE TABLE clienteMayorista (
	idCliente INT,
    RUC VARCHAR(50),
    razonSocial VARCHAR(50),
    PRIMARY KEY (idCliente),
    FOREIGN KEY (idCliente) REFERENCES persona(idUsuario)
)ENGINE=InnoDB;

CREATE TABLE empresa (
	idEmpresa INT AUTO_INCREMENT,
    RUC VARCHAR(50),
    telefono VARCHAR(20),
    correo VARCHAR(50),
    razonSocial VARCHAR(50),
    PRIMARY KEY (idEmpresa)
)ENGINE=InnoDB;

CREATE TABLE sede (
	idSede INT AUTO_INCREMENT,
	idEmpresa INT,
    direccion VARCHAR(50),
    telefono VARCHAR(20),
    correo VARCHAR(50),
    horaIniAtencion TIME,
	horaFinAtencion TIME,
    descripcion VARCHAR(100),
    esPrincipal BOOLEAN,
    PRIMARY KEY (idSede),
    FOREIGN KEY (idEmpresa) REFERENCES empresa(idEmpresa)
)ENGINE=InnoDB;

CREATE TABLE proveedor (
	idProveedor INT AUTO_INCREMENT,
    nombre VARCHAR(50),
    RUC VARCHAR(50),
    direccion1 VARCHAR(100),
    direccion2 VARCHAR(100),
    correo VARCHAR(50),
    telefono VARCHAR(20),
    descripcion VARCHAR(100),
    PRIMARY KEY (idProveedor)
)ENGINE=InnoDB;
 
CREATE TABLE sedeXproveedor (
	idSede INT,
    idProveedor INT,
    PRIMARY KEY (idSede, idProveedor),
	FOREIGN KEY (idSede) REFERENCES sede(idSede),
	FOREIGN KEY (idProveedor) REFERENCES proveedor(idProveedor) 
)ENGINE=InnoDB;

CREATE TABLE producto (
	idProducto INT AUTO_INCREMENT,
    marca VARCHAR(50),
    nombreProducto VARCHAR(50),
    descripcion VARCHAR(100),
    tipoProducto VARCHAR(50),
    precioUnit DECIMAL(10, 2),
    precioPorMayor DECIMAL(10, 2),
    stockBase INT,
    stock INT,
    agotado BOOLEAN,
    PRIMARY KEY (idProducto)    
)ENGINE=InnoDB;

CREATE TABLE sedeXproducto (
	idSede INT,
    idProducto INT,
    PRIMARY KEY (idSede, idProducto),
	FOREIGN KEY (idSede) REFERENCES sede(idSede),
	FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE ordenDeCompra (
	idOrden INT AUTO_INCREMENT,
    idEmpleado INT,
    idProveedor INT,
    fechadeOrden DATE,
    precioTotalCompra DECIMAL(10, 2),
    estado BOOLEAN,
    PRIMARY KEY (idOrden),
    FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
    FOREIGN KEY (idProveedor) REFERENCES proveedor(idProveedor)
)ENGINE=InnoDB;

CREATE TABLE lote (
    idLote INT AUTO_INCREMENT,
	idOrden INT,
    idProducto INT,
    fechaObtencion DATE,
    fechaVenc DATE,
    cantProduct INT,
    descripcion VARCHAR(100),
    stockDisponible INT,
    PRIMARY KEY (idLote),
    FOREIGN KEY (idOrden) REFERENCES ordenDeCompra(idOrden),
    FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE pedido (
	idPedido INT AUTO_INCREMENT,
    idVendedor INT,
	montoTotal DECIMAL(10, 2),
    estado VARCHAR(50),
    fechaPedido DATE,
    direccionEnvio VARCHAR(100),
    fechaEntrega DATE,
    clienteMinor BOOLEAN,
    descTotal DECIMAL(10, 2),
    PRIMARY KEY (idPedido),
    FOREIGN KEY (idVendedor) REFERENCES vendedor(idVendedor)
)ENGINE=InnoDB;

CREATE TABLE lineaPedido (
	idLineaPedido INT AUTO_INCREMENT,
    idPedido INT,
    idProducto INT,
    cantidad INT,
    subTotal DECIMAL(10, 2),
    activo BOOLEAN,
    descuento DECIMAL(10, 2),
    PRIMARY KEY (idLineaPedido),
    FOREIGN KEY (idPedido) REFERENCES pedido(idPedido),
    FOREIGN KEY (idProducto) REFERENCES producto(idProducto)
)ENGINE=InnoDB;

CREATE TABLE factura (
	idFactura INT,
	idCliente INT,
    PRIMARY KEY (idFactura),
    FOREIGN KEY (idFactura) REFERENCES pedido(idPedido),
    FOREIGN KEY (idCliente) REFERENCES clienteMayorista(idCliente)
)ENGINE=InnoDB;

CREATE TABLE boleta (
	idBoleta INT,
    descripcion VARCHAR(100),
    PRIMARY KEY (idBoleta),
    FOREIGN KEY (idBoleta) REFERENCES pedido(idPedido)
)ENGINE=InnoDB;

/*---------------------------------------------------------------------------------------*/

