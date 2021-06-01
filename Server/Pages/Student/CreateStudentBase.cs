using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.GradeService;
using BusinessLogicLayer.GradeService.Dtos;
using BusinessLogicLayer.StudentService;
using BusinessLogicLayer.StudentService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Student
{
    public class CreateStudentBase : ComponentBase
    {
        protected StudentDto Student { get; set; } = new();

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IStudentService StudentService { get; set; }
        
        [Inject]
        private IGradeService GradeService { get; set; }

        protected List<GradeDto> Grades { get; set; }

        protected override void OnInitialized()
        {
            var grades = GradeService.GetAll();
            Grades = grades;
        }

        protected async Task CreateTeacher()
        {
            await StudentService.AddOneAsync(Student);
            NavigationManager.NavigateTo("/students");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("students");
        }
    }
}