namespace PlacesToEat.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RegularUser : User
    {
        private ICollection<RestaurantUser> favouriteRestaurants;

        public RegularUser()
        {
            this.favouriteRestaurants = new HashSet<RestaurantUser>();
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
    }
}
