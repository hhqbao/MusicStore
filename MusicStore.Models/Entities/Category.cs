using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicStore.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }

        public Category()
        {
            Songs = new Collection<Song>();
        }
    }
}
