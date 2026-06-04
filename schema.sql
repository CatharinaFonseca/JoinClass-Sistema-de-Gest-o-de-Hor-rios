-- 1. Criar o banco de dados
<<<<<<< HEAD
CREATE DATABASE "JoinClass";

--2. Tabela Pessoa
CREATE TABLE pessoa (
=======
CREATE DATABASE JoinClass;

--2. Tabela Pessoa
CREATE TABLE Pessoa (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100)
);

--3. Tabela Coordenador
<<<<<<< HEAD
CREATE TABLE coordenador (
    id INT NOT NULL,
    CONSTRAINT pk_coordenador,
    PRIMARY KEY (id),
=======
CREATE TABLE Coordenador (
    id INT NOT NULL,
    CONSTRAINT pk_coordenador PRIMARY KEY (id),
>>>>>>> feature/Gabriela
    CONSTRAINT fk_coordenadoor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 4. Tabela Graduacao

<<<<<<< HEAD
CREATE TABLE graduacao (
    id SERIAL PRIMARY KEY,
    nome_graduacao VARCHAR(100) NOT NULL,
    duracao_graduacao INT NOT NULL,
    qnt_aula_graduacao INT NOT NULL id_coordenador INT NOT NULL,
=======
CREATE TABLE Graduacao (
    id SERIAL PRIMARY KEY,
    nome_graduacao VARCHAR(100) NOT NULL,
    duracao_graduacao INT NOT NULL,
    qnt_aula_graduacao INT NOT NULL,
    id_coordenador INT NOT NULL,
>>>>>>> feature/Gabriela
    CONSTRAINT fk_graduacao_coordenador FOREIGN KEY (id_coordenador) REFERENCES coordenador (id) ON DELETE CASCADE
);

-- 5. Tabela Disciplina

<<<<<<< HEAD
CREATE TABLE disciplina (
=======
CREATE TABLE Disciplina (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    carg_horaria int NOT NULL
);

-- 6. Tabela Aluno (herda de Pessoa - TPT)

<<<<<<< HEAD
CREATE TABLE aluno (
=======
CREATE TABLE Aluno (
>>>>>>> feature/Gabriela
    id INT NOT NULL,
    CONSTRAINT pk_aluno PRIMARY KEY (id),
    CONSTRAINT fk_professor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 7. Tabela Professor

<<<<<<< HEAD
CREATE TABLE professor (
=======
CREATE TABLE Professor (
>>>>>>> feature/Gabriela
    id INT NOT NULL,
    CONSTRAINT pk_professor PRIMARY KEY (id),
    CONSTRAINT fk_professor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 8. Tabela ProfessorDisciplina
<<<<<<< HEAD
CREATE TABLE professor_disciplina (
=======
CREATE TABLE Professor_Disciplina (
>>>>>>> feature/Gabriela
    id_professor INT NOT NULL,
    id_disciplina INT NOT NULL,
    CONSTRAINT pk_professor_disciplina PRIMARY KEY (id_professor, id_disciplina),
    CONSTRAINT fk_pd_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE,
    CONSTRAINT fk_pd_disciplina FOREIGN KEY (id_disciplina) REFERENCES disciplina (id) ON DELETE CASCADE
);

-- 9. Tabela Disponibilidade

<<<<<<< HEAD
CREATE TABLE disponibilidade (
=======
CREATE TABLE Disponibilidade (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    dia_semana VARCHAR(20) NOT NULL,
    horario_inicio VARCHAR(5) NOT NULL,
    horario_fim VARCHAR(5) NOT NULL,
    id_professor INT NOT NULL,
    CONSTRAINT fk_graduacao_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE
);

-- 10. Tabela Semestre

<<<<<<< HEAD
CREATE TABLE semestre (
=======
CREATE TABLE Semestre (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    periodo VARCHAR(20) NOT NULL
);

-- 11. Tabela Matriz Curricular

<<<<<<< HEAD
CREATE TABLE matriz_curricular (
=======
CREATE TABLE Matriz_curricular (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    nome_matriz_curricular VARCHAR(100) NOT NULL,
    id_graduacao INT NOT NULL,
    id_semestre INT NOT NULL,
    id_disponibilidade INT NOT NULL,
    CONSTRAINT fk_matriz_curricular_graduacao FOREIGN KEY (id_graduacao) REFERENCES graduacao (id) ON DELETE CASCADE,
    CONSTRAINT fk_matriz_curricular_semestre FOREIGN KEY (id_semestre) REFERENCES semestre (id) ON DELETE CASCADE,
    CONSTRAINT fk_matriz_curricular_disponibilidade FOREIGN KEY (id_disponibilidade) REFERENCES disponibilidade (id) ON DELETE CASCADE
);

-- 12. Tabela Turma

<<<<<<< HEAD
CREATE TABLE turma (
    id SERIAL PRIMARY KEY,
    id_professor INT NOT NULL,
    id_matriz_curricular_ INT NOT NULL,
    CONSTRAINT fk_turma_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE,
    CONSTRAINT fk_turma_matriz_curricular FOREIGN KEY (id_matriz_curricular) REFERENCES matriz_curricular (id) ON DELETE CASCADE
=======
CREATE TABLE Turma (
    id SERIAL PRIMARY KEY,
    id_professor INT NOT NULL,
    id_matriz_curricular INT NOT NULL,
    CONSTRAINT fk_turma_professor FOREIGN KEY (id_professor) REFERENCES Professor (id) ON DELETE CASCADE,
    CONSTRAINT fk_turma_matriz_curricular FOREIGN KEY (id_matriz_curricular) REFERENCES Matriz_curricular (id) ON DELETE CASCADE
>>>>>>> feature/Gabriela
);

-- 13. Tabela Turma Aluno

<<<<<<< HEAD
CREATE TABLE turma_aluno (
=======
CREATE TABLE Turma_Aluno (
>>>>>>> feature/Gabriela
    id_turma INT NOT NULL,
    id_aluno INT NOT NULL,
    CONSTRAINT pk_turma_aluno PRIMARY KEY (id_turma, id_aluno),
    CONSTRAINT fk_ta_turma FOREIGN KEY (id_turma) REFERENCES turma (id) ON DELETE CASCADE,
    CONSTRAINT fk_ta_aluno FOREIGN KEY (id_aluno) REFERENCES aluno (id) ON DELETE CASCADE
);

-- 14. Tabela Horario

<<<<<<< HEAD
CREATE TABLE horario (
=======
CREATE TABLE Horario (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    dia_semana VARCHAR(20) NOT NULL,
    horario_inicio VARCHAR(5) NOT NULL,
    horario_fim VARCHAR(5) NOT NULL,
    id_turma INT NOT NULL,
    CONSTRAINT fk_horario_turma FOREIGN KEY (id_turma) REFERENCES turma (id) ON DELETE CASCADE
);

-- 15. Tabela Titulacao

<<<<<<< HEAD
CREATE TABLE titulacao (
=======
CREATE TABLE Titulacao (
>>>>>>> feature/Gabriela
    id SERIAL PRIMARY KEY,
    tipo_titulacao VARCHAR(20) NOT NULL,
    id_professor INT NOT NULL,
    CONSTRAINT fk_titulacao_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE
);