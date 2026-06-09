using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.ProfessoresDiciplinas.Request
{
    public class VincularProfessorDisciplinaRequest
    {
        public int id_professor { get; set; }
        public int id_disciplina { get; set; }
    }
}