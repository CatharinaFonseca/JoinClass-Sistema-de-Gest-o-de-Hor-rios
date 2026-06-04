using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace JoinClassGestaodeHorario.API.Dominio.Entidade
{
<<<<<<<< HEAD:JoinClassGestaodeHorario.API/Controllers/Graduacoes/Request/CriarGraduacaoRequest.cs
    public class CriarGraduacaoRequest
========
    public class Graduacao
>>>>>>>> feature/Gabriela:JoinClass-SistemaDeGestaoDeHorarios/JoinClassGestaodeHorario.API/Dominio/Entidade/Graduacao.cs
    {
        public string nome { get; set; }
        public int cargaHoraria { get; set; }
        public int duracao { get; set; }
        public int qntAulas { get; set; }
<<<<<<<< HEAD:JoinClassGestaodeHorario.API/Controllers/Graduacoes/Request/CriarGraduacaoRequest.cs
========
        //public List<Disciplina> disciplinas { get; set; }
>>>>>>>> feature/Gabriela:JoinClass-SistemaDeGestaoDeHorarios/JoinClassGestaodeHorario.API/Dominio/Entidade/Graduacao.cs
=======
namespace JoinClassGestaodeHorario.API.Controllers.Graduacoes.Request
{
    public class CriarGraduacaoRequest
    {
        public string nomeGraduacao { get; set; }
        public int duracaoGraduacao { get; set; }
        public int qntAulaGraduacao { get; set; }

        public int idCoordenador { get; set; }
>>>>>>> feature/Gabriela
    }
}