using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Graduacao
    {
        public int id { get; set; }
        public string nomeGraduacao { get; set; }
        public int duracaoGraduacao { get; set; }
        public int qntAulaGraduacao { get; set; }

        public int idCoordenador { get; set; }
        public Coordenador Coordenador { get; set; }

        public ICollection<MatrizCurricular> Matrizes { get; set; } = new List<MatrizCurricular>();
    }
}