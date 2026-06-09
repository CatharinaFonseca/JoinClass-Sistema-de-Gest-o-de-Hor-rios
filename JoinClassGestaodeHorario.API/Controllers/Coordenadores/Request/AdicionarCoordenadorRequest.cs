using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Controllers.Pessoas.Request;
using JoinClassGestaodeHorario.API.Dominio.Entidade;

namespace JoinClassGestaodeHorario.API.Controllers.Coordenadores.Request
{
    public class AdicionarCoordenadorRequest
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}