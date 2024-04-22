using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Please enter service icon")]
        public string? ServiceIcon { get; set; }

        [Required(ErrorMessage = "Please enter service title")]
        [StringLength(100,ErrorMessage ="Title content contains max 100 character")]
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
