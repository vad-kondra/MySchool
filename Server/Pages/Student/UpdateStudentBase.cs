using System.Collections.Generic;
using BusinessLogicLayer.GradeService;
using BusinessLogicLayer.GradeService.Dtos;
using BusinessLogicLayer.StudentService;
using BusinessLogicLayer.StudentService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Student
{
    public class UpdateStudentBase : ComponentBase
    {
        [Parameter]
        public long? StudentId { get; set; }
        
        protected StudentDto Student { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IStudentService StudentService { get; set; }
        
        [Inject]
        private IGradeService GradeService { get; set; }

        protected List<GradeDto> Grades { get; set; }

        protected override void OnInitialized()
        {
            if (StudentId != null)
            {
                Grades = GradeService.GetAll();
                Student = StudentService.GetById(StudentId.Value);
            }
            else
            {
                NavigationManager.NavigateTo("students");
            }
        }

        protected void Save()
        {
            StudentService.Update(Student);
            NavigationManager.NavigateTo("students");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("students");
        }
    }
}