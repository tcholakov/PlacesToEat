namespace PlacesToEat.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Users;

    public class Comment : BaseModel<int>
    {
        public string RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual RestaurantUser Restaurant { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual RegularUser Author { get; set; }

        [MinLength(3)]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
