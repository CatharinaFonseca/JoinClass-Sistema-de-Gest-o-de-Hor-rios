using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar
{
    public interface IAtualizarHorarioUseCase
    {
        Task AtualizarHorario(Horario horario);
    }
}