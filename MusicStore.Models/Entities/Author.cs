using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicStore.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Author()
        {
            Songs = new Collection<Song>();
        }
    }
}
