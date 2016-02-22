namespace PlacesToEat.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using Users;

    public class Category : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
