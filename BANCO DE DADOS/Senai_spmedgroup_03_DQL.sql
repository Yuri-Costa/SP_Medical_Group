---------DQL------
USE SP_MEDICAL_GROUP;

Select * FROM Clinicas;
Select * FROM Especialidades;
Select * FROM Medicos;
Select * FROM Pacientes;
Select * FROM Consultas;
Select * FROM Situacao;
Select * FROM TipoUsuarios;
Select * FROM Usuarios;
Select * FROM Pacientes;

Alter Table Clinicas Add HorarioAbertura TIME
Alter Table Clinicas Add HorarioFechamento TIME

UPDATE Clinicas
SET HorarioFechamento = '22:00:00'
WHERE Clinicas.IdClinica = 1  

UPDATE Clinicas
SET HorarioFechamento = '22:00:00'
WHERE Clinicas.IdClinica = 2

UPDATE Clinicas
SET HorarioFechamento = '22:00:00'
WHERE Clinicas.IdClinica = 3

UPDATE Clinicas
SET HorarioAbertura = '08:30:00'
WHERE Clinicas.IdClinica = 1  

UPDATE Clinicas
SET HorarioAbertura = '08:30:00'
WHERE Clinicas.IdClinica = 2

UPDATE Clinicas
SET HorarioAbertura = '08:30:00'
WHERE Clinicas.IdClinica = 3


--------------------------------------------------------------

---- AQUI O ADMINISTRADOR MOSTRA OS DADOS DA CLINICA  ----

Select * FROM Clinicas;

--------------------------------------------------------------
----------------------------LOGIN BASICO-----------------------------------------------;
SELECT Email AS Email, Senha AS Senhas FROM Usuarios
INNER JOIN TipoUsuarios
ON Usuarios.idTipoUsuario = TipoUsuarios.idTipoUsuario
WHERE email = 'fernando@gmail.com' AND senha = 'I789';

----AQUI ESTÁ TODAS AS CONSULTAS COM NOMES DOS PACIENTES------

Select IdConsulta, Pacientes.IdPaciente, Pacientes.Nome AS NomePaciente, Medicos.Nome, Especialidades.Especialidade, IdSituacao, DataConsulta from Consultas
INNER JOIN Pacientes
ON Pacientes.IdPaciente = Consultas.IdPaciente
INNER JOIN Medicos
ON Consultas.IdMedico = Medicos.IdMedico
INNER JOIN Especialidades
ON Medicos.IdEspecialidade = Especialidades.IdEspecialidade

--------------------------------------------------------------

---- AQUI O PACIENTE ALEXANDRE CONSEGUE VER APENAS A SUAS CONSULTAS ----

Select IdConsulta, Pacientes.IdPaciente, Pacientes.Nome AS NomePAciente, Medicos.Nome, Especialidades.Especialidade, IdSituacao, DataConsulta from Consultas
INNER JOIN Pacientes
ON Pacientes.IdPaciente = Consultas.IdPaciente
INNER JOIN Medicos
ON Consultas.IdMedico = Medicos.IdMedico
INNER JOIN Especialidades
ON Medicos.IdEspecialidade = Especialidades.IdEspecialidade
Where Pacientes.Nome = 'Alexandre'

-------------------------------------------------------------------------

---- AQUI O PACIENTE FERNANDO CONSEGUE VER APENAS A SUAS CONSULTAS ----
Select IdConsulta, Pacientes.IdPaciente, Pacientes.Nome AS NomePAciente, Medicos.Nome, Especialidades.Especialidade, IdSituacao, DataConsulta from Consultas
INNER JOIN Pacientes
ON Pacientes.IdPaciente = Consultas.IdPaciente
INNER JOIN Medicos
ON Consultas.IdMedico = Medicos.IdMedico
INNER JOIN Especialidades
ON Medicos.IdEspecialidade = Especialidades.IdEspecialidade
Where Pacientes.Nome = 'Fernando'

-------------------------------------------------------------------------

---- AQUI O PACIENTE HENRIQUE CONSEGUE VER APENAS A SUAS CONSULTAS ----
Select IdConsulta, Pacientes.IdPaciente, Pacientes.Nome AS NomePaciente, Medicos.Nome, Especialidades.Especialidade, IdSituacao, DataConsulta from Consultas
INNER JOIN Pacientes
ON Pacientes.IdPaciente = Consultas.IdPaciente
INNER JOIN Medicos
ON Consultas.IdMedico = Medicos.IdMedico
INNER JOIN Especialidades
ON Medicos.IdEspecialidade = Especialidades.IdEspecialidade
Where Pacientes.Nome = 'Henrique'

... (82 linhas)



