using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Lütfen Oda numarasını giriniz")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen Oda resmi giriniz")]
        public string? CoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen oda başlığı giriniz")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı giriniz")]

        public string? BathCount { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı giriniz")]
        public string? BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen açıklamayı giriniz")]
        public string? Description { get; set; }
    }
}
