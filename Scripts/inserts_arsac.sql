-- INSERTS para la tabla parametros
INSERT INTO parametros (nombre_empresa, ruc, direccion, telefono, email)
VALUES ('LIBRERIAS ARENALES S.A.C.', '20123456789', 'Av. Lima 1234, San Juan de Lurigancho, Perú', '01-2345678', 'libArenales@miempresa.com');

-- INSERTS para los productos
CALL insertar_marca(@id_marca, 'Artesco');
CALL insertar_marca(@id_marca, 'Tekno');
CALL insertar_marca(@id_marca, 'Pilot');

CALL insertar_categoria(@id_categoria, 'UTIL ESCOLAR');
CALL insertar_categoria(@id_categoria, 'CUADERNO Y BLOCK');
CALL insertar_categoria(@id_categoria, 'PEGAMENTO Y FORRO');

CALL insertar_producto(@id_producto, 1, 1, 'Lapiz 2B', 2, 1.7);
CALL insertar_producto(@id_producto, 2, 2, 'Cauderno cuadriculado', 5, 3.7);
CALL insertar_producto(@id_producto, 2, 3, 'Pegamento en barra', 5, 4.7);

CALL insertar_tipo_empleado(@id_tipo_empleado, 'ALMACEN');
CALL insertar_tipo_empleado(@id_tipo_empleado, 'CONTABILIDAD');
CALL insertar_tipo_empleado(@id_tipo_empleado, 'VENTAS');
CALL insertar_tipo_empleado(@id_tipo_empleado, 'GERENTE');

CALL insertar_sede(@id_sede, true, 'Calle A #123', '12345678A', 'juanperez@email.com');
CALL insertar_sede(@id_sede, false, 'Calle A #123', '12345678A', 'juanperez@email.com');
CALL insertar_sede(@id_sede, false, 'Calle A #123', '12345678A', 'juanperez@email.com');
CALL insertar_sede(@id_sede, false, 'Calle A #123', '12345678A', 'juanperez@email.com');

-- INSERTS para la tabla empleado
CALL insertar_empleado(@id_empleado, '87654321', 'Juan', 'Pérez González', 'juanperez@email.com', '12345678A', 3,
						current_date(), 1500, 'Calle A #123', '1', '1', 2);
CALL insertar_empleado(@id_empleado, '87654321', 'Maria', 'Pérez González', 'juanperez@email.com', '12345678A', 3,
						current_date(), 1500, 'Calle A #123', '1', '1', 3);
CALL insertar_empleado(@id_empleado, '87654321', 'Pedro', 'Pérez González', 'juanperez@email.com', '12345678A', 3,
						current_date(), 1500, 'Calle A #123', '1', '1', 4);


-- INSERTS para la tabla sedeXproducto
CALL INSERTAR_SEDE_X_PRODUCTO(2, 1, 100, 50, 400);

CALL INSERTAR_SEDE_X_PRODUCTO (3, 2, 100, 50, 400);

CALL INSERTAR_SEDE_X_PRODUCTO (4, 3, 100, 50, 400);

CALL INSERTAR_SEDE_X_PRODUCTO (2, 3, 100, 50, 400);

CALL INSERTAR_ORDEN_DE_VENTA(@idOrdenDeVenta, 2, 500);
CALL INSERTAR_LINEA_ORDEN_DE_VENTA(4, 2, 20, 10, 50);


