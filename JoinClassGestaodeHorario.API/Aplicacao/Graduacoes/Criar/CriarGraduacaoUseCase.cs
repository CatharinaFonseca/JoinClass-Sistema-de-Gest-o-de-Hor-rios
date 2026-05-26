using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.Criar
{
    public class CriarGraduacaoUseCase : ICriarGraduacaoUseCase
    {
        private IGraduacaoRepositorio graduacaoRepositorio;

        public CriarGraduacaoUseCase(IGraduacaoRepositorio graduacaoRepositorio)
        {
            this.graduacaoRepositorio = graduacaoRepositorio;
        }

        public async Task CadastrarGraduacao(Graduacao graduacao)
        {
            await graduacaoRepositorio.Criar(graduacao);
        }
    }
}