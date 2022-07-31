using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Controller
{
    public class AdminController
    {
        private AdminRepository _adminRepository;
        public AdminController()
        {
            _adminRepository = new AdminRepository();
        }

        public Admin Authenticate()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter admin username:");
            string username = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter admin password:");
            string password = Console.ReadLine();

            
            var admin = _adminRepository.Get(a => a.Username.ToLower() == username.ToLower() && PasswordHasher.Decrypt(a.Password) == password);
            
            return admin;
        }
        public void GetAll()
        {
            var admins = _adminRepository.GetAll();
            if (admins.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All admin list");
                foreach (var admin in admins )
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Username - {admin.Username}");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not any admins");
            }
        }
         
    }
}
