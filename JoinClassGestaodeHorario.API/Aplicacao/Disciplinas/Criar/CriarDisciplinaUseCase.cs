using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Criar
{
    public class CriarDisciplinaUseCase : ICriarDisciplinaUseCase
    {
        private IDisciplinaRepositorio disciplinaRepositorio;

        public CriarDisciplinaUseCase(IDisciplinaRepositorio disciplinaRepositorio)
        {
            this.disciplinaRepositorio = disciplinaRepositorio;
        }

        public async Task CadastrarDisciplina(Disciplina disciplina)
        {
            await disciplinaRepositorio.Adicionar(disciplina);
        }
    }
}