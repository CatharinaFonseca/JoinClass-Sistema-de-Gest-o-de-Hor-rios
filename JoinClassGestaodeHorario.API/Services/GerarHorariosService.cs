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
            if (string.IsNullOrWhiteSpace(horario.dia_semana))
            {
                throw new Exception("Dia da semana é obrigatório.");
            }

            // Horário inicial obrigatório
            if (string.IsNullOrWhiteSpace(horario.horario_inicio))
            {
                throw new Exception("Horário inicial é obrigatório.");
            }

            // Horário final obrigatório
            if (string.IsNullOrWhiteSpace(horario.horario_fim))
            {
                throw new Exception("Horário final é obrigatório.");
            }

            // Horário final deve ser maior que o inicial
            if (string.Compare(horario.horario_fim, horario.horario_inicio) <= 0)
            {
                throw new Exception(
                    "Horário final deve ser maior que o horário inicial.");
            }

            // Não permitir finais de semana
            if (!Enum.TryParse<DayOfWeek>(horario.dia_semana, true, out var dia))
            {
                throw new Exception("Dia da semana inválido.");
            }

            if (!diasDaSemana.Contains(dia))
            {
                throw new Exception(
                    "Não é permitido cadastrar aulas aos finais de semana.");
            }
        }

        public List<Horario> GerarHorario(int idTurma, List<Disciplina> disciplinas)
        {
            var horarios = new List<Horario>();

            int diaIndex = 0;
            string horaInicio = "19:00";

            foreach (var disciplina in disciplinas)
            {
                var horario = new Horario
                {
                    dia_semana = diasDaSemana[diaIndex].ToString(),
                    horario_inicio = horaInicio,
                    horario_fim = SomarHoras(horaInicio, 2),
                    id_turma = idTurma
                };

                ValidarHorario(horario);

                horarios.Add(horario);

                // próxima aula
                horaInicio = horario.horario_fim;

                // troca dia se passar limite
                if (horaInicio == "22:30")
                {
                    diaIndex++;
                    horaInicio = "19:00";
                }
            }

            return horarios;
        }

        private string SomarHoras(string hora, int horas)
        {
            var h = TimeSpan.Parse(hora);
            return h.Add(TimeSpan.FromHours(horas)).ToString(@"hh\:mm");
        }
    }

}
