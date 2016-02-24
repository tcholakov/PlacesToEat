﻿namespace PlacesToEat.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using PlacesToEat.Data.Common.Models;
    using Users;

    public class Event : BaseModel<int>
    {
        private ICollection<RegularUser> participants;

        public Event()
        {
            this.participants = new HashSet<RegularUser>();
        }

        public string RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public virtual RestaurantUser Restaurant { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<RegularUser> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }
    }
}
