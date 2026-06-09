using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dados;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Services
{
    public class GerarHorariosService
    {
        // Alterado para strings em português para casar perfeitamente com o seu banco e front-end
        private readonly List<string> diasDaSemanaPTBR = new List<string>()
        {
            "Segunda-feira",
            "Terça-feira",
            "Quarta-feira",
            "Quinta-feira",
            "Sexta-feira"
        };

        // Validação dos horários cadastrados
        public void ValidarHorario(Horario horario)
        {
            if (string.IsNullOrWhiteSpace(horario.dia_semana))
            {
                throw new Exception("Dia da semana é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(horario.horario_inicio))
            {
                throw new Exception("Horário inicial é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(horario.horario_fim))
            {
                throw new Exception("Horário final é obrigatório.");
            }

            if (string.Compare(horario.horario_fim, horario.horario_inicio) <= 0)
            {
                throw new Exception("Horário final deve ser maior que o horário inicial.");
            }

            // Valida se o dia enviado está na nossa lista permitida em português
            if (!diasDaSemanaPTBR.Any(d => d.Equals(horario.dia_semana, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Dia da semana inválido ou não é permitido cadastrar aulas aos finais de semana.");
            }
        }

        private readonly ApplicationDbContext _contexto;

        public GerarHorariosService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Horario>> GerarHorarioAutomatico(int idTurma, List<int> idsDisciplinas)
        {
            var horarios = new List<Horario>();
            int diaIndex = 0;

            foreach (var idDisciplina in idsDisciplinas)
            {
                var vinculoProfessor = await _contexto.ProfessorDisciplinas
                    .Where(pd => pd.id_disciplina == idDisciplina)
                    .FirstOrDefaultAsync();

                if (vinculoProfessor == null)
                {
                    throw new Exception($"Não existe nenhum professor cadastrado para a disciplina ID {idDisciplina}");
                }

                // TURNO 1: Bate certinho com o ID "Dia-19:00" do seu HTML
                var horarioTurno1 = new Horario
                {
                    dia_semana = diasDaSemanaPTBR[diaIndex],
                    horario_inicio = "19:00",
                    horario_fim = "20:40",
                    id_turma = idTurma,
                    id_disciplina = idDisciplina,
                    id_professor = vinculoProfessor.id_professor
                };
                ValidarHorario(horarioTurno1);
                horarios.Add(horarioTurno1);

                // TURNO 2: Bate certinho com o ID "Dia-20:50" do seu HTML
                var horarioTurno2 = new Horario
                {
                    dia_semana = diasDaSemanaPTBR[diaIndex], // MESMO DIA
                    horario_inicio = "20:50",
                    horario_fim = "22:30",
                    id_turma = idTurma,
                    id_disciplina = idDisciplina,
                    id_professor = vinculoProfessor.id_professor
                };
                ValidarHorario(horarioTurno2);
                horarios.Add(horarioTurno2);

                // Só avança o dia depois de criar os dois turnos para a mesma matéria
                diaIndex++;
                if (diaIndex >= diasDaSemanaPTBR.Count) diaIndex = 0;
            }

            await _contexto.Horarios.AddRangeAsync(horarios);
            await _contexto.SaveChangesAsync();

            return horarios;
        }

        private string SomarHoras(string hora, double horas)
        {
            var h = TimeSpan.Parse(hora);
            return h.Add(TimeSpan.FromHours(horas)).ToString(@"hh\:mm");
        }
    }
}