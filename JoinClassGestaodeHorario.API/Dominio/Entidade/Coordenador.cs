using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Coordenador : Pessoa
    {
        public ICollection<Graduacao> Graduacoes { get; set; } = new List<Graduacao>();
    }
}