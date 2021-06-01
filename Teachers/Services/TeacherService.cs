using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Teachers.Repositories;

namespace Teachers.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            ValidateItemId(id);
            
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task AddOneAsync(Teacher item)
        {
            ValidateItem(item);
            
            await _teacherRepository.AddOneAsync(item);
        }

        public async Task AddRangeAsync(List<Teacher> items)
        {
            if (items == null || !items.Any())
            {
                throw new ArgumentException("Список учителей пуст");
            }
            
            await _teacherRepository.AddRangeAsync(items);
        }

        public async Task UpdateOneAsync(Teacher item)
        {
            ValidateItem(item);
            ValidateItemId(item.Id);
            
            await _teacherRepository.UpdateOneAsync(item);
        }

        public async Task DeleteOneAsync(Teacher item)
        {
            ValidateItem(item);
            ValidateItemId(item.Id);
            
            await _teacherRepository.DeleteOneAsync(item);
        }

        private void ValidateItem(Teacher item)
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