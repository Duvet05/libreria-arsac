
INSERT INTO parametros (nombre_empresa, ruc, direccion, telefono, email)
VALUES ('ARSAC S.A.', '12345678901', 'Av. Los Girasoles 789, Miraflores, Lima', '923456789', 'ARSAC_SA@gmail.com');
-- #######################################################################
-- INSERT para la tabla persona
-- #######################################################################
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono) VALUES
    ('Juan', 'López', '42789045', 'juan.lopez@gmail.com', '911234567'),
    ('María', 'García', '50013698', 'maria.garcia@gmail.com', '922345678'),
    ('Carlos', 'Martínez', '76251480', 'carlos.martinez@gmail.com', '933456789'),
    ('Ana', 'Rodríguez', '54286791', 'ana.rodriguez@gmail.com', '944567890'),
    ('Pedro', 'Hernández', '64398275', 'pedro.hernandez@gmail.com', '955678901'),
    ('Laura', 'Pérez', '43267509', 'laura.perez@gmail.com', '966789012'),
    ('Luis', 'Gómez', '52940768', 'luis.gomez@gmail.com', '977890123'),
    ('Marta', 'Torres', '48957263', 'marta.torres@gmail.com', '988901234'),
    ('Javier', 'Rojas', '84459370', 'javier.rojas@gmail.com', '999012345'),
    ('Paula', 'Sánchez', '73295168', 'paula.sanchez@gmail.com', '900123456'),
    ('Roberto', 'Díaz', '50439872', 'roberto.diaz@gmail.com', '911234567'),
    ('Sofía', 'Romero', '64058973', 'sofia.romero@gmail.com', '922345678'),
    ('Gabriel', 'Ortega', '84452690', 'gabriel.ortega@gmail.com', '933456789'),
    ('Carmen', 'Vargas', '53724968', 'carmen.vargas@gmail.com', '944567890'),
    ('Raúl', 'Molina', '78239645', 'raul.molina@gmail.com', '955678901'),
    ('Isabel', 'Campos', '47586391', 'isabel.campos@gmail.com', '966789012'),
    ('Alejandro', 'Fuentes', '51072946', 'alejandro.fuentes@gmail.com', '977890123'),
    ('Elena', 'Guerrero', '44329570', 'elena.guerrero@gmail.com', '988901234'),
    ('Mario', 'Cruz', '81036854', 'mario.cruz@gmail.com', '999012345'),
    ('Natalia', 'Silva', '73648021', 'natalia.silva@gmail.com', '900123456'),
    ('Andrés', 'Vega', '52079348', 'andres.vega@gmail.com', '911234567'),
    ('Luisa', 'Fernández', '87049153', 'luisa.fernandez@gmail.com', '922345678'),
    ('Fernando', 'Navarro', '72136849', 'fernando.navarro@gmail.com', '933456789'),
    ('Julia', 'Rivas', '50397826', 'julia.rivas@gmail.com', '944567890'),
    ('Diego', 'Reyes', '68092573', 'diego.reyes@gmail.com', '955678901'),
    ('Valeria', 'Mendoza', '42683957', 'valeria.mendoza@gmail.com', '966789012'),
    ('Gonzalo', 'Aguilar', '56427908', 'gonzalo.aguilar@gmail.com', '977890123'),
    ('Carolina', 'Soto', '81265793', 'carolina.soto@gmail.com', '988901234'),
    ('Andrea', 'Escobar', '46532987', 'andrea.escobar@gmail.com', '999012345'),
    ('Daniel', 'Castillo', '72094653', 'daniel.castillo@gmail.com', '900123456'),
    ('Mariana', 'Guzmán', '52874319', 'mariana.guzman@gmail.com', '911234567'),
    ('Manuel', 'Luna', '89670243', 'manuel.luna@gmail.com', '922345678'),
    ('Sara', 'Cortés', '69473285', 'sara.cortes@gmail.com', '933456789'),
    ('Héctor', 'Ríos', '54907642', 'hector.rios@gmail.com', '944567890'),
    ('Adriana', 'Delgado', '77869034', 'adriana.delgado@gmail.com', '955678901'),
    ('Jorge', 'Castañeda', '47615928', 'jorge.castaneda@gmail.com', '966789012'),
    ('Daniela', 'Villalobos', '49158307', 'daniela.villalobos@gmail.com', '977890123'),
    ('Juan', 'Mejía', '85927314', 'juan.mejia@gmail.com', '988901234'),
    ('Patricia', 'Paredes', '67341892', 'patricia.paredes@gmail.com', '999012345'),
    ('Emilio', 'Santos', '43190275', 'emilio.santos@gmail.com', '900123456'),
    ('Renata', 'Valencia', '54692738', 'renata.valencia@gmail.com', '911234567'),
    ('Óscar', 'Montes', '83967124', 'oscar.montes@gmail.com', '922345678'),
    ('Gabriela', 'Cordero', '72684015', 'gabriela.cordero@gmail.com', '933456789'),
    ('Hugo', 'Rocha', '49580372', 'hugo.rocha@gmail.com', '944567890'),
    ('Camila', 'Vera', '81396450', 'camila.vera@gmail.com', '955678901'),
    ('Ricardo', 'Cabrera', '71459023', 'ricardo.cabrera@gmail.com', '966789012'),
    ('Paola', 'Miranda', '53874296', 'paola.miranda@gmail.com', '977890123'),
    ('Luisa', 'González', '52780913', 'luisa.gonzalez@gmail.com', '900123456'),
	('Diego', 'Martínez', '61725489', 'diego.martinez@gmail.com', '911234657'),
	('María', 'López', '43517826', 'maria.lopez@gmail.com', '922345768'),
	('Andrés', 'Ramírez', '75290418', 'andres.ramirez@gmail.com', '933456879'),
	('Carolina', 'Herrera', '69051247', 'carolina.herrera@gmail.com', '944567980'),
	('Javier', 'Pérez', '36504287', 'javier.perez@gmail.com', '955678091');

-- #######################################################################
-- INSERT para la tabla sede
-- #######################################################################
INSERT INTO sede (direccion, telefono, correo, es_principal) 
VALUES ('Av. Los Jazmines 123, Los Olivos, Lima', '987654321', 'ARSAC_SAsede1@gmail.com', 0);
INSERT INTO sede (direccion, telefono, correo, es_principal) 
VALUES ('Jirón Las Orquídeas 456, Barranco, Lima', '912345678', 'ARSAC_SAsede2@gmail.com', 0);
INSERT INTO sede (direccion, telefono, correo, es_principal) 
VALUES ('Jirón Los Lirios 012, San Isidro, Lima', '934567890', 'ARSAC_SAsede3@gmail.com', 0);
INSERT INTO sede (direccion, telefono, correo, es_principal) 
VALUES ('Av. Las Margaritas 345, Surco, Lima', '945678901', 'ARSAC_SAsede4@gmail.com', 0);
INSERT INTO sede (direccion, telefono, correo, es_principal) 
VALUES ('Av. Los Girasoles 789, Miraflores, Lima', '923456789', 'ARSAC_SA@gmail.com', 1);
-- #######################################################################
-- INSERT para la tabla marca
-- #######################################################################
INSERT INTO marca (descripcion) VALUES ('ARTESCO');
INSERT INTO marca (descripcion) VALUES ('FABER_CASTELL');
INSERT INTO marca (descripcion) VALUES ('STANDFORD');
INSERT INTO marca (descripcion) VALUES ('ALPHA');

-- #######################################################################
-- INSERT para la tabla categoria
-- #######################################################################
INSERT INTO categoria (descripcion) VALUES ('LAPICEROS');
INSERT INTO categoria (descripcion) VALUES ('BORRADORES');
INSERT INTO categoria (descripcion) VALUES ('CUADERNOS');
INSERT INTO categoria (descripcion) VALUES ('CINTAS');
INSERT INTO categoria (descripcion) VALUES ('REGLAS');

-- INSERT para la tabla proveedor
INSERT INTO proveedor (nombre, RUC, direccion, telefono, activo)
VALUES ('Proveedor A', '1234567890', 'Calle Proveedor 123', '987654321', true);

-- #######################################################################
-- INSERT para la tabla tipoEmpleado
-- #######################################################################
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Gerente');
/*
	todo
*/
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Vendedor Mayorista');
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Vendedor Minorista');
/*
	pedidos, reportes
*/
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Logistica');
/*
	sedes,proveedores, reportes, rrhh
*/
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Almacen');
/*
	almacen, sedes, provee
*/
INSERT INTO tipoEmpleado (descripcion)
VALUES ('Contabilidad');
/*
	rrhh, reporte
*/


-- INSERT para la tabla empleado
INSERT INTO empleado (fid_empleado, fid_tipo_empleado, fid_sede, fecha_contratacion, salario, direccion, foto)
VALUES (1, 1, 1, '2023-06-16', 2000.00, 'Calle Empleado 123', NULL);

-- INSERT para la tabla clienteMayorista
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (1, '20547896321', 'Escolares Express');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (2, '30872514682', 'Papelería Directa S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (3, '46238957143', 'Distribuidora Educativa Ríos');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (4, '57942136734', 'Artículos Escolares Innovación');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (5, '63928745195', 'Material Didáctico S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (6, '71859236406', 'Útiles Pedagógicos Moderna');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (7, '85764321967', 'Comercializadora Educativa');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (8, '95372648138', 'Distribuidora Escolar González');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (9, '10493526789', 'Papelería Creativa S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (10, '11764853091', 'Suministros Pedagógicos');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (11, '12940587652', 'Distribuidora de Materiales Escolares');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (12, '13396078243', 'Artículos Didácticos S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (13, '14762891364', 'Mayorista de Útiles Educativos');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (14, '15327984655', 'Distribuidora Escolar Morales');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (15, '16843920526', 'Comercializadora Pedagógica');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (16, '17580293467', 'Papelería Integral S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (17, '18254639758', 'Mayorista de Materiales Educativos');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (18, '19908374599', 'Distribuidora Educativa S.A.');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (19, '20473861910', 'Artículos Escolares Avanzados');
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social) 
VALUES (20, '21847052321', 'Comercializadora de Útiles Pedagógicos');
-- #######################################################################
-- INSERT para la tabla producto
-- #######################################################################
-- Grupo 1 - Marca: ARTESCO
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (1, 1, 'LAPICERO ARTESCO AZUL 4MM', 5.99, 5.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (2, 1, 'BORRADOR ARTESCO GRANDE', 3.99, 3.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor)
VALUES (3, 1, 'CUADERNO ARTESCO RAYADO TAPA DURA', 9.99, 9.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (4, 1, 'CINTA ARTESCO TRANSPARENTE 1.5CM', 4.99, 4.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (5, 1, 'REGLA ARTESCO 30CM', 2.99, 2.49);

-- Grupo 2 - Marca: FABER_CASTELL
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (1, 2, 'LAPICERO FABER_CASTELL NEGRO 5MM', 6.99, 6.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (2, 2, 'BORRADOR FABER_CASTELL PEQUEÑO', 2.99, 2.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (3, 2, 'CUADERNO FABER_CASTELL CUADRICULADO TAPA BLANDA', 8.99, 8.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (4, 2, 'CINTA FABER_CASTELL TRANSPARENTE 2CM', 5.99, 5.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (5, 2, 'REGLA FABER_CASTELL 20CM', 3.99, 3.49);

-- Grupo 3 - Marca: STANDFORD
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (1, 3, 'LAPICERO STANDFORD ROJO 6MM', 7.99, 7.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (2, 3, 'BORRADOR STANDFORD MEDIANO', 3.99, 3.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (3, 3, 'CUADERNO STANDFORD RAYADO TAPA BLANDA', 7.99, 7.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (4, 3, 'CINTA STANDFORD TRANSPARENTE 1CM', 3.99, 3.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (5, 3, 'REGLA STANDFORD 15CM', 2.99, 2.49);

-- Grupo 4 - Marca: ALPHA
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (1, 4, 'LAPICERO ALPHA VERDE 4.5MM', 4.99, 4.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (2, 4, 'BORRADOR ALPHA GRANDE', 3.99, 3.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (3, 4, 'CUADERNO ALPHA CUADRICULADO TAPA DURA', 9.99, 9.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (4, 4, 'CINTA ALPHA TRANSPARENTE 1.2CM', 4.99, 4.49);
INSERT INTO producto (fid_categoria, fid_marca, nombre, precio, precio_por_mayor) 
VALUES (5, 4, 'REGLA ALPHA 25CM', 3.99, 3.49);

-- #######################################################################
-- INSERT para la tabla promocion
-- #######################################################################
INSERT INTO promocion (fid_producto, porcentaje, cantidad_minima, fecha_inicio, fecha_fin, activo)
VALUES (1, 10.00, 5, '2023-06-16', '2023-06-30', true);

-- INSERT para la tabla sedeXproducto
INSERT INTO sedeXproducto (fid_sede, fid_producto, stock, activo)
VALUES (1, 1, 100, true);

-- INSERT para la tabla productoXproveedor
INSERT INTO productoXproveedor (fid_producto, fid_proveedor, costo, activo)
VALUES (1, 1, 8.00, true);

-- INSERT para la tabla ordenDeAbastecimiento
INSERT INTO ordenDeAbastecimiento (fid_empleado, fid_sede, fecha_orden, activo)
VALUES (1, 1, '2023-06-16', true);

-- INSERT para la tabla lineaOrdenDeAbastecimiento
INSERT INTO lineaOrdenDeAbastecimiento (fid_orden_de_abastecimiento, fid_producto, cantidad)
VALUES (1, 1, 50);

-- INSERT para la tabla ordenDeVenta
INSERT INTO ordenDeVenta (fid_empleado, fid_cliente_mayorista, total, fecha_orden, activo)
VALUES (1, 1, 100.00, '2023-06-16', true);

-- INSERT para la tabla lineaOrdenDeVenta
INSERT INTO lineaOrdenDeVenta (fid_orden_de_venta, fid_producto, cantidad, descuento, subtotal, activo)
VALUES (1, 1, 2, 0.10, 18.00, true);

-- INSERT para la tabla ordenDeCompra
INSERT INTO ordenDeCompra (fid_empleado, fid_proveedor, fecha_orden, total, activo)
VALUES (1, 1, '2023-06-16', 500.00, true);

-- INSERT para la tabla lineaOrdenDeCompra
INSERT INTO lineaOrdenDeCompra (fid_orden_de_compra, fid_producto, cantidad, subtotal)
VALUES (1, 1, 10, 100.00);