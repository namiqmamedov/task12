using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Group : Person ,IEntity
    {      
        public int Id { get; set; }       
        public int MaxSize { get; set; }       
        public int CurrentSize { get; set; }      

        public Teacher Teacher { get; set; }    
    }
}
