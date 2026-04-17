create database JoinClass;
use JoinClass;

create table professor (
	id_professor int auto_increment primary key,
	nome_professor varchar (100) not null,
	email_professor varchar (100) not null
);

create table disciplina (
	id_disciplina int auto_increment primary key,
	nome_disciplina varchar (100) not null,
	carg_horaria int
);

create table disponibilidade (
	id_disponibilidade int auto_increment primary key,
	dia_semana varchar (20) not null,
	horario_inicio varchar (5) not null,
	horario_fim varchar(5) not null,
	id_professor int,
	foreign key (id_professor) references professor(id_professor)
);

create table coordenador (
	id_coordenador int auto_increment primary key,
	nome_coordenador varchar (100) not null,
	email_coordenador varchar (100) not null
);

create table graduacao (
	id_graduacao int auto_increment primary key,
	nome_graduacao varchar (100) not null,
	duracao_graduacao int not null,
	qnt_aula_graduacao int not null,
	id_coordenador int,
	foreign key (id_coordenador) references coordenador(id_coordenador)
);

create table semestre (
	id_semestre int auto_increment primary key,
	periodo varchar (20) not null
);

create table matriz_curricular (
	id_matriz_curricular int auto_increment primary key,
	nome_matriz_curricular varchar (100) not null,
	id_graduacao int,
	foreign key (id_graduacao) references graduacao(id_graduacao),
	id_semestre int,
	foreign key (id_semestre) references semestre(id_semestre),
	id_disponibilidade int,
	foreign key (id_disponibilidade) references disponibilidade(id_disponibilidade)
);

create table turma (
	id_turma int auto_increment primary key,
	id_professor int,
	foreign key (id_professor) references professor(id_professor),
	id_matriz_curricular int,
	foreign key (id_matriz_curricular) references matriz_curricular(id_matriz_curricular)
);

create table aluno (
	id_aluno int auto_increment primary key,
	nome_aluno varchar (100) not null,
	email_aluno varchar (100) not null
);

create table turma_aluno (
	id_turma int,
	foreign key (id_turma) references turma(id_turma),
	id_aluno int,
	foreign key (id_aluno) references aluno(id_aluno)
); 

create table horario (
	id_horario int auto_increment primary key,
	dia_semana varchar (20) not null,
	horario_inicio varchar (5) not null,
	horario_fim varchar(5) not null,
	id_turma int,
	foreign key (id_turma) references turma(id_turma)
);

create table titulacao (
	id_titulacao int auto_increment primary key,
	tipo_titulacao varchar (20) not null,
	id_professor int,
	foreign key (id_professor) references professor(id_professor)
);

create table prof_disciplina (
	id_disciplina int,
	foreign key (id_disciplina) references disciplina(id_disciplina),
	id_professor int,
	foreign key (id_professor) references professor(id_professor)
);



