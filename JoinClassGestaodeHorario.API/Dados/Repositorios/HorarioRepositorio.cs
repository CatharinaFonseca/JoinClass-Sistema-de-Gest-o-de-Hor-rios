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

<<<<<<< HEAD
        public async Task Adicionar(Horario horario)
        {
            await contexto.Horarios.AddAsync(horario);
            await contexto.SaveChangesAsync();
        }

=======
>>>>>>> feature/Gabriela
        public async Task Alterar(Horario horario)
        {
            contexto.Horarios.Update(horario);
            await contexto.SaveChangesAsync();
        }

<<<<<<< HEAD
=======
        public async Task Criar(Horario horario)
        {
            await contexto.Horarios.AddAsync(horario);
            await contexto.SaveChangesAsync();
        }

>>>>>>> feature/Gabriela
        public async Task Deletar(Horario horario)
        {
            contexto.Horarios.Remove(horario);
            await contexto.SaveChangesAsync();
        }

        public async Task<Horario> ObterHorario(int id)
        {
            var horario = contexto.Horarios
<<<<<<< HEAD
                 .FromSql($"Select * From horario where id = {id}");
=======
                 .FromSql($"Select * From horarios where id = {id}");
>>>>>>> feature/Gabriela
            return await horario.FirstOrDefaultAsync();
        }

        public async Task<List<Horario>> ObterTodosOsHorarios()
        {
            var horarios = contexto.Database
<<<<<<< HEAD
                .SqlQuery<Horario>($"Select * From horario");
=======
                .SqlQuery<Horario>($"Select * From horarios");
>>>>>>> feature/Gabriela
            return await horarios.ToListAsync();
        }
    }
}