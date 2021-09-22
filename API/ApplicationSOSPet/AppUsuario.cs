using Microsoft.EntityFrameworkCore;
using RepositorySOSPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSOSPet
{
    public class AppUsuario
    {
        private readonly ApplicationDbContext _context;

        public AppUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todas
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IList<Usuario>> GetAll(Expression<Func<Usuario, bool>> filter = null)
        {
            IList<Usuario> list = null;

            if (filter != null)
                list = await _context.Set<Usuario>().Where(filter).ToListAsync();
            else
                list = await _context.Set<Usuario>().ToListAsync();

            return list;
        }

        public async Task<Usuario> Get(int IdUsuario)
        {
            return await _context.Set<Usuario>().FindAsync(IdUsuario);
        }

        public async Task Add(Usuario usuario)
        {
            await _context.Set<Usuario>().AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Usuario usuario)
        {
            _context.Set<Usuario>().Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Set<Usuario>().Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
