using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IGraduacaoRepositorio
    {
        Task Criar(Graduacao graduacao);

        Task Alterar(Graduacao graduacao);

        Task Deletar(Graduacao graduacao);
        Task<Graduacao> ObterGraduacao(int id);
        Task<List<Graduacao>> ObterTodasAsGraduacoes();
    }
}