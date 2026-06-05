-- 1. Criar o banco de dados
CREATE DATABASE "JoinClass";

--2. Tabela Pessoa
CREATE TABLE pessoa (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100)
);

--3. Tabela Coordenador
CREATE TABLE coordenador (
    id INT NOT NULL,
    CONSTRAINT pk_coordenador,
    PRIMARY KEY (id),
    CONSTRAINT fk_coordenadoor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 4. Tabela Graduacao
CREATE TABLE graduacao (
    id SERIAL PRIMARY KEY,
    nome_graduacao VARCHAR(100) NOT NULL,
    duracao_graduacao INT NOT NULL,
    qnt_aula_graduacao INT NOT NULL id_coordenador INT NOT NULL,
    CONSTRAINT fk_graduacao_coordenador FOREIGN KEY (id_coordenador) REFERENCES coordenador (id) ON DELETE CASCADE
);

-- 5. Tabela Disciplina
CREATE TABLE disciplina (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    carga_horaria int NOT NULL
);

-- 6. Tabela Aluno (herda de Pessoa - TPT)
CREATE TABLE aluno (
    id INT NOT NULL,
    CONSTRAINT pk_aluno PRIMARY KEY (id),
    CONSTRAINT fk_professor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 7. Tabela Professor
CREATE TABLE professor (
    id INT NOT NULL,
    CONSTRAINT pk_professor PRIMARY KEY (id),
    CONSTRAINT fk_professor_pessoa FOREIGN KEY (id) REFERENCES pessoa (id) ON DELETE CASCADE
);

-- 8. Tabela ProfessorDisciplina
CREATE TABLE professor_disciplina (
    id_professor INT NOT NULL,
    id_disciplina INT NOT NULL,
    CONSTRAINT pk_professor_disciplina PRIMARY KEY (id_professor, id_disciplina),
    CONSTRAINT fk_pd_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE,
    CONSTRAINT fk_pd_disciplina FOREIGN KEY (id_disciplina) REFERENCES disciplina (id) ON DELETE CASCADE
);

-- 9. Tabela Disponibilidade
CREATE TABLE disponibilidade (
    id SERIAL PRIMARY KEY,
    dia_semana VARCHAR(20) NOT NULL,
    horario_inicio VARCHAR(5) NOT NULL,
    horario_fim VARCHAR(5) NOT NULL,
    id_professor INT NOT NULL,
    CONSTRAINT fk_graduacao_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE
);

-- 10. Tabela Semestre
CREATE TABLE semestre (
    id SERIAL PRIMARY KEY,
    periodo VARCHAR(20) NOT NULL
);

-- 11. Tabela Matriz Curricular

CREATE TABLE matriz_curricular (
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
CREATE TABLE turma (
    id SERIAL PRIMARY KEY,
    id_professor INT NOT NULL,
    id_matriz_curricular_ INT NOT NULL,
    CONSTRAINT fk_turma_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE,
    CONSTRAINT fk_turma_matriz_curricular FOREIGN KEY (id_matriz_curricular) REFERENCES matriz_curricular (id) ON DELETE CASCADE
);

-- 13. Tabela Turma Aluno
CREATE TABLE turma_aluno (
    id_turma INT NOT NULL,
    id_aluno INT NOT NULL,
    CONSTRAINT pk_turma_aluno PRIMARY KEY (id_turma, id_aluno),
    CONSTRAINT fk_ta_turma FOREIGN KEY (id_turma) REFERENCES turma (id) ON DELETE CASCADE,
    CONSTRAINT fk_ta_aluno FOREIGN KEY (id_aluno) REFERENCES aluno (id) ON DELETE CASCADE
);

-- 14. Tabela Horario

CREATE TABLE horario (
    id SERIAL PRIMARY KEY,
    dia_semana VARCHAR(20) NOT NULL,
    horario_inicio VARCHAR(5) NOT NULL,
    horario_fim VARCHAR(5) NOT NULL,
    id_turma INT NOT NULL,
    CONSTRAINT fk_horario_turma FOREIGN KEY (id_turma) REFERENCES turma (id) ON DELETE CASCADE
);

-- 15. Tabela Titulacao
CREATE TABLE titulacao (
    id SERIAL PRIMARY KEY,
    tipo_titulacao VARCHAR(20) NOT NULL,
    id_professor INT NOT NULL,
    CONSTRAINT fk_titulacao_professor FOREIGN KEY (id_professor) REFERENCES professor (id) ON DELETE CASCADE
);