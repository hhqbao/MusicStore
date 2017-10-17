using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MusicStore.Models.Entities
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Song> Songs { get; set; }

        public ApplicationUser()
        {
            Songs = new Collection<Song>();
        }
    }
}
