using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Services
{
    public class GerarHorariosService(List<Turma> turmas, List<Professor> professores)
    {
        private readonly List<DayOfWeek> diasDaSemana = new List<DayOfWeek>()
        {
            //DayOfWeek é um enum pronto do C# que representa os dias da semana
            //Determina os dias da semana
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday
        };
    }
}