using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Request;

namespace JoinClassGestaodeHorario.API.Controllers.Alunos.Request
{
    public class AdicionarAlunoRequest
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}