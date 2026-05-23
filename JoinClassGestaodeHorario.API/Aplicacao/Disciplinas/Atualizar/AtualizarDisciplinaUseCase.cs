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
            await disciplinaRepositorio.Alterar(disciplina);
        }
    }
}