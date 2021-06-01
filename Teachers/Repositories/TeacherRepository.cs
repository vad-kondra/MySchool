using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Teachers.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly TeacherContext _teacherContext;

        public TeacherRepository(TeacherContext teacherContext)
        {
            _teacherContext = teacherContext;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            var result = await _teacherContext.Teachers.ToListAsync();
            
            return result;
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _teacherContext.Teachers.FindAsync(id);
        }

        public async Task AddOneAsync(Teacher item)
        {
            await _teacherContext.Teachers.AddAsync(item);
            await _teacherContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<Teacher> items)
        {
            await _teacherContext.AddRangeAsync(items);
        }

        public async Task UpdateOneAsync(Teacher item)
        {
            _teacherContext.Entry(item).State = EntityState.Modified;
            await _teacherContext.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(Teacher item)
        {
            _teacherContext.Teachers.Remove(item);
            await _teacherContext.SaveChangesAsync();
        }
    }
}