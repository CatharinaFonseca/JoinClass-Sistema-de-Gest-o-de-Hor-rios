using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Titulacao
    {
        public int Id { get; set; }
        public string TipoTitulacao { get; set; }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
    }
}