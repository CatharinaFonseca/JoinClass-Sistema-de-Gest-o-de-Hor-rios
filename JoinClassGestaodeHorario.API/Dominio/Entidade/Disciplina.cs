using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Disciplina
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
    }
}