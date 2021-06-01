using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using SchoolClasses.Repositories;

namespace SchoolClasses.Services
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public SchoolClassService(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<List<Clazz>> GetAllAsync()
        {
            return await _schoolClassRepository.GetAllAsync();
        }

        public async Task<Clazz> GetByIdAsync(int id)
        {
            ValidateItemId(id);
            
            return await _schoolClassRepository.GetByIdAsync(id);
        }

        public async Task AddOneAsync(Clazz item)
        {
            ValidateItem(item);
            
            await _schoolClassRepository.AddOneAsync(item);
        }

        public async Task AddRangeAsync(List<Clazz> items)
        {
            if (items == null || !items.Any())
            {
                throw new ArgumentException("Список учителей пуст");
            }
            
            await _schoolClassRepository.AddRangeAsync(items);
        }

        public async Task UpdateOneAsync(Clazz item)
        {
            ValidateItem(item);
            ValidateItemId(item.Id);
            
            await _schoolClassRepository.UpdateOneAsync(item);
        }

        public async Task DeleteOneAsync(Clazz item)
        {
            ValidateItem(item);
            ValidateItemId(item.Id);
            
            await _schoolClassRepository.DeleteOneAsync(item);
        }

        private void ValidateItem<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentException("Объект учитель null");
            }
        }

        private void ValidateItemId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id учителя не корректен");
            }
        }
    }
}