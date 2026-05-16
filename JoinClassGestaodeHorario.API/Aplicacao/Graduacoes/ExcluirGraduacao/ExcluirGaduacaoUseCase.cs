using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;

namespace JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao
{
    public class ExcluirGaduacaoUseCase : IExcluirGraduacao
    {
        private IGraduacaoRepositorio graduacaoRepositorio;

        public ExcluirGaduacaoUseCase(IGraduacaoRepositorio graduacaoRepositorio)
        {
            this.graduacaoRepositorio = graduacaoRepositorio;
        }

        public async Task ExcluirGraduacao(int id)
        {
            //Busca Graduacao
            Graduacao graduacao = await graduacaoRepositorio.ObterGraduacao(id);
            //Deleta Graduacao
            await graduacaoRepositorio.Deletar(graduacao);
        }
    }
}