using System.ComponentModel.DataAnnotations;

namespace Megazine.Models
{
    public class ArticleSecond
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string TimeAgo
        {
            get
            {
                TimeSpan timeSincePosted = DateTime.Now - CreatedAt;

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
