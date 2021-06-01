using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }
        
        public async Task<List<Student>> GetAllAsync()
        {
            var result = await _context.Students
                                             .AsNoTracking()
                                             .Include(x => x.Grade)
                                             .ToListAsync();
            
            return result;
        }

        public Student GetById(long id)
        {
            return _context.Students
                                 .AsNoTracking()
                                 .Include(x => x.Grade)
                                 .FirstOrDefault(x => x.StudentId == id);
        }
        
        public async Task<Student> GetByIdAsync(long id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentId == id);
        }
        
        public async Task<Student> AddOneAsync(Student item)
        {
            await _context.Students.AddAsync(item);
            await _context.SaveChangesAsync();
            
            return item;
        }

        public async Task<List<Student>> AddRangeAsync(List<Student> items)
        {
            await _context.AddRangeAsync(items);
            await _context.SaveChangesAsync();
            
            return items;
        }

        public void Update(Student item)
        {

            var local = _context
                        .Set<Student>()
                        .Local
                        .FirstOrDefault(x => x.StudentId.Equals(item.StudentId));
            
            if (local != null)
            {
                _context.Entry(local).State = EntityState.Detached;
            }
            
            _context.Entry(item).State = EntityState.Modified;
            _context.Update(item);
            _context.SaveChanges();
        }

        public async Task DeleteOneAsync(Student item)
        {
            _context.Students.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}