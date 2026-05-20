using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Excluir
{
    public class ExcluirCoordenadorUseCase : IExcluirCoordenadorUseCase
    {
        private ICoordenadorRepositorio coordenadorRepositorio;

        public ExcluirCoordenadorUseCase(ICoordenadorRepositorio coordenadorRepositorio)
        {
            this.coordenadorRepositorio = coordenadorRepositorio;
        }

        public async Task ExcluirCoordenador(int id)
        {
            Coordenador coordenador = await coordenadorRepositorio.ObterCoordenador(id);
            await coordenadorRepositorio.Deletar(coordenador);
        }
    }
}