using System.Threading.Tasks;
using BusinessLogicLayer.SubjectService;
using BusinessLogicLayer.SubjectService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Subject
{
    public class UpdateSubjectBase : ComponentBase
    {
        [Parameter]
        public long? SubjectId { get; set; }
        
        protected SubjectDto Subject { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        protected ISubjectService SubjectService { get; set; }
        
        protected override void OnInitialized()
        {
            if (SubjectId != null)
            {
                 Subject = SubjectService.GetById(SubjectId.Value);
            }
            else
            {
                NavigationManager.NavigateTo("subjects");
            }
        }

        protected void Save()
        {
            SubjectService.Update(Subject);
            NavigationManager.NavigateTo("subjects");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("subjects");
        }
    }
}