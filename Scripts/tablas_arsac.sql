DROP TABLE IF EXISTS lineaOrdenDeVenta;

DROP TABLE IF EXISTS lineaOrdenDeCompra;

DROP TABLE IF EXISTS lineaOrdenDeAbastecimiento;

DROP TABLE IF EXISTS ordenDeVenta;

DROP TABLE IF EXISTS ordenDeCompra;

DROP TABLE IF EXISTS ordenDeAbastecimiento;

DROP TABLE IF EXISTS productoXproveedor;

DROP TABLE IF EXISTS sedeXproducto;

DROP TABLE IF EXISTS promocion;

DROP TABLE IF EXISTS producto;

DROP TABLE IF EXISTS clienteMayorista;

DROP TABLE IF EXISTS cuentaUsuario;

DROP TABLE IF EXISTS empleado;

DROP TABLE IF EXISTS sede;

DROP TABLE IF EXISTS tipoEmpleado;

DROP TABLE IF EXISTS proveedor;

DROP TABLE IF EXISTS categoria;

DROP TABLE IF EXISTS marca;

DROP TABLE IF EXISTS persona;

DROP TABLE IF EXISTS parametros;

CREATE TABLE
    parametros (
        nombre_empresa VARCHAR(100) NOT NULL,
        ruc VARCHAR(20) NOT NULL,
        direccion VARCHAR(200) NOT NULL,
        telefono VARCHAR(20) NOT NULL,
        email VARCHAR(50) NOT NULL,
        CONSTRAINT parametros_pk PRIMARY KEY (nombre_empresa)
    );

CREATE TABLE
    persona (
        id_persona INT AUTO_INCREMENT,
        nombre VARCHAR(100) NOT NULL,
        apellidos VARCHAR(100) NOT NULL,
        DNI CHAR(8) NOT NULL,
        correo VARCHAR(50) NOT NULL UNIQUE,
        telefono VARCHAR(20),
        activo boolean not null default 1,
        PRIMARY KEY(id_persona)
    ) ENGINE = InnoDB;

CREATE TABLE
    sede (
        id_sede INT AUTO_INCREMENT,
        direccion VARCHAR(50),
        telefono VARCHAR(20),
        correo VARCHAR(50),
        es_principal BOOLEAN not null default 0,
        activo boolean not null default 1,
        PRIMARY KEY (id_sede)
    ) ENGINE = InnoDB;

CREATE TABLE
    marca(
        id_marca INT AUTO_INCREMENT,
        descripcion VARCHAR(50),
        activo BOOLEAN not null default 1,
        PRIMARY KEY (id_marca)
    ) ENGINE = InnoDB;

CREATE TABLE
    categoria(
        id_categoria INT AUTO_INCREMENT,
        descripcion VARCHAR(50),
        activo BOOLEAN not null default 1,
        PRIMARY KEY (id_categoria)
    ) ENGINE = InnoDB;

CREATE TABLE
    proveedor (
        id_proveedor INT AUTO_INCREMENT,
        nombre VARCHAR(50) NOT NULL,
        RUC VARCHAR(50) NOT NULL UNIQUE,
        direccion VARCHAR(100),
        telefono VARCHAR(20),
        activo boolean not null default 1,
        PRIMARY KEY (id_proveedor)
    ) ENGINE = InnoDB;

CREATE TABLE
    tipoEmpleado(
        id_tipo_empleado INT auto_increment,
        descripcion VARCHAR(50),
        activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_tipo_empleado)
    ) ENGINE = InnoDB;

CREATE TABLE
    empleado (
        fid_empleado INT,
        fid_tipo_empleado INT,
        fid_sede INT,
        fecha_contratacion DATE,
        salario DECIMAL(10, 2),
        direccion VARCHAR(100),
        foto LONGBLOB,
        PRIMARY KEY (fid_empleado),
        FOREIGN KEY (fid_empleado) REFERENCES persona(id_persona),
        FOREIGN KEY (fid_sede) REFERENCES sede(id_sede),
        FOREIGN KEY (fid_tipo_empleado) REFERENCES tipoEmpleado(id_tipo_empleado)
    ) ENGINE = InnoDB;

CREATE TABLE
    cuentaUsuario(
        id_cuenta_usuario INT AUTO_INCREMENT,
        fid_empleado INT UNIQUE,
        usuario VARCHAR(50) NOT NULL UNIQUE,
        contrasena VARBINARY(255) NOT NULL,
        activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY(id_cuenta_usuario),
        FOREIGN KEY(fid_empleado) REFERENCES empleado(fid_empleado)
    ) ENGINE = InnoDB;

CREATE TABLE
    clienteMayorista (
        fid_cliente_mayorista INT,
        RUC VARCHAR(50),
        razon_social VARCHAR(50),
        direccion VARCHAR(255),
        PRIMARY KEY (fid_cliente_mayorista),
        FOREIGN KEY (fid_cliente_mayorista) REFERENCES persona(id_persona)
    ) ENGINE = InnoDB;

CREATE TABLE
    producto (
        id_producto INT AUTO_INCREMENT,
        fid_categoria INT,
        fid_marca INT,
        nombre VARCHAR(50),
        precio DECIMAL(10, 2),
        precio_por_mayor DECIMAL(10, 2),
        foto LONGBLOB,
        activo boolean not null default 1,
        PRIMARY KEY (id_producto),
        FOREIGN KEY (fid_categoria) references categoria(id_categoria),
        FOREIGN KEY (fid_marca) references marca(id_marca)
    ) ENGINE = InnoDB;

CREATE TABLE
    promocion (
        fid_producto INT,
        porcentaje DECIMAL(10, 2),
        cantidad_minima INT,
        fecha_inicio DATE,
        fecha_fin DATE,
        activo boolean not null default 1,
        PRIMARY KEY (fid_producto),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto)
    ) ENGINE = InnoDB;

CREATE TABLE
    sedeXproducto (
        fid_sede INT,
        fid_producto INT,
        stock INT,
        activo boolean not null default 1,
        PRIMARY KEY (fid_sede, fid_producto),
        FOREIGN KEY (fid_sede) REFERENCES sede(id_sede),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto)
    ) ENGINE = InnoDB;

CREATE TABLE
    productoXproveedor(
        fid_producto INT,
        fid_proveedor INT,
        costo DECIMAL(10, 2),
        activo boolean not null default 1,
        PRIMARY KEY (fid_producto, fid_proveedor),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto),
        FOREIGN KEY (fid_proveedor) REFERENCES proveedor(id_proveedor)
    ) ENGINE = InnoDB;

CREATE TABLE
    ordenDeAbastecimiento(
        id_orden_de_abastecimiento INT auto_increment,
        fid_empleado INT,
        fid_sede INT,
        fecha_orden DATE,
        activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_orden_de_abastecimiento),
        FOREIGN KEY (fid_empleado) REFERENCES empleado(fid_empleado),
        FOREIGN KEY (fid_sede) REFERENCES sede(id_sede)
    ) ENGINE = InnoDB;

CREATE TABLE
    lineaOrdenDeAbastecimiento (
		id_linea_orden_abastecimiento INT AUTO_INCREMENT,
        fid_orden_de_abastecimiento INT,
        fid_producto INT,
        cantidad INT,
		activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_linea_orden_abastecimiento),
        FOREIGN KEY (fid_orden_de_abastecimiento) REFERENCES ordenDeAbastecimiento(id_orden_de_abastecimiento),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto)
    ) ENGINE = InnoDB;

CREATE TABLE
    ordenDeVenta (
        id_orden_de_venta INT AUTO_INCREMENT,
        fid_empleado INT,
        fid_cliente_mayorista INT,
        total DECIMAL(10, 2),
        fecha_orden DATE,
        activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_orden_de_venta),
        FOREIGN KEY (fid_empleado) REFERENCES empleado(fid_empleado),
        FOREIGN KEY (fid_cliente_mayorista) REFERENCES clienteMayorista(fid_cliente_mayorista)
    ) ENGINE = InnoDB;

CREATE TABLE
    lineaOrdenDeVenta (
		id_linea_orden_venta INT AUTO_INCREMENT,
        fid_orden_de_venta INT,
        fid_producto INT,
        cantidad INT,
        descuento DECIMAL(10, 2),
        subtotal DECIMAL(10, 2),
        activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_linea_orden_venta),
        FOREIGN KEY (fid_orden_de_venta) REFERENCES ordenDeVenta(id_orden_de_venta),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto)
    ) ENGINE = InnoDB;


CREATE TABLE
    ordenDeCompra (
        id_orden_de_compra INT AUTO_INCREMENT,
        fid_empleado INT,
        fid_proveedor INT,
        fecha_orden DATE,
        total DECIMAL(10, 2),
        activo BOOLEAN NOT NULL DEFAULT 1,
        estado varchar(50),
        PRIMARY KEY (id_orden_de_compra),
        FOREIGN KEY (fid_empleado) REFERENCES empleado(fid_empleado),
        FOREIGN KEY (fid_proveedor) REFERENCES proveedor(id_proveedor)
    ) ENGINE = InnoDB;

CREATE TABLE
    lineaOrdenDeCompra (
		id_linea_orden_compra INT AUTO_INCREMENT,
        fid_orden_de_compra INT,
        fid_producto INT,
        cantidad INT,
        subtotal DECIMAL(10, 2),
		activo BOOLEAN NOT NULL DEFAULT 1,
        PRIMARY KEY (id_linea_orden_compra),
        FOREIGN KEY (fid_orden_de_compra) REFERENCES ordenDeCompra(id_orden_de_compra),
        FOREIGN KEY (fid_producto) REFERENCES producto(id_producto)
    ) Engine = InnoDB;

