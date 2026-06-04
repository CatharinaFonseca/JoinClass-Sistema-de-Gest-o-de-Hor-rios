using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Services
{
    public class GerarHorariosService
    {
        private readonly List<Turma> _turmas;
        private readonly List<Professor> _professores;
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

        // Recebe todas as turmas e professores cadastrados
        public GerarHorariosService(
            List<Turma> turmas,
            List<Professor> professores)
        {
            _turmas = turmas;
            _professores = professores;
        }

        // Método principal responsável por validar todos os dados
        public void ValidarDados()
        {
            foreach (var turma in _turmas)
            {
                // Valida as informações da turma
                ValidarTurma(turma);

                // Percorre todos os horários da turma
                foreach (var horario in turma.Horarios)
                {
                    // Valida o horário
                    ValidarHorario(horario);

                    // Um professor não pode ter duas aulas no mesmo horário
                    if (ProfessorTemConflito(
                        turma.Professor,
                        horario.diaSemana,
                        horario.horarioInicio))
                    {
                        throw new Exception(
                            $"Conflito de horário para o professor da turma {turma.id}");
                    }

                    // Uma turma não pode possuir horários duplicados
                    if (TurmaTemConflito(
                        turma,
                        horario.diaSemana,
                        horario.horarioInicio))
                    {
                        throw new Exception(
                            $"Conflito de horário na turma {turma.id}");
                    }
                }
            }
        }

        // Validação das informações da turma
        private void ValidarTurma(Turma turma)
        {
            // Toda turma deve possuir um professor responsável
            if (turma.Professor == null)
            {
                throw new Exception(
                    $"A turma {turma.id} não possui professor.");
            }

            // O professor deve possuir disponibilidade cadastrada
            if (!ProfessorPossuiDisponibilidade(turma.Professor))
            {
                throw new Exception(
                    $"O professor da turma {turma.id} não possui disponibilidade cadastrada.");
            }
        }

        // Validação dos horários cadastrados
        public void ValidarHorario(Horario horario)
        {
            // O dia da semana é obrigatório
            if (string.IsNullOrWhiteSpace(horario.diaSemana))
            {
                throw new Exception("Dia da semana é obrigatório.");
            }

            // Horário inicial é obrigatório
            if (string.IsNullOrWhiteSpace(horario.horarioInicio))
            {
                throw new Exception("Horário inicial é obrigatório.");
            }

            // Horário final é obrigatório
            if (string.IsNullOrWhiteSpace(horario.horarioFim))
            {
                throw new Exception("Horário final é obrigatório.");
            }

            // O horário final deve ser maior que o inicial
            if (string.Compare(
                horario.horarioFim,
                horario.horarioInicio) <= 0)
            {
                throw new Exception(
                    "Horário final deve ser maior que horário inicial.");
            }
        }

        // Verifica se o professor possui disponibilidade cadastrada
        private bool ProfessorPossuiDisponibilidade(
            Professor professor)
        {
            return professor.Disponibilidades.Any();
        }

        // Verifica conflito de horário do professor
        // Um professor não pode ministrar duas aulas simultaneamente
        private bool ProfessorTemConflito(
            Professor professor,
            string diaSemana,
            string horarioInicio)
        {
            return _turmas
                .Where(t => t.idProfessor == professor.id)
                .SelectMany(t => t.Horarios)
                .Count(h =>
                    h.diaSemana == diaSemana &&
                    h.horarioInicio == horarioInicio) > 1;
        }

        // Verifica conflito de horário dentro da própria turma
        // Uma turma não pode ter dois horários iguais
        private bool TurmaTemConflito(
            Turma turma,
            string diaSemana,
            string horarioInicio)
        {
            return turma.Horarios.Count(h =>
                h.diaSemana == diaSemana &&
                h.horarioInicio == horarioInicio) > 1;
        }
    }
}