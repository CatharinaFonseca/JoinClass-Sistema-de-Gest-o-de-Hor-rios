using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Horario
    {
        public int Id { get; set; }
        public string DiaSemana { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }

        public int IdTurma { get; set; }
        public Turma Turma { get; set; }
    }
}