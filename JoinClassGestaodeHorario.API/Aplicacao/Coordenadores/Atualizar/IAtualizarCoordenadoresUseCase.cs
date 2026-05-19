using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Atualizar
{
    public interface IAtualizarCoordenadoresUseCase
    {
        Task AtualizarCoordenador(Coordenador coordenador);
    }
}