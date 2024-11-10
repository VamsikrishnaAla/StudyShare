using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudyShare
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        public string FilePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
