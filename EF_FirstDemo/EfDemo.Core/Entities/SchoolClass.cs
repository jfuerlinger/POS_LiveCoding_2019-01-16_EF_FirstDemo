using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Core.Entities
{
    public class SchoolClass
    {
        public SchoolClass()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pupil> Pupils { get; set; }


    }
}
