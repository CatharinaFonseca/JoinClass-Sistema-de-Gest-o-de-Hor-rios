using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Atualizar
{
    public class AtualizarDisciplinaUseCase : IAtualizarDisciplinaUseCase
    {
        private IDisciplinaRepositorio disciplinaRepositorio;

        public AtualizarDisciplinaUseCase(IDisciplinaRepositorio disciplinaRepositorio)
        {
            this.disciplinaRepositorio = disciplinaRepositorio;
        }

        public async Task AtualizarDisciplina(Disciplina disciplina)
        {
            //Não permitir disciplina sem nome 
            if (string.IsNullOrWhiteSpace(disciplina.nome))
            {
                throw new Exception("Nome da disciplina é obrigatório.");
            }
            //Garantir carga horária positiva
            if (disciplina.carga_horaria <= 0)
            {
                throw new Exception("Carga horária inválida.");
            }
            await disciplinaRepositorio.Alterar(disciplina);
        }
    }
}