using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Coordenador
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }

        public List<Graduacao> Graduacoes { get; set; }
    }
}