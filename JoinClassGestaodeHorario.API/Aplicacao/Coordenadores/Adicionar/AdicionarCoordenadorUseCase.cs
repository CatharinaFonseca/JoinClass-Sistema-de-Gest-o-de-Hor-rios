using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Adicionar
{
    public class AdicionarCoordenadorUseCase : IAdicionarCoordenadoresUseCase
    {
        private ICoordenadorRepositorio coordenadorRepositorio;

        public AdicionarCoordenadorUseCase(ICoordenadorRepositorio coordenadorRepositorio)
        {
            this.coordenadorRepositorio = coordenadorRepositorio;
        }

        public async Task CadastrarCoordenador(Coordenador coordenador)
        {
            await coordenadorRepositorio.Adicionar(coordenador);
        }
    }
}