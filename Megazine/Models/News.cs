using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Megazine.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        [NotMapped]
        public IFormFile? ImageUrl { get; set; }
        public string ImageName { get; set; }

        public string TimeAgo
        {
            get
            {
                TimeSpan timeSincePosted = DateTime.Now - CreatedDate;

                if (timeSincePosted.TotalMinutes < 1)
                {
                    return "just now";
                }
                else if (timeSincePosted.TotalHours < 1)
                {
                    int minutes = (int)Math.Floor(timeSincePosted.TotalMinutes);
                    return $"{minutes} minute{(minutes > 1 ? "s" : "")} ago";
                }
                else if (timeSincePosted.TotalDays < 1)
                {
                    int hours = (int)Math.Floor(timeSincePosted.TotalHours);
                    return $"{hours} hour{(hours > 1 ? "s" : "")} ago";
                }
                else
                {
                    int days = (int)Math.Floor(timeSincePosted.TotalDays);
                    return $"{days} day{(days > 1 ? "s" : "")} ago";
                }
            }
        }
    }
}
