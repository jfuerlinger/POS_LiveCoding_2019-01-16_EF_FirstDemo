using System;
using System.ComponentModel.DataAnnotations;

namespace EFDemoLiveCoding.Core.Entities
{
    public class Driver
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public Team Team { get; set; }


    }
}
