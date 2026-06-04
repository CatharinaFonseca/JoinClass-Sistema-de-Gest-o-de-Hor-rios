using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Aluno: Pessoa
    {
        public Graduacao graduacao { get; set; }
    }
}