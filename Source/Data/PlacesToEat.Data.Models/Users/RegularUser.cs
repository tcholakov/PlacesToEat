namespace PlacesToEat.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegularUser : User
    {
        private ICollection<RestaurantUser> favouriteRestaurants;
        private ICollection<Event> events;

        public RegularUser()
        {
            this.favouriteRestaurants = new HashSet<RestaurantUser>();
            this.events = new HashSet<Event>();
        }

        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<RestaurantUser> FavouriteRestaurants
        {
            get { return this.favouriteRestaurants; }
            set { this.favouriteRestaurants = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }
    }
}
