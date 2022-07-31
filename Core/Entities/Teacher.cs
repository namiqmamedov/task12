using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Teacher : Person, IEntity
    {
        public Teacher()
        {
            Groups = new List<Group>();
        }
        public int Id { get; set; }
        public List<Group> Groups { get; set; }
    }
}
