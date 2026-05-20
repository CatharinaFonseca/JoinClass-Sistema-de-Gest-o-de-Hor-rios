using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.AtualizarGraduacao
{
    public class AtualizarGraduacaoUseCase : IAtualizarGraduacaoUseCase
    {
        private IGraduacaoRepositorio graduacaoRepositorio;

        public AtualizarGraduacaoUseCase(IGraduacaoRepositorio graduacaoRepositorio)
        {
            this.graduacaoRepositorio = graduacaoRepositorio;
        }

        public async Task AtualizarGraduacao(Graduacao graduacao)
        {
            await graduacaoRepositorio.Alterar(graduacao);
        }
    }
}