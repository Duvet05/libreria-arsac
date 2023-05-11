-- INSERTS para la tabla parametros
INSERT INTO parametros (nombre_empresa, ruc, direccion, telefono, email)
VALUES ('LIBRERIAS ARENALES S.A.C.', '20123456789', 'Av. Lima 1234, San Juan de Lurigancho, Perú', '01-2345678', 'libArenales@miempresa.com');

-- INSERTS para la tabla persona
INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Juan', 'Pérez González', '12345678A', 'juanperez@email.com', '987654321');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('María', 'García Gómez', '87654321B', 'mariagarcia@email.com', '123456789');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Jhon', 'Huaman Cortez', '7757321B', 'garcia@gmail.com', '123433389');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('María', 'Gómez Castro', '7634826A', 'mariagomez@gmail.com', '987654321');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Carlos', 'Chavez García', '6421589C', 'carloschavez@gmail.com', '123456789');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Ana', 'Ramírez López', '7382910D', 'anaramirez@gmail.com', '456789012');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Juan', 'Herrera Sánchez', '9453812E', 'juanherrera@gmail.com', '789012345');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Miguel', 'Torres Pérez', '1569324F', 'migueltorres@gmail.com', '234567890');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Paola', 'Mendoza Gutiérrez', '4376912G', 'paolamendoza@gmail.com', '678901234');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Luis', 'García Martínez', '3489271H', 'luisgarcia@gmail.com', '345678901');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Sofía', 'Sánchez González', '8392015I', 'sofiasanchez@gmail.com', '456789012');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Pedro', 'Rodríguez Pérez', '7921064J', 'pedrorodriguez@gmail.com', '123456789');

INSERT INTO persona (nombre, apellidos, DNI, correo, telefono)
VALUES ('Camila', 'Castillo Flores', '1049827K', 'camilacastillo@gmail.com', '678901234');

-- INSERTS para la tabla empleado
INSERT INTO empleado (idEmpleado, cargo, fechaContratacion, salario, direccion, contrasena)
VALUES (1, 'Gerente', '2022-01-01', 5000.00, 'Calle A #123', 'contrasena1');

INSERT INTO empleado (idEmpleado, cargo, fechaContratacion, salario, direccion, contrasena)
VALUES (2, 'Vendedor', '2022-01-01', 2000.00, 'Calle B #456', 'contrasena2');

INSERT INTO empleado (idEmpleado, cargo, fechaContratacion, salario, direccion, contrasena)
VALUES (3, 'Vendedor', '2023-01-01', 1000.00, 'Calle C #456', 'contrasena3');

-- INSERTS para la tabla vendedor
INSERT INTO vendedor (idVendedor, cantVentas, totalVendido)
VALUES (2, 10, 5000.00);

INSERT INTO vendedor (idVendedor, cantVentas, totalVendido)
VALUES (3, 10, 5000.00);

-- INSERTS para la tabla clienteMayorista
INSERT INTO clienteMayorista (idCliente, tipoDocumentoCliente, numDocumentoCliente, RUC, razonSocial)
VALUES (4, 'DNI', '12345678C', NULL, 'TAYLOY SAC');

-- INSERTS para la tabla sede
INSERT INTO sede (direccion, telefono, correo, horaIniAtencion, horaFinAtencion, descripcion, esPrincipal)
VALUES ('Av. Principal #789', '456789012', 'sede1@email.com', '08:00:00', '17:00:00', 'Sede principal', TRUE);

INSERT INTO sede (direccion, telefono, correo, horaIniAtencion, horaFinAtencion, descripcion, esPrincipal)
VALUES ('Av. Secundaria #89', '16789012', 'sede2@email.com', '08:00:00', '12:00:00', 'Sede Secundaria', FALSE);

INSERT INTO sede (direccion, telefono, correo, horaIniAtencion, horaFinAtencion, descripcion, esPrincipal)
VALUES ('Av. Secundaria #89', '16789012', 'sede2@email.com', '08:00:00', '12:00:00', 'Sede', FALSE);

-- INSERTS para la tabla proveedor
INSERT INTO proveedor (nombre, RUC, direccion1, direccion2, correo, telefono, descripcion)
VALUES ('Proveedor1', '12345678D', 'Calle C #789', NULL, 'proveedor1@email.com', '456789012', 'Proveedor 1');

INSERT INTO proveedor (nombre, RUC, direccion1, direccion2, correo, telefono, descripcion)
VALUES ('Proveedor2', '12345678T', 'Calle A #789', NULL, 'GAAA2@email.com', '9450123824', 'Proveedor 2');

-- INSERTS para la tabla sedeXproveedor
INSERT INTO sedeXproveedor (idSede, idProveedor)
VALUES (1, 1);

INSERT INTO sedeXproveedor (idSede, idProveedor)
VALUES (2, 2);

-- INSERTS para la tabla producto
INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Marca1', 'Producto1', 'Descripción del producto 1', 'Tipo1', 10.00, 8.00, 50, 50, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Planeta', 'La Sombra del Viento', 'Novela del autor Carlos Ruiz Zafón', 'Libro', 15.00, 12.00, 100, 100, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Anagrama', 'Los Detectives Salvajes', 'Novela del autor Roberto Bolaño', 'Libro', 18.00, 15.00, 80, 80, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Tusquets', 'El Amante Japonés', 'Novela del autor Isabel Allende', 'Libro', 20.00, 17.00, 120, 120, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Alfaguara', 'Rayuela', 'Novela del autor Julio Cortázar', 'Libro', 14.00, 11.00, 90, 90, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Anaya', 'Platero y Yo', 'Novela del autor Juan Ramón Jiménez', 'Libro', 12.00, 10.00, 70, 70, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Edhasa', 'El Juego de Ender', 'Novela del autor Orson Scott Card', 'Libro', 16.00, 13.00, 110, 110, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Salamandra', 'El Cartero', 'Novela del autor Pablo Neruda', 'Libro', 13.00, 11.00, 75, 75, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Tusquets', 'La Ciudad y los Perros', 'Novela del autor Mario Vargas Llosa', 'Libro', 19.00, 16.00, 100, 100, FALSE);

INSERT INTO producto (marca, nombreProducto, descripcion, tipoProducto, precioUnit, precioPorMayor, stockBase, stock, agotado)
VALUES ('Editorial Anagrama', '2666', 'Novela del autor Roberto Bolaño', 'Libro', 22.00, 19.00, 130, 130, FALSE);

-- INSERTS para la tabla sedeXproducto
INSERT INTO sedeXproducto (idSede, idProducto)
VALUES (1, 1);

INSERT INTO sedeXproducto (idSede, idProducto)
VALUES (1, 2);

INSERT INTO sedeXproducto (idSede, idProducto)
VALUES (1, 3);

INSERT INTO sedeXproducto (idSede, idProducto)
VALUES (2, 4);


-- INSERTS ORDENDECOMPRA
INSERT INTO ordenDeCompra (idEmpleado, idProveedor, fechadeOrden, precioTotalCompra, estado)
VALUES (2, 2, '2023-05-10', 500.00, TRUE);

INSERT INTO ordenDeCompra (idEmpleado, idProveedor, fechadeOrden, precioTotalCompra, estado)
VALUES (2, 2, '2023-05-11', 1000.00, FALSE);

INSERT INTO ordenDeCompra (idEmpleado, idProveedor, fechadeOrden, precioTotalCompra, estado)
VALUES (2, 1, '2023-05-12', 750.00, TRUE);

-- INSERTS LOTE
INSERT INTO lote (idOrden, idProducto, fechaObtencion, fechaVenc, cantProduct, descripcion, stockDisponible)
VALUES (2, 1, '2023-05-10', '2024-05-10', 50, 'Lote de productos frescos', 50);

-- INSERTS PEDIDO
INSERT INTO pedido (idVendedor, montoTotal, estado, fechaPedido, direccionEnvio, fechaEntrega, clienteMinor, descTotal)
VALUES (3, 500.00, 'pendiente', '2023-05-10', 'Calle 123, Lima', NULL, TRUE, 50.00);

INSERT INTO pedido (idVendedor, montoTotal, estado, fechaPedido, direccionEnvio, fechaEntrega, clienteMinor, descTotal)
VALUES (3, 500.00, 'pendiente', '2023-05-10', 'Calle 123, Lima', NULL, TRUE, 50.00);

INSERT INTO pedido (idVendedor, montoTotal, estado, fechaPedido, direccionEnvio, fechaEntrega, clienteMinor, descTotal)
VALUES (3, 500.00, 'pendiente', '2023-05-10', 'Calle 123, Lima', NULL, TRUE, 50.00);

INSERT INTO pedido (idVendedor, montoTotal, estado, fechaPedido, direccionEnvio, fechaEntrega, clienteMinor, descTotal)
VALUES (3, 500.00, 'pendiente', '2023-05-10', 'Calle 123, Lima', NULL, TRUE, 50.00);

-- INSERTS tabla lineaPedido
INSERT INTO lineaPedido (idPedido, idProducto, cantidad, subTotal, activo, descuento)
VALUES (3, 2, 2, 20.00, TRUE, 0.00);

INSERT INTO lineaPedido (idPedido, idProducto, cantidad, subTotal, activo, descuento)
VALUES (3, 3, 2, 20.00, TRUE, 0.00);
