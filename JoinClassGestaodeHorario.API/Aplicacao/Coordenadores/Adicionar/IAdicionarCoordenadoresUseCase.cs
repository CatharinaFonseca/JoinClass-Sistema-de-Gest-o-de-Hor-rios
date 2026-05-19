using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Adicionar
{
    public interface IAdicionarCoordenadoresUseCase
    {
        Task CadastrarCoordenador(Coordenador coordenador);
    }
}