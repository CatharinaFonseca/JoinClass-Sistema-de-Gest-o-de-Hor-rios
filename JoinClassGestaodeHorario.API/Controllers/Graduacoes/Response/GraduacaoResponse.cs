using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
<<<<<<<< HEAD:JoinClassGestaodeHorario.API/Controllers/Graduacoes/Response/GraduacaoResponse.cs
namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Response
{
    public class GraduacaoResponse
========
namespace JoinClassGestaodeHorario.API.Controllers.Disciplinas.Response
{
    public class DisciplinaResponse
>>>>>>>> feature/Gabriela:JoinClassGestaodeHorario.API/Controllers/Disciplinas/Response/DisciplinaResponse.cs
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
=======
namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Response
{
    public class GraduacaoResponse
    {
        public int id { get; set; }
        public string nomeGraduacao { get; set; }
        public int duracaoGraduacao { get; set; }
        public int qntAulaGraduacao { get; set; }

        public int idCoordenador { get; set; }
>>>>>>> feature/Gabriela
    }
}