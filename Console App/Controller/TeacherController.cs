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
    public class TeacherController
    {
        private TeacherRepository _teacherRepository;
        private GroupRepository _groupRepository;

        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
            _groupRepository = new GroupRepository();
        }

        #region Create
        public void Create()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher name:");
            string name = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher surname:");
            string surname = Console.ReadLine();

        TeacherAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher age:");
            string age = Console.ReadLine();
            byte teacherAge;
            bool result = byte.TryParse(age, out teacherAge);

            if (result)
            {
                Teacher teacher = new Teacher
                {
                    Name = name,
                    Surname = surname,
                    Age = teacherAge,
                };

                var dbTeacher = _teacherRepository.Create(teacher);
                if (dbTeacher != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{teacher.Name} {teacher.Surname} {teacher.Age} is created ");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Something went wrong");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter age in correct format!");
                goto TeacherAge;
            }

        }
        #endregion

        #region Update
        public void Update()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {teacher.Id}, Fullname - {teacher.Name} {teacher.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher ID");
                string id = Console.ReadLine();
                int chosenID;
                var result = int.TryParse(id, out chosenID);
                if (result)
                {
                    var dbTeacher = _teacherRepository.Get(t => t.Id == chosenID);
                    if (dbTeacher != null)
                    {
                        string oldName = dbTeacher.Name;
                        string oldSurname = dbTeacher.Surname;

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher new name");
                        string newName = Console.ReadLine();

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher new surname");
                        string newSurname = Console.ReadLine();

                    NewAge: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teachew new age");

                        string newAge = Console.ReadLine();
                        byte TeacherNewAge;
                        result = byte.TryParse(newAge, out TeacherNewAge);
                        if (result)
                        {
                            var updatedTeacher = new Teacher
                            {
                                Id = dbTeacher.Id,
                                Name = newName,
                                Surname = newSurname,
                                Age = TeacherNewAge,
                            };
                            _teacherRepository.Update(updatedTeacher);
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname} is updated to {updatedTeacher.Name} {updatedTeacher.Surname}");
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter age in correct format");
                            goto NewAge;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this ID");
                        goto ID;
                    }
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are not any teacher ");
            }
        }
        #endregion

        #region Delete
        public void Delete()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All teacher list");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID - {teacher.Id} Fullname - {teacher.Name} {teacher.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher ID");
                string id = Console.ReadLine();
                int teacherID;
                var result = int.TryParse(id, out teacherID);
                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherID);
                    if (teacher != null)
                    {
                        string fullName = $"{teacher.Name} {teacher.Surname}";
                        _teacherRepository.Delete(teacher);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Enter ID in correct format");
                    goto ID;
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There are not any groups");
            }

        }

        #endregion

        #region GetAll
        public void GetAll()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All teacher list");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID -- {teacher.Id}, Fullname -- {teacher.Name} {teacher.Surname}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not any teachers");
            }

        }
        #endregion

        #region AddGroup
        public void AddGroupTeacher()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count > 0)
            {
                var teachers = _teacherRepository.GetAll();
                if (teachers.Count > 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All teachers list");
                    foreach (var teacher in teachers)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID -- {teacher.Id} Fullname -- {teacher.Name} {teacher.Surname} ");
                    }
                ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher ID");
                    string id = Console.ReadLine();
                    int teacherID;
                    var result = int.TryParse(id, out teacherID);

                    if (result)
                    {
                        var teacher = _teacherRepository.Get(t => t.Id == teacherID);
                        if (teacher != null)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "All group list");
                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID -- {group.Id} Name - {group.Name}");
                            }
                        GroupID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter group ID");
                            string groupid = Console.ReadLine();

                            int groupID;
                            result = int.TryParse(groupid, out groupID);
                            if (result)
                            {
                                var group = _groupRepository.Get(g => g.Id == groupID);
                                if (group != null)
                                {
                                    if (group.Teacher == null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is succesfully added to {teacher.Name}");
                                    }
                                    else
                                    {
                                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"This group has already teacher - {group.Teacher.Name}");
                                    }


                                }
                                else
                                {
                                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Group doesn't exist with this ID");
                                    goto GroupID;

                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter ID in correct format");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this ID");
                            goto ID;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter ID in correct format");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not any teacher");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "You must create a group before adding teacher");
            }
        }
        #endregion

        #region GetAllGroupByTeacher
        public void GetAllGroupsByTeacher()
        {
            var teachers = _teacherRepository.GetAll();
            if (teachers.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "All teacher list");
                foreach (var teacher in teachers)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"ID -- {teacher.Id}, Fullname -- {teacher.Name} {teacher.Surname}");
                }
                ID:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter teacher ID");
                string id = Console.ReadLine();
                int teacherID;
                var result = int.TryParse(id, out teacherID);
                if (result)
                {
                    var teacher = _teacherRepository.Get(t => t.Id == teacherID);
                    if (teacher != null)
                    {
                        var groups = _groupRepository.GetAll(g =>g.Teacher != null ? g.Teacher.Id == teacherID : false);
                        if (groups.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "The groups of teacher");
                            foreach (var group in groups)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"ID -- {group.Id}, Name -- {group.Name}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher has no group");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Teacher doesn't exist with this ID");
                        goto ID;
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter ID in correct format");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is not any teacher");
            }
        }

        #endregion

    }
}
