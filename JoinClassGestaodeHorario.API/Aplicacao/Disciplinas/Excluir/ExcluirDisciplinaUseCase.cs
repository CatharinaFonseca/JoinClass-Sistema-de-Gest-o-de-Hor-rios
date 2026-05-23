using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Excluir
{
    public class ExcluirDisciplinaUseCase : IExcluirDisciplinaUseCase
    {
        private IDisciplinaRepositorio disciplinaRepositorio;

        public ExcluirDisciplinaUseCase(IDisciplinaRepositorio disciplinaRepositorio)
        {
            this.disciplinaRepositorio = disciplinaRepositorio;
        }

        public async Task ExcluirDisciplina(int id)
        {
            Disciplina disciplina = await disciplinaRepositorio.ObterDisciplina(id);
            await disciplinaRepositorio.Deletar(disciplina);
        }
    }
}