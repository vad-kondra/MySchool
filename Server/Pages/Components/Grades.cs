using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.GradeService;
using BusinessLogicLayer.GradeService.Dtos;
using Microsoft.AspNetCore.Components;

namespace Server.Pages.Components
{
    public class Grades : ComponentBase
    {
        [Parameter]
        public long GradeId { get; set; }
        
        public List<GradeDto> GradesList { get; set; }
        
        [Inject]
        public IGradeService GradeService { get; set; }
        
        [Parameter]
        public string Value { get; set; }
        
        [Parameter]
        public EventCallback < string > ValueChanged { get; set; }
        
        protected override async Task OnInitializedAsync()
        {  
            GradesList = await GradeService.GetAllAsync();
        }
        
        private Task OnValueChanged(ChangeEventArgs e)
        {
            if (e.Value != null)
            {
                Value = e.Value.ToString();
            }
            
            return ValueChanged.InvokeAsync(Value);
        }
    }
}