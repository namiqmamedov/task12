using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        static DbContext()
        {
            Students = new List<Student>();
            Groups = new List<Group>();  
            Admins = new List<Admin>();
            Teachers = new List<Teacher>();

            string password1 = "toor";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("root", hashedPassword1);
            Admins.Add(admin1);

            string password2 = "noob";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin", hashedPassword2);
            Admins.Add(admin2);


        }
        public static List<Teacher> Teachers { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Student> Students { get; set; }
        public static List<Group> Groups { get; set; }
    }
}
