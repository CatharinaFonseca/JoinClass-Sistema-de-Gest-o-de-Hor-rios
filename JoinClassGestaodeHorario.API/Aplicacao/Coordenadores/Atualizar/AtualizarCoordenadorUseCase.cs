using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Atualizar
{
    public class AtualizarCoordenadorUseCase : IAtualizarCoordenadoresUseCase
    {
        private ICoordenadorRepositorio coordenadorRepositorio;

        public AtualizarCoordenadorUseCase(ICoordenadorRepositorio coordenadorRepositorio)
        {
            this.coordenadorRepositorio = coordenadorRepositorio;
        }

        public async Task AtualizarCoordenador(Coordenador coordenador)
        {
            await coordenadorRepositorio.Alterar(coordenador);
        }
    }
}