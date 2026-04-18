using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Graduacao
    {
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
        public int duracao { get; set; }
        public int qntAulas { get; set; }
        //public List<Disciplina> disciplinas { get; set; }
    }
}