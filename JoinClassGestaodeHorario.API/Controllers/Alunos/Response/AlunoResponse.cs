using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Response;

namespace JoinClassGestaodeHorario.API.Controllers.Alunos.Response
{
    public class AlunoResponse
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}