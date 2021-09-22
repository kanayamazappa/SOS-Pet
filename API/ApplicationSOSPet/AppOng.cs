using Microsoft.EntityFrameworkCore;
using RepositorySOSPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationSOSPet
{
    public class AppOng
    {
        private readonly ApplicationDbContext _context;

        public AppOng(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todas
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IList<Ong>> GetAll(Expression<Func<Ong, bool>> filter = null)
        {
            IList<Ong> list = null;

            if (filter != null)
                list = await _context.Set<Ong>().Where(filter).ToListAsync();
            else
                list = await _context.Set<Ong>().ToListAsync();

            return list;
        }

        public async Task<Ong> Get(int IdOng)
        {
            return await _context.Set<Ong>().FindAsync(IdOng);
        }

        public async Task Add(Ong ong)
        {
            await _context.Set<Ong>().AddAsync(ong);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Ong ong)
        {
            _context.Set<Ong>().Remove(ong);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ong ong)
        {
            _context.Set<Ong>().Update(ong);
            await _context.SaveChangesAsync();
        }
    }
}
