using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Services
{
    public class GerarHorariosService
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

        // Validação dos horários cadastrados
        public void ValidarHorario(Horario horario)
        {
            // Dia da semana obrigatório
            if (string.IsNullOrWhiteSpace(horario.diaSemana))
            {
                throw new Exception("Dia da semana é obrigatório.");
            }

            // Horário inicial obrigatório
            if (string.IsNullOrWhiteSpace(horario.horarioInicio))
            {
                throw new Exception("Horário inicial é obrigatório.");
            }

            // Horário final obrigatório
            if (string.IsNullOrWhiteSpace(horario.horarioFim))
            {
                throw new Exception("Horário final é obrigatório.");
            }

            // Horário final deve ser maior que o inicial
            if (string.Compare(horario.horarioFim, horario.horarioInicio) <= 0)
            {
                throw new Exception(
                    "Horário final deve ser maior que o horário inicial.");
            }

            // Não permitir finais de semana
            if (!Enum.TryParse<DayOfWeek>(horario.diaSemana, true, out var dia))
            {
                throw new Exception("Dia da semana inválido.");
            }

            if (!diasDaSemana.Contains(dia))
            {
                throw new Exception(
                    "Não é permitido cadastrar aulas aos finais de semana.");
            }
        }
    }

}