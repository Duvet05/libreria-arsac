INSERT INTO tipoEmpleado(descripcion, activo) VALUES("GERENCIA", 1);
INSERT INTO tipoEmpleado(descripcion, activo) VALUES("VENTAS", 1);
INSERT INTO tipoEmpleado(descripcion, activo) VALUES("LOGISTICA", 1);
INSERT INTO tipoEmpleado(descripcion, activo) VALUES("ALMACEN", 1);
INSERT INTO tipoEmpleado(descripcion, activo) VALUES("CONTABILIDAD", 1);

INSERT INTO sede(direccion, telefono, correo, es_principal) VALUES("fff", "1111", "222", true);
INSERT INTO sede(direccion, telefono, correo, es_principal) VALUES("qqq", "1111", "666", false);
INSERT INTO sede(direccion, telefono, correo, es_principal) VALUES("hhh", "444", "333", false);
INSERT INTO sede(direccion, telefono, correo, es_principal) VALUES("jjj", "1111", "444", false);

call LISTAR_EMPLEADOS_POR_NOMBRE_DNI("");