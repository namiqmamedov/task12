using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{ 
    public class Admin : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin(string username, string password)
        {          
            Username = username;
            Password = password;    
        }
    }
}
