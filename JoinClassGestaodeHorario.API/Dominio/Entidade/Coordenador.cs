using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Coordenador : Pessoa
    {
        public List<Disciplina> disciplinas { get; set; }
        public List<Graduacao> graduacoes { get; set; }
    }
}