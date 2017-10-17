using MusicStore.Models.ViewModels.Song;

namespace MusicStore.Models.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyric { get; set; }
        public string FileUrl { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string UserId { get; set; }

        public Category Category { get; set; }
        public Author Author { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        protected Song()
        {

        }

        public Song(SongFormViewModel viewModel, string userId)
        {
            Title = viewModel.Title;
            FileUrl = viewModel.FileUrl;
            AuthorId = viewModel.AuthorId;
            CategoryId = viewModel.CategoryId;
            Lyric = viewModel.Lyric;
            UserId = userId;
        }
    }
}