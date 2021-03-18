using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestProject
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public ICollection<Song> Songs { get; set; }
        public override string ToString()
        {
            return $"Group ID: {Id}, Group Name: {Name}";
        }
    }
}
