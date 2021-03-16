using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestProject
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
