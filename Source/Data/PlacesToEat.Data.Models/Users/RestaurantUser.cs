namespace PlacesToEat.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RestaurantUser : User
    {
        private ICollection<RegularUser> regularUsers;
        private ICollection<Comment> comments;

        public RestaurantUser()
        {
            this.regularUsers = new HashSet<RegularUser>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<RegularUser> RegularUsers
        {
            get { return this.regularUsers; }
            set { this.regularUsers = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
