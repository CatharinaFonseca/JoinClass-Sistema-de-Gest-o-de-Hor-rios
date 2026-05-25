using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoinClassGestaodeHorario.API.Dominio.Entidade;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace JoinClassGestaodeHorario.API.Dados.Repositorios
{
    public class HorarioRepositorio : IHorarioRepositorio
    {
        private ApplicationDbContext contexto;

        public HorarioRepositorio(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Horario horario)
        {
            await contexto.Horarios.AddAsync(horario);
            await contexto.SaveChangesAsync();
        }

        public async Task Alterar(Horario horario)
        {
            contexto.Horarios.Update(horario);
            await contexto.SaveChangesAsync();
        }

        public async Task Deletar(Horario horario)
        {
            contexto.Horarios.Remove(horario);
            await contexto.SaveChangesAsync();
        }

        public async Task<Horario> ObterHorario(int id)
        {
            var horario = contexto.Horarios
                 .FromSql($"Select * From horario where id = {id}");
            return await horario.FirstOrDefaultAsync();
        }

        public async Task<List<Horario>> ObterTodosOsHorarios()
        {
            var horarios = contexto.Database
                .SqlQuery<Horario>($"Select * From horario");
            return await horarios.ToListAsync();
        }
    }
}