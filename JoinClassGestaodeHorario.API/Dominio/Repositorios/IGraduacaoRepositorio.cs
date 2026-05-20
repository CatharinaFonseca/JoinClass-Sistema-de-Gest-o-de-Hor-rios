using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using JoinClassGestaodeHorario.API.Dominio.Entidade;
>>>>>>> a4d2bb56cac098b3eaf581cd52b32dde03a60178

namespace JoinClassGestaodeHorario.API.Dominio.Repositorios
{
    public interface IGraduacaoRepositorio
    {
<<<<<<< HEAD
        
=======
        Task Criar(Graduacao graduacao);
        
        Task Alterar(Graduacao graduacao);

        Task Deletar(Graduacao graduacao);
        Task <Graduacao> ObterGraduacao(int id);
        Task<List<Graduacao>> ObterTodasAsGraduacoes();
>>>>>>> a4d2bb56cac098b3eaf581cd52b32dde03a60178
    }
}