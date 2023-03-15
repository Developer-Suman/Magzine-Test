using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Megazine.Models
{
    [Table("Advertisements")]
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? OwenerName { get; set; }
        public int? Amount { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow.AddHours(29);

        [NotMapped]
        public IFormFile? advertiseImageFile { get; set; }
        public string advertiseImage { get; set; }
    }
}
