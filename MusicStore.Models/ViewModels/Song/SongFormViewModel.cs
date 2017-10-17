using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models.ViewModels.Song
{
    public class SongFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Lyric { get; set; }

        [Required]
        public string FileUrl { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }
    }
}