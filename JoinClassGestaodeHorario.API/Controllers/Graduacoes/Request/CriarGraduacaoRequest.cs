using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Request
{
    public class CriarGraduacaoRequest
    {
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
        public int duracao { get; set; }
        public int qntAulas { get; set; }
    }
}