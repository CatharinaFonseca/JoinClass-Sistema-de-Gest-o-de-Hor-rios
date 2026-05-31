using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
    public class Graduacao
    {
        public int Id { get; set; }
        public string NomeGraduacao { get; set; }
        public int DuracaoGraduacao { get; set; }
        public int QntAulaGraduacao { get; set; }

        public int IdCoordenador { get; set; }
        public Coordenador Coordenador { get; set; }

        public List<MatrizCurricular> Matrizes { get; set; }
    }
}