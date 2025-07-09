-- Creacion de registros de prueba

-- 3 Pacientes
INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES
('María Fernández', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'maria.fernandez@gmail.com', 'Paciente'),
('José Martínez', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'jose.martinez@gmail.com', 'Paciente'),
('Lucía Vega', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'lucia.vega@gmail.com', 'Paciente');

-- 5 Doctores
INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES
('Andrés Solano', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'andres.solano@clinicacr.com', 'Doctor'),
('Carolina Mora', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'carolina.mora@clinicacr.com', 'Doctor'),
('Felipe Castro', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'felipe.castro@clinicacr.com', 'Doctor'),
('Natalia Rojas', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'natalia.rojas@clinicacr.com', 'Doctor'),
('Esteban Núñez', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'esteban.nunez@clinicacr.com', 'Doctor');

-- 2 Secretarias
INSERT INTO usuarios (nombre, password, correo, tipo_usuario) VALUES
('Laura Brenes', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'laura.brenes@clinicacr.com', 'Secretaria'),
('Camila Jiménez', '148685dc72fe8d3e6b22cbfa971ecc5b883424209b640db0e53109f0fa55d756', 'camila.jimenez@clinicacr.com', 'Secretaria');


-- TABLA PERSONAS

-- Persona asociada a María Fernández
INSERT INTO persona (
    identificacion,
    nombre_completo,
    apellido,
    direccion,
    telefono,
    correo,
    edad,
    sexo,
    fecha_nacimiento,
    tipo_sangre,
    contacto_emergencia,
    usuarios_idusuarios
) VALUES (
    '109250123',
    'María',
    'Fernández Ramírez',
    'Barrio Escalante, San José',
    '8888-0001',
    'maria.fernandez@gmail.com',
    '28',
    'Femenino',
    '1997-05-12',
    'A+',
    'Luis Ramírez - 8888-7771',
    1 -- ID del usuario correspondiente a María
);

-- Persona asociada a José Martínez
INSERT INTO persona (
    identificacion,
    nombre_completo,
    apellido,
    direccion,
    telefono,
    correo,
    edad,
    sexo,
    fecha_nacimiento,
    tipo_sangre,
    contacto_emergencia,
    usuarios_idusuarios
) VALUES (
    '110150456',
    'José',
    'Martínez Quesada',
    'Cartago centro',
    '8888-0002',
    'jose.martinez@gmail.com',
    '35',
    'Masculino',
    '1989-03-22',
    'O+',
    'Ana Quesada - 8888-7772',
    2 -- ID del usuario correspondiente a José
);

-- Persona asociada a Lucía Vega
INSERT INTO persona (
    identificacion,
    nombre_completo,
    apellido,
    direccion,
    telefono,
    correo,
    edad,
    sexo,
    fecha_nacimiento,
    tipo_sangre,
    contacto_emergencia,
    usuarios_idusuarios
) VALUES (
    '208430789',
    'Lucía',
    'Vega Hernández',
    'Heredia, San Francisco',
    '8888-0003',
    'lucia.vega@gmail.com',
    '30',
    'Femenino',
    '1994-08-09',
    'B+',
    'Gabriela Hernández - 8888-7773',
    3 -- ID del usuario correspondiente a Lucía
);

-- TABLA DOCTOR
INSERT INTO doctor (
    identificacion, nombre_completo, apellido, direccion, telefono,
    correo, edad, sexo, usuarios_idusuarios
) VALUES
('1-1234-5678', 'Andrés', 'Solano', 'San José, Costa Rica', '8898-1001', 'andres.solano@gmail.com', '40', 'Masculino', 7),
('2-2345-6789', 'Carolina', 'Mora', 'Cartago, Costa Rica', '8825-0200', 'carolina.mora@hotmail.com', '35', 'Femenino', 8),
('3-3456-7890', 'Felipe', 'Castro', 'Heredia, Costa Rica', '8845-2003', 'felipe.castro@gmail.com', '42', 'Masculino', 9),
('4-4567-8901', 'Natalia', 'Rojas', 'Alajuela, Costa Rica', '8860-1004', 'natalia.rojas@yahoo.es', '38', 'Femenino', 10),
('5-5678-9012', 'Esteban', 'Núñez', 'Puntarenas, Costa Rica', '8878-4005', 'esteban.nunez@hotmail.com', '45', 'Masculino', 11);

-- CREA ESPECIALIDADES
INSERT INTO especialidad (id, descripcion) VALUES
(1, 'Cardiología'),
(3, 'Ginecología'),
(4, 'Pediatría'),
(5, 'Urología'),
(6, 'Ortopedia');

-- ASOCIA ESPECIALIDAD CON LOS DOCTORES
INSERT INTO doctor_especialidad (doctor_id, especialidad_id) VALUES
(1, 1),  -- Andrés Solano → Cardiología
(2, 3),  -- Carolina Mora → Ginecología
(3, 4),  -- Felipe Castro → Pediatría
(4, 5),  -- Natalia Rojas → Urología
(5, 6);  -- Esteban Núñez → Ortopedia

-- Vistas
CREATE VIEW `vDoctor`
AS
SELECT
	doctor.id AS ID,
	doctor.nombre_completo AS NOMBRE,	
	doctor.apellido AS APELLIDOS,
    doctor.identificacion AS IDENTIFICACION,
    doctor.direccion AS DIRECCION,
    doctor.telefono AS TELEFONO,
    doctor.correo AS CORREO_PERSONAL,
    usuarios.correo AS USUARIO,
    especialidad.descripcion AS ESPECIALIDAD      
 FROM db_clinica.doctor
 INNER JOIN usuarios ON doctor.usuarios_idusuarios = usuarios.idusuarios
 INNER JOIN doctor_especialidad ON doctor.id = doctor_especialidad.doctor_id
 INNER JOIN especialidad ON doctor_especialidad.especialidad_id = especialidad.id;

CREATE VIEW `vPacienteSecretaria` AS
SELECT 
	persona.id AS ID,
	nombre_completo AS NOMBRE,
    apellido AS APELLIDO,
    identificacion AS CEDULA,
    telefono AS TELEFONO,
    persona.correo AS CORREO_ELECTRONICO,
    edad AS EDAD,
    sexo AS GENERO,
    usuarios.correo AS USUARIO
FROM db_clinica.persona
INNER JOIN usuarios ON persona.usuarios_idusuarios = usuarios.idusuarios;


CREATE VIEW `vDoctorSecretaria`
AS
SELECT
	doctor.id AS ID,
	doctor.nombre_completo 'NOMBRE',	
	doctor.apellido 'APELLIDOS',
    especialidad.descripcion 'ESPECIALIDAD'      
 FROM db_clinica.doctor
 INNER JOIN doctor_especialidad ON doctor.id = doctor_especialidad.doctor_id
 INNER JOIN especialidad ON doctor_especialidad.especialidad_id = especialidad.id;
 
CREATE VIEW `vPaciente` AS
SELECT 
	persona.id AS ID,
	nombre_completo AS NOMBRE,
    apellido AS APELLIDO,
    identificacion AS CEDULA,
    telefono AS TELEFONO,
    usuarios.correo AS USUARIO,
    (Select count(0) from db_clinica.consulta where consulta.persona_id = persona.id) AS CANT_CONSULTAS
FROM db_clinica.persona
INNER JOIN usuarios ON persona.usuarios_idusuarios = usuarios.idusuarios;


CREATE VIEW `vPacienteConsultas` AS
SELECT 
	consulta.id AS ID,
	numero AS CONSECUTIVO,
    fecha AS FECHA_CONSULTA,
    doctor.nombre_completo + doctor.apellido AS DOCTOR,
    especialidad.descripcion AS ESPECIALIDAD
FROM db_clinica.consulta
INNER JOIN doctor ON doctor.id = consulta.doctor_id
INNER JOIN doctor_especialidad ON doctor.id = doctor_especialidad.doctor_id
INNER JOIN especialidad ON doctor_especialidad.especialidad_id = especialidad.id;


CREATE VIEW `vUsuarios` AS
select
	idusuarios AS ID,
	nombre AS NOMBRE_USUARIO,
    correo AS CODIGO_USUARIO,
    tipo_usuario AS TIPO_USUARIO
from usuarios;