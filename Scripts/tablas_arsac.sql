DROP TABLE IF EXISTS ordenDeCompraXproveedorXproducto;
DROP TABLE IF EXISTS ordenDeCompraXproveedor;
DROP TABLE IF EXISTS ordenDeCompra;
DROP TABLE IF EXISTS ordenDeVentaMayorista;
DROP TABLE IF EXISTS lineaOrdenDeVenta;
DROP TABLE IF EXISTS ordenDeVenta;
DROP TABLE IF EXISTS lineaOrdenDeAbastecimiento;
DROP TABLE IF EXISTS ordenDeAbastecimiento;
DROP TABLE IF EXISTS productoXproveedor;
DROP TABLE IF EXISTS sedeXproducto;
DROP TABLE IF EXISTS promocion;
DROP TABLE IF EXISTS producto;
DROP TABLE IF EXISTS clienteMayorista;
DROP TABLE IF EXISTS empleado;
DROP TABLE IF EXISTS tipoEmpleado;
DROP TABLE IF EXISTS proveedor;
DROP TABLE IF EXISTS categoria;
DROP TABLE IF EXISTS marca;
DROP TABLE IF EXISTS sede;
DROP TABLE IF EXISTS persona;
DROP TABLE IF EXISTS parametros;

CREATE TABLE parametros (
  nombre_empresa VARCHAR(100) NOT NULL,
  ruc VARCHAR(20) NOT NULL,
  direccion VARCHAR(200) NOT NULL,
  telefono VARCHAR(20) NOT NULL,
  email VARCHAR(50) NOT NULL,
  CONSTRAINT parametros_pk PRIMARY KEY (nombre_empresa)
);

CREATE TABLE persona (
	idPersona INT AUTO_INCREMENT,
    nombre VARCHAR(50),
    apellidos VARCHAR(100),
    DNI CHAR(8),
    correo VARCHAR(50),
    telefono VARCHAR(20),
    activo boolean not null default 1,
    PRIMARY KEY(idPersona)
)ENGINE=InnoDB;

CREATE TABLE sede (
	idSede INT AUTO_INCREMENT,
    direccion VARCHAR(50),
    telefono VARCHAR(20),
    correo VARCHAR(50),
    esAlmacen BOOLEAN not null default 0,
    activo boolean not null default 1,
    PRIMARY KEY (idSede)
)ENGINE=InnoDB;

CREATE TABLE marca(
	idMarca INT AUTO_INCREMENT,
	descripcion VARCHAR(50),
	activo BOOLEAN not null default 1,
	PRIMARY KEY (idMarca)
)ENGINE=InnoDB;

CREATE TABLE categoria(
	idCategoria INT AUTO_INCREMENT,
	descripcion VARCHAR(50),
	activo BOOLEAN not null default 1,
	PRIMARY KEY (idCategoria)
)ENGINE=InnoDB;

CREATE TABLE proveedor (
	idProveedor INT AUTO_INCREMENT,
    nombre VARCHAR(50),
    RUC VARCHAR(50),
    direccion VARCHAR(100),
    telefono VARCHAR(20),
    activo boolean not null default 1,
    PRIMARY KEY (idProveedor)
)ENGINE=InnoDB;

CREATE TABLE tipoEmpleado(
	idTipoEmpleado INT auto_increment,
    descripcion VARCHAR(50),
    activo BOOLEAN NOT NULL DEFAULT 1,
    PRIMARY KEY (idTipoEmpleado)
)ENGINE=InnoDB;

CREATE TABLE empleado (
	idEmpleado INT,
	idSede INT,
    fechaContratacion DATE,
    salario DECIMAL(10, 2),
    direccion VARCHAR(100),
	usuario VARCHAR(50),
    contrasena VARCHAR(50),
    idTipoEmpleado INT,
    PRIMARY KEY (idEmpleado),
    FOREIGN KEY (idEmpleado) REFERENCES persona(idPersona),
	FOREIGN KEY (idSede) REFERENCES sede(idSede),
    FOREIGN KEY (idTipoEmpleado) REFERENCES tipoEmpleado(idTipoEmpleado)
)ENGINE=InnoDB;

CREATE TABLE clienteMayorista (
	idClienteMayorista INT,
    RUC VARCHAR(50),
    razonSocial VARCHAR(50),
    PRIMARY KEY (idClienteMayorista),
    FOREIGN KEY (idClienteMayorista) REFERENCES persona(idPersona)
)ENGINE=InnoDB;

CREATE TABLE producto (
	idProducto INT AUTO_INCREMENT,
	idCategoria INT,
	idMarca INT,
	nombre VARCHAR(50),
    precio DECIMAL(10, 2),
    precioPorMayor DECIMAL(10, 2),
    activo boolean not null default 1,
    PRIMARY KEY (idProducto),
    FOREIGN KEY (idCategoria) references categoria(idCategoria),
    FOREIGN KEY (idMarca) references marca(idMarca)
)ENGINE=InnoDB;

CREATE TABLE promocion (
	idProducto INT,
    porcentaje DECIMAL(10, 2),
    cantidadMinima INT,
    fechaInicio DATE,
	fechaFin DATE,
    activo boolean not null default 1,
    PRIMARY KEY (idProducto),
	FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE sedeXproducto (
	idSede INT,
	idProducto INT,
	stock INT,
	stockMinimo INT,
	stockMaximo INT,
	activo boolean not null default 1,
	PRIMARY KEY (idSede, idProducto),
	FOREIGN KEY (idSede) REFERENCES sede(idSede),
	FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE productoXproveedor(
	idProducto INT,
	idProveedor INT,
	costo DECIMAL(10, 2),
	activo boolean not null default 1,
	PRIMARY KEY (idProducto, idProveedor),
	FOREIGN KEY (idProveedor) REFERENCES proveedor(idProveedor),
	FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE ordenDeAbastecimiento(
	idOrdenDeAbastecimiento INT auto_increment,
	idEmpleado INT,
	idSede INT,
	fechaOrden DATE,
	fechaEntrega DATE,
    estado VARCHAR(50),
    activo BOOLEAN NOT NULL DEFAULT 1,
	PRIMARY KEY (idOrdenDeAbastecimiento),
	FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado),
	FOREIGN KEY (idSede) REFERENCES sede(idSede)
)ENGINE=InnoDB;

CREATE TABLE lineaOrdenDeAbastecimiento (
	idOrdenDeAbastecimiento INT,
	idProducto INT,
	cantidad INT,
	PRIMARY KEY (idOrdenDeAbastecimiento, idProducto),
	FOREIGN KEY (idOrdenDeAbastecimiento) REFERENCES ordenDeAbastecimiento(idOrdenDeAbastecimiento),
	FOREIGN KEY (idProducto) REFERENCES producto(idProducto)
)ENGINE=InnoDB;

CREATE TABLE ordenDeVenta (
	idOrdenDeVenta INT AUTO_INCREMENT,
    idEmpleado INT,
	precioTotal DECIMAL(10, 2),
    fechaOrden DATE,
    esMayorista BOOLEAN,
    activo BOOLEAN NOT NULL DEFAULT 1,
    PRIMARY KEY (idOrdenDeVenta),
    FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado)
)ENGINE=InnoDB;

CREATE TABLE lineaOrdenDeVenta (
	idOrdenDeVenta INT,
    idProducto INT,
    cantidad INT,
    descuento DECIMAL(10, 2),
    precio DECIMAL(10,2),
    activo BOOLEAN NOT NULL DEFAULT 1,
    PRIMARY KEY (idOrdenDeVenta, idProducto),
    FOREIGN KEY (idOrdenDeVenta) REFERENCES ordenDeVenta(idOrdenDeVenta),
    FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)ENGINE=InnoDB;

CREATE TABLE ordenDeVentaMayorista(
	idOrdenDeVenta INT,
    idClienteMayorista INT,
    fechaEntrega DATE,
    PRIMARY KEY (idOrdenDeVenta),
    FOREIGN KEY (idOrdenDeVenta) REFERENCES ordenDeVenta(idOrdenDeVenta),
    FOREIGN KEY (idClienteMayorista) REFERENCES clienteMayorista(idClienteMayorista)
)ENGINE=InnoDB;

CREATE TABLE ordenDeCompra (
	idOrdenDeCompra INT AUTO_INCREMENT,
	idEmpleado INT,
	fechadeOrden DATE,
	costoTotal DECIMAL(10, 2),
    activo BOOLEAN NOT NULL DEFAULT 1,
	PRIMARY KEY (idOrdenDeCompra),
	FOREIGN KEY (idEmpleado) REFERENCES empleado(idEmpleado)
)ENGINE=InnoDB;

CREATE TABLE ordenDeCompraXproveedor (
    idOrdenDeCompra INT,
	idProveedor INT,
    fechaLlegada DATE,
    costo DECIMAL(10, 2),
    primary key (idOrdenDeCompra, idProveedor),
    FOREIGN KEY (idOrdenDeCompra) REFERENCES ordenDeCompra(idOrdenDeCompra),
    FOREIGN KEY (idProveedor) REFERENCES proveedor(idProveedor)
)ENGINE=InnoDB;

CREATE TABLE ordenDeCompraXproveedorXproducto (
	idOrdenDeCompra INT,
	idProveedor INT,
    idProducto INT,
    cantidad INT,
    costo DECIMAL(10, 2),
    PRIMARY KEY (idOrdenDeCompra, idProveedor, idProducto),
    FOREIGN KEY (idOrdenDeCompra) REFERENCES ordenDeCompraXproveedor(idOrdenDeCompra),
    FOREIGN KEY (idProveedor) REFERENCES ordenDeCompraXproveedor(idProveedor),
    FOREIGN KEY (idProducto) REFERENCES producto(idProducto) 
)Engine=InnoDB;


