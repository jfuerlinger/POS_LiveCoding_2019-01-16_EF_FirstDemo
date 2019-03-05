using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Core.Entities
{
    public class Pupil
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string  FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public SchoolClass SchoolClass { get; set; }
    }
}
