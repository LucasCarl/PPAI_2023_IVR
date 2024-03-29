USE [PPAI_IVS_DB]

/* Acciones */
INSERT INTO Acciones (id_accion, nombre) VALUES (0, 'Accion 1')
INSERT INTO Acciones (id_accion, nombre) VALUES (1, 'Accion 2')
INSERT INTO Acciones (id_accion, nombre) VALUES (2, 'Accion 3')
INSERT INTO Acciones (id_accion, nombre) VALUES (3, 'Accion 4')
INSERT INTO Acciones (id_accion, nombre) VALUES (4, 'Accion 5')

/* Validaciones */
INSERT INTO Validaciones (id_validacion, nombre, orden) VALUES (0, 'Fecha', 1)
INSERT INTO Validaciones (id_validacion, nombre, orden) VALUES (1, 'Hijos', 2)
INSERT INTO Validaciones (id_validacion, nombre, orden) VALUES (2, 'Codigo Postal', 3)

/* Categorias */
INSERT INTO Categorias (id_categoria, nombre, orden) VALUES (0, 'Robo', 1)
INSERT INTO Categorias (id_categoria, nombre, orden) VALUES (1, 'Bloqueo', 2)
INSERT INTO Categorias (id_categoria, nombre, orden) VALUES (2, 'Nueva Tarjeta', 3)

/* Opciones */
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (0, 0, 'Nueva tarjeta', 1)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (0, 1, 'Anular tarjeta', 2)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (1, 2, 'Conoce motivo bloqueo', 1)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (1, 3, 'Desconoce motivo bloqueo', 2)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (2, 4, 'Op 1', 1)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (2, 5, 'Op 2', 2)
INSERT INTO Opciones (id_categoria, id_opcion, nombre, orden) VALUES (2, 6, 'Op 3', 3)

/* Subopciones */
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (0, 0, 'Cuenta con los datos', 1)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (1, 0, 'No cuenta con los datos', 2)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (2, 0, 'Desea comunicarse con responsable', 3)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (3, 1, 'Cuenta con los datos', 1)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (4, 1, 'No cuenta con los datos', 2)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (5, 1, 'Desea comunicarse con responsable', 3)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (6, 3, 'Informar motivo de bloqueo', 1)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (7, 3, 'Desea comunicarse con responsable', 2)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (8, 4, 'SubOp 1', 1)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (9, 4, 'SubOp 2', 2)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (10, 4, 'SubOp 3', 3)
INSERT INTO Subopciones (id_subopcion, id_opcion, nombre, orden) VALUES (11, 4, 'SubOp 4', 4)

/* Clientes */
INSERT INTO Clientes (dni, nombre, celular) VALUES (35485155, 'Ernesto Lopez', 3512648978)
INSERT INTO Clientes (dni, nombre, celular) VALUES (42586684, 'Norberto Diaz', 3513698741)
INSERT INTO Clientes (dni, nombre, celular) VALUES (42678364, 'Ramon Ramirez', 3512548456)

/* Informacion Clientes */
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (35485155, 0, '3/5/1985')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (35485155, 1, '0')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (35485155, 2, '5012')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42586684, 0, '13/7/1968')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42586684, 1, '1')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42586684, 2, '5000')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42678364, 0, '25/10/1973')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42678364, 1, '3')
INSERT INTO [Informaciones Clientes] (dni_cliente, id_validacion, dato) VALUES (42678364, 2, '5004')

/* Validaciones x Opcion */
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (2, 0)
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (2, 2)
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (5, 2)
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (6, 0)
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (6, 1)
INSERT INTO [Validaciones X Opcion] (id_opcion, id_validacion) VALUES (6, 2)

/* Validaciones x Subopcion */
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (0, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (0, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (1, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (1, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (2, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (2, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (3, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (3, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (4, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (4, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (5, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (5, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (6, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (7, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (7, 2)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (8, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (9, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (10, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (10, 2)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (11, 0)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (11, 1)
INSERT INTO [Validaciones X Subopcion] (id_subopcion, id_validacion) VALUES (11, 2)

/* Estados */
INSERT INTO Estados (id_estado, nombre) VALUES (0, 'Iniciada')
INSERT INTO Estados (id_estado, nombre) VALUES (1, 'EnCurso')
INSERT INTO Estados (id_estado, nombre) VALUES (2, 'Finalizada')
INSERT INTO Estados (id_estado, nombre) VALUES (3, 'Cancelada')