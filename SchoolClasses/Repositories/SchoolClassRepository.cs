using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolClasses.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly SchoolClassesContext _schoolClassesContext;

        public SchoolClassRepository(SchoolClassesContext schoolClassesContext)
        {
            _schoolClassesContext = schoolClassesContext;
        }

        public async Task<List<Clazz>> GetAllAsync()
        {
            var result = await _schoolClassesContext.SchoolClasses.ToListAsync();
            
            return result;
        }

        public async Task<Clazz> GetByIdAsync(int id)
        {
            return await _schoolClassesContext.SchoolClasses.FindAsync(id);
        }

        public async Task AddOneAsync(Clazz item)
        {
            await _schoolClassesContext.SchoolClasses.AddAsync(item);
            await _schoolClassesContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(List<Clazz> items)
        {
            await _schoolClassesContext.AddRangeAsync(items);
        }

        public async Task UpdateOneAsync(Clazz item)
        {
            _schoolClassesContext.Entry(item).State = EntityState.Modified;
            await _schoolClassesContext.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(Clazz item)
        {
            _schoolClassesContext.SchoolClasses.Remove(item);
            await _schoolClassesContext.SaveChangesAsync();
        }
    }
}