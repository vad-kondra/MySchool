using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.SubjectRepository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolContext _context;

        public SubjectRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            var result = await _context.Subjects
                                       .AsNoTracking()
                                       .ToListAsync();
            
            return result;
        }
        
        public async Task AddOneAsync(Subject item)
        {
            await _context.Subjects.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> GetByIdAsync(long id)
        {
            var result = await _context.Subjects
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync(x => x.SubjectId == id);
            
            return result;
        }

        public Subject GetById(long id)
        {
            var result = _context.Subjects
                                       .AsNoTracking()
                                       .FirstOrDefault(x => x.SubjectId == id);
            
            return result;
        }

        public void Update(Subject item)
        {
            var local = _context
                        .Set<Subject>()
                        .Local
                        .FirstOrDefault(x => x.SubjectId.Equals(item.SubjectId));
            
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}