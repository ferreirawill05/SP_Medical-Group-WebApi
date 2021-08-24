USE SPMED_GROUP;
GO

INSERT INTO Usuario(IdTipoUsuario, NomeUsuario, Email, Senha)
VALUES (3, 'Ligia', 'ligia@gmail.com', 'ligia@846'),
	   (3, 'Alexandre', 'alexandre@gmail.com', 'ale@84856'),
	   (3, 'Fernando', 'fernando@gmail.com', 'fezinho13'),
	   (3, 'Henrique', 'henrique@gmail.com', 'henri@467'),
	   (3, 'João', 'joao@hotmail.com', '974018462'),
	   (3, 'Bruno', 'bruno@gmail.com', 'nobruzera'),
	   (3, 'Mariana', 'mariana@outlook.com', 'maconta10'),
	   (2, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', 'ricardin9'),
	   (2, 'Roberto Hugo', 'roberto.hugo@spmedicalgroup.com.br', 'rob@87459'),
	   (2, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', 'heleninha');
GO

INSERT INTO Clinica(NomeFantasia, RazaoSocial, Endereco, Cnpj, HorarioAbertura, HorarioFechamento)
VALUES ('Clinica Possarle', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP', '86.400.902/0001-30', '10:00', '22:00');
GO

INSERT INTO Medico(IdUsuario, IdEspecialidade, IdClinica, Crmv)
VALUES (8, 2, 1, '54356-SP'),
	   (9, 17, 1, '53452-SP'),
	   (10, 16, 1, '65463-SP');
GO

INSERT INTO Paciente(IdUsuario, Telefone, DataNascimento, Endereco, Rg, Cpf)
VALUES (1, '11 3456-7654', '13/10/1983', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', '43522543-5', '94839859000'),
	   (2, '11 98765-6543', '23/07/2001', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200', '32654345-7', '73556944057'),
	   (3, '11 97208-4453', '10/10/1978', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', '54636525-3', '16839338002'),
	   (4, '11 3456-6543', '13/10/1985', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '54366362-5', '14332654765'),
	   (5, '11 7656-6377', '27/08/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', '53254444-1', '91305348010'),
	   (6, '11 95436-8769', '21/03/1972', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001', '54566266-7', '79799299004'),
	   (7, '', '05/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '54566266-8', '13771913039')
GO

INSERT INTO Consulta(IdMedico, IdPaciente, DataeHora, IdSituacao, Descricao)
VALUES (3, 7, '20/01/2020 15:00', 1, ''),
	   (2, 2, '06/01/2020 10:00', 2, ''),
	   (2, 3, '07/02/2020 11:00', 1, ''),
	   (2, 2, '06/02/2018 10:00', 1, ''),
	   (1, 4, '07/02/2019 11:00', 2, ''),
	   (3, 7, '08/03/2020 15:00', 3, ''),
	   (1, 4, '09/03/2020 11:00', 2, '')
GO