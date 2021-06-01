using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.SubjectService;
using BusinessLogicLayer.SubjectService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Subject
{
    public class CreateSubjectBase : ComponentBase
    {
        protected SubjectDto Subject { get; set; } = new();

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        protected ISubjectService SubjectService { get; set; }
        
        protected List<SubjectDto> Subjects { get; set; }

        protected override void OnInitialized()
        {
            
        }

        protected async Task CreateTeacher()
        {
            await SubjectService.AddOneAsync(Subject);
            NavigationManager.NavigateTo("/subjects");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("subjects");
        }
    }
}