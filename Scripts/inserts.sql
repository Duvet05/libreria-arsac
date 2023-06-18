INSERT INTO parametros (nombre_empresa, ruc, direccion, telefono, email)
VALUES ('Librería XYZ', '123456789', 'Calle Principal 123', '987654321', 'info@libreriaxyz.com');

-- INSERT para la tabla persona
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono, activo)
VALUES ('John', 'Doe', '12345678', 'johndoe@example.com', '987654321', true);
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono, activo)
VALUES ('Jane', 'Smith', '87654321', 'janesmith@example.com', '123456789', true);
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono, activo)
VALUES ('Michael', 'Johnson', '45678912', 'michaeljohnson@example.com', '987123456', true);
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono, activo)
VALUES ('Sarah', 'Williams', '32165487', 'sarahwilliams@example.com', '654789123', true);
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono, activo)
VALUES ('David', 'Brown', '98765432', 'davidbrown@example.com', '321654987', true);

-- INSERT para la tabla sede
INSERT INTO sede (direccion, telefono, correo, es_principal, activo)
VALUES ('Calle Principal 123', '987654321', 'sede@example.com', true, true);

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

-- INSERT para la tabla tipoEmpleado
INSERT INTO tipoEmpleado (descripcion, activo)
VALUES ('Gerente', true);
/*
	todo
*/
INSERT INTO tipoEmpleado (descripcion, activo)
VALUES ('Vendedor', true);
/*
	pedidos, reportes
*/
INSERT INTO tipoEmpleado (descripcion, activo)
VALUES ('Logistica', true);
/*
	sedes,proveedores, reportes, rrhh
*/
INSERT INTO tipoEmpleado (descripcion, activo)
VALUES ('Almacen', true);
/*
	almacen, sedes, provee
*/
INSERT INTO tipoEmpleado (descripcion, activo)
VALUES ('Contabilidad', true);
/*
	rrhh, reporte
*/


-- INSERT para la tabla empleado
INSERT INTO empleado (fid_empleado, fid_tipo_empleado, fid_sede, fecha_contratacion, salario, direccion, foto)
VALUES (1, 1, 1, '2023-06-16', 2000.00, 'Calle Empleado 123', NULL);

-- INSERT para la tabla clienteMayorista
INSERT INTO clienteMayorista (fid_cliente_mayorista, RUC, razon_social)
VALUES (1, '1234567890', 'Cliente Mayorista A');
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

CALL `lp2`.`INSERTAR_CUENTA_USUARIO`(@x, 1, 'usuario1', 'contrasena1');
