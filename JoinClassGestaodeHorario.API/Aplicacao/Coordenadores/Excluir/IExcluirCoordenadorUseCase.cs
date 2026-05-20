using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Excluir
{
    public interface IExcluirCoordenadorUseCase
    {
        Task ExcluirCoordenador(int id);
    }
}