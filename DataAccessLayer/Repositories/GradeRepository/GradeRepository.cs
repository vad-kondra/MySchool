using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.GradeRepository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolContext _schoolContext;

        public GradeRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Grade GetById(long id)
        {
            var result = _schoolContext.Grades
                                       .AsNoTracking()
                                       .Include(x => x.Teacher)
                                       .FirstOrDefault(x => x.GradeId == id);
            
            return result;
        }

        public Task<Grade> GetByIdAsync(long id)
        {
            var result = _schoolContext.Grades
                                       .AsNoTracking()
                                       .Include(x => x.Teacher)
                                       .FirstOrDefaultAsync(x => x.GradeId == id);
            
            return result;
        }

        public void Update(Grade item)
        {
            var local = _schoolContext
                        .Set<Grade>()
                        .Local
                        .FirstOrDefault(x => x.GradeId.Equals(item.GradeId));
            
            if (local != null)
            {
                _schoolContext.Entry(local).State = EntityState.Detached;
            }
            
            _schoolContext.Entry(item).State = EntityState.Modified;
            _schoolContext.Update(item);
            _schoolContext.SaveChanges();
        }

        public List<Grade> GetAll()
        {
            var result = _schoolContext.Grades.AsNoTracking().ToList();
            
            return result;
        }
        
        public async Task<List<Grade>> GetAllAsync()
        {
            var result = await _schoolContext.Grades.AsNoTracking().ToListAsync();
            
            return result;
        }

        public async Task AddOneAsync(Grade item)
        {
            await _schoolContext.Grades.AddAsync(item);
            await _schoolContext.SaveChangesAsync();
        }
    }
}