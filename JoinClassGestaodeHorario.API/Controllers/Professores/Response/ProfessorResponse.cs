using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Response;

namespace JoinClassGestaodeHorario.API.Controllers.Professores.Response
{
    public class ProfessorResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string titulacao { get; set; }

    }
}