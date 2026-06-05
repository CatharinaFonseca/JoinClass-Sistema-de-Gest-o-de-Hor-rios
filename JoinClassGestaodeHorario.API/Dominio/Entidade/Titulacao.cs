using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Titulacao
    {
        public int id { get; set; }
        public string tipoTitulacao { get; set; }

        public int id_professor { get; set; }
        public Professor Professor { get; set; }
    }
}