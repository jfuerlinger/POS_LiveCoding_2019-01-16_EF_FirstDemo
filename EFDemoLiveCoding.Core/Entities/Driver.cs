using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemoLiveCoding.Core.Entities
{
    public class Driver
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }

        public int TeamId { get; set; }


    }
}
