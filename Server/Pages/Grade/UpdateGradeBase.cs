using BusinessLogicLayer.GradeService;
using BusinessLogicLayer.GradeService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Grade
{
    public class UpdateGradeBase : ComponentBase
    {
        [Parameter]
        public long? GradeId { get; set; }
        
        protected GradeDto Grade { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        [Inject]
        private IGradeService GradeService { get; set; }
        
        protected override void OnInitialized()
        {
            if (GradeId != null)
            {
                Grade = GradeService.GetById(GradeId.Value);
            }
            else
            {
                NavigationManager.NavigateTo("grades");
            }
        }

        protected void SaveStudent()
        {
            GradeService.Update(Grade);
            NavigationManager.NavigateTo("grades");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("grades");
        }
    }
}