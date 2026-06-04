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
            //Não permitir disciplina sem nome 
            if (string.IsNullOrWhiteSpace(disciplina.nome))
            {
                throw new Exception("Nome da disciplina é obrigatório.");
            }
            //Garantir carga horária positiva
            if (disciplina.cargaHoraria <= 0)
            {
                throw new Exception("Carga horária inválida.");
            }
            
            await disciplinaRepositorio.Adicionar(disciplina);
        }
    }
}