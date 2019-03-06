using System.Collections.Generic;

namespace EFDemoLiveCoding.Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Driver> Drivers { get; set; }

    }
}
