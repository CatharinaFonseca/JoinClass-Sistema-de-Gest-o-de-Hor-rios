using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Aluno : Pessoa
    {
        public int id { get; set; }
        public Graduacao graduacao { get; set; }
    }
}