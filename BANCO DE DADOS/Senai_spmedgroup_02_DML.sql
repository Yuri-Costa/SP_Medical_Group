---------DML--------

USE SP_MEDICAL_GROUP;

INSERT INTO Clinicas (Cnpj, Endereco, NomeFantasia, RazaoSocial)
VALUES				 ('86.400.902/0001-30', 'Av. Barão Limeira, 532, São Paulo, SP', 'Clinica Possarle', 'SP Medical Group'),
					 ('86.400.902/0001-30', 'Av. Barão Limeira, 532, São Paulo, SP', 'Clinica Possarle', 'SP Medical Group'),
					 ('86.400.902/0001-30', 'Av. Barão Limeira, 532, São Paulo, SP', 'Clinica Possarle', 'SP Medical Group')

INSERT INTO Especialidades (Especialidade)
VALUES						('Acupuntura'),
							('Anestesiologia'),
							('Angiologia'),
							('Cardiologia'),
							('Cirurgia Cardiovascular'),
							('Cirurgia da Mão'),
							('Cirurgia do Aparelho Digestivo'),
							('Cirurgia Geral'),
							('Cirurgia Pediátrica'),
							('Cirurgia Plástica'),
							('Cirurgia Torácica'),
							('Cirurgia Vascular'),
							('Dermatologia'),
							('Radioterapia'),
							('Urologia'),
							('Pediatria'),
							('Psiquiatria')

INSERT INTO Situacao(Situacao)
VALUES				('Agendada'),
					('Realizada'),
					('Cancelada')


INSERT INTO TipoUsuarios (TipoUsuario)
VALUES					('Paciente'),
						('Medico'),
						('Administrador')

INSERT INTO Usuarios (IdTipoUsuario, Email, Senha, DataNascimento, Rg, Telefone, Cpf, Endereco)
VALUES				 (1, 'ligia@gmail.com', 'G123', '19831013 10:34:09 AM', '435225435', 94567654, 94839859000, 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
					 (1, 'alexandre@gmail.com', 'U456','20010623 10:34:09 AM', '326543457', 987656543, 73556944057, 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
					 (1, 'fernando@gmail.com', 'I789', '19781010 00:00:00 AM', '546365253', 972084453, 16839338002, 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
					 (1, 'henrique@gmail.com', 'L135', '19851013 00:00:00 AM', '543663625', 934566543, 14332654765, 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
					 (1, 'joao@hotmail.com', 'H791', '19750827 00:00:00 AM', '432544444', 976566377, 91305348010, 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
					 (1, 'bruno@gmail.com', 'E246', '19720321 00:00:00 AM', '545662669', 954368769, 79799299004, 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
					 (1, 'mariana@outlook.com', 'R810', '20180503 00:00:00 AM', '545662668', 940038933, 13771913039, 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140'),
					 (2, 'ricardo.lemos@spmedicalgroup.com.br', 'M234','19781010 00:00:00 AM', '322543007', 987656543, 83556944057, 'Av. Paulista, 1578 - Bela paisagem, São Paulo - SP, 01310-200'),
					 (2, 'roberto.possarle@spmedicalgroup.com.br', 'E400', '19851030 00:00:00 AM', '241165253', 972084453, 56839338002, 'Av. Ibirapuera - são Pedro, 2927,  São Paulo - SP, 04029-200'),
					 (2, 'helena.souza@spmedicalgroup.com.br', 'Y142', '19750827 00:00:00 AM', '443662225', 40028922, 94332224765, 'R. Vitória, 120 - Av Sao Jorge, Itaquera - SP, 06402-030')

INSERT INTO Medicos (IdEspecialidade, IdUsuario, IdClinica, Nome, Crm)
VALUES				(2, 8, 1, 'Ricardo Lemos', 54356),
					(17, 9, 1, 'Roberto Possarle', 53452),
					(16, 10, 1, 'Helena Strada', 65463)

INSERT INTO Pacientes (IdUsuario, Nome, Rg, Telefone, Cpf, NumCartao )
VALUES				  (1, 'Ligia', '435225435', '934567654', '94839859', '40028922'),
					  (2,'Alexandre', '326543457', '987656543', '73556944', '51139033'),
					  (3,'Fernando', '546365253', '972084453', '16839338', '62241144'),
					  (4,'Henrique', '543663625', '934566543', '14332654', '73352255'),
					  (5, 'João', '4325444441', '976566377', '91305348', '84463366'),
					  (6, 'Bruno', '545662667', '954368769', '79799299', '95574477'),
					  (7, 'Mariana', '545662668', '962345678', '13771913', '34463366')

INSERT INTO Consultas (IdPaciente, IdMedico, IdSituacao, DataConsulta)
VALUES				  (7, 3, 2, '20200201 03:00:00 PM'),
					  (2, 2, 3, '20200602 10:00:00 AM'),
					  (3, 2, 2, '20200702 11:00:00 AM'),
					  (2, 2, 2, '20180602 10:00:00 AM'),
					  (4, 1, 3, '20190702 00:00:00 AM'),
					  (7, 3, 1, '20200803 03:00:00 PM'),
					  (4, 1, 1, '20200903 11:00:00 AM')


					  