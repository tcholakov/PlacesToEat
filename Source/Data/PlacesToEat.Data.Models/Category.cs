﻿namespace PlacesToEat.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
