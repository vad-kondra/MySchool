using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.TeacherRepository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;

        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var result = await _context.Teachers.AsNoTracking().ToListAsync();
            
            return result;
        }

        public async Task<Teacher> GetByIdAsync(long id)
        {
            return await _context.Teachers.AsNoTracking().FirstOrDefaultAsync(x => x.TeacherId == id);
        }
        
        public async Task<Teacher> AddOneAsync(Teacher item)
        {
            await _context.Teachers.AddAsync(item);
            await _context.SaveChangesAsync();
            
            return item;
        }

        public async Task<List<Teacher>> AddRangeAsync(List<Teacher> items)
        {
            await _context.AddRangeAsync(items);
            await _context.SaveChangesAsync();
            
            return items;
        }

        public void Update(Teacher item)
        {

            var local = _context
                        .Set<Teacher>()
                        .Local
                        .FirstOrDefault(x => x.TeacherId.Equals(item.TeacherId));
            
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            _context.SaveChanges();
        }

        public async Task DeleteOneAsync(Teacher item)
        {
            _context.Teachers.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}