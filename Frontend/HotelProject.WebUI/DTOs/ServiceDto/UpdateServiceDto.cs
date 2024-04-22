using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.DTOs.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }


        [Required(ErrorMessage = "Please enter service icon")]
        public string? ServiceIcon { get; set; }

       
        [Required(ErrorMessage = "Please enter service title")]
        [StringLength(100, ErrorMessage = "Title content contains max 100 character")]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Please enter service description")]
        [StringLength(200, ErrorMessage = "Description content contains max 200 character")]
        public string Description { get; set; }
    }
}
