using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Responses
{
    //DPO - Data Presentation Object
    public class GraduacaoResponse 
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
        public int duracao { get; set; }
        public int qntAulas { get; set; }
    }
}