using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Response
{
    public class GraduacaoResponse
    {
        public int id { get; set; }
        public string nomeGraduacao { get; set; }
        public int duracaoGraduacao { get; set; }
        public int qntAulaGraduacao { get; set; }

        public int idCoordenador { get; set; }
    }
}