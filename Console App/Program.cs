using Console_App.Controller;
using Core.Constants;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;

namespace Manage
{
    public class Program
    {
        static void Main()
        {
            GroupController _groupController = new GroupController();
            StudentController _studentController = new StudentController();
            AdminController _adminController = new AdminController();
            TeacherController _teacherController = new TeacherController();          

            Authentication: var admin = _adminController.Authenticate();

            if (admin != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Console.WriteLine("-------");
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Groups");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group by name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Create Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "7 - Update Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "8 - Delete Student");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "9 - All Student By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "10 - Get Student By Group");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "11 - Create Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "12 - Update Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "13 - Delete Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "14 - All Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "15 - Add Group To Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "16 - All Groups Of Teacher");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "17 - All Admins");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                    Console.WriteLine("-------");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select Options");
                    string number = Console.ReadLine();

                    int SelectedNumber;
                    bool result = int.TryParse(number, out SelectedNumber);

                    if (result)
                    {
                        if (SelectedNumber >= 0 && SelectedNumber <= 17)
                        {
                            switch (SelectedNumber)
                            {
                                case (int)Options.CreateGroup:
                                    _groupController.CreateGroup();
                                    break;
                                case (int)Options.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)Options.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)Options.AllGroups:
                                    _groupController.AllGroups();
                                    break;
                                case (int)Options.GetGroupByName:
                                    _groupController.GetGroupByName();
                                    break;
                                case (int)Options.CreateStudent:
                                    _studentController.CreateStudent();
                                    break;
                                case (int)Options.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)Options.DeleteStudent:
                                    _studentController.DeleteStudent();
                                    break;
                                case (int)Options.GetAllStudentsByGroup:
                                    _studentController.GetAllStudentsByGroup();
                                    break;
                                case (int)Options.CreateTeacher:
                                    _teacherController.Create();
                                    break;
                                case (int)Options.UpdateTeacher:
                                    _teacherController.Update();
                                    break;
                                case (int)Options.DeleteTeacher:
                                    _teacherController.Delete();
                                    break;
                                case (int)Options.AllTeachers:
                                    _teacherController.GetAll();
                                    break;
                                case (int)Options.AddGroupTeacher:
                                    _teacherController.AddGroupTeacher();
                                    break;
                                case (int)Options.AllGroupsOfTeacher:
                                    _teacherController.GetAllGroupsByTeacher();
                                    break;
                                case (int)Options.AllAdmins:
                                    _adminController.GetAll();
                                    break;
                                case (int)Options.Exit:
                                    _groupController.Exit();
                                    return;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");

                    }


                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Admin username or password is incorrect");
                goto Authentication;
            }
        }

    }

}



