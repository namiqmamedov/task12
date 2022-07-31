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

    public class StudentController
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;
        private Student student;

        public StudentController()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        #region CreateStudent
        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");
                string surname = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student age:");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);


                ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "All groups");
                foreach (var group in groups)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                }
            Group: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name:");
                string groupName = Console.ReadLine();

                var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());

                if (dbGroup != null)
                {
                    if (dbGroup.MaxSize > dbGroup.CurrentSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                            Group = dbGroup,

                        };
                        dbGroup.CurrentSize++;

                        _studentRepository.Create(student);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{student.Name}, Surname:{student.Surname}, Age:{student.Age}, Group:{student.Group.Name}");
                    }
                    else
                    {
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Group is full, max size of group {dbGroup.MaxSize}");
                        }
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"Including group doesn't exist");
                    goto Group;
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"You must create group before creating of student");
            }



        }
        #endregion

        #region DeleteStudent
        public void DeleteStudent()
        {
            var students = _studentRepository.GetAll();
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {student.ID} Fullname - {student.Name} {student.Surname}");
                }
            ID: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student ID");
                string id = Console.ReadLine();
                int studentID;
                var result = int.TryParse(id, out studentID);
                if (result)
                {
                    var student = _studentRepository.Get(s => s.ID == studentID);
                    if (student != null)
                    {
                        string fullName = $"{student.Name} {student.Surname}";
                        _studentRepository.Delete(student);
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

        #region UpdateStudent
        public void UpdateStudent()
        {
            var students = _studentRepository.GetAll();
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, $"ID - {student.ID} Fullname - {student.Name} {student.Surname}");
                }
                ID:  ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student ID");
                string id = Console.ReadLine();
                int studentid;
                bool result = int.TryParse(id, out studentid);
                var studentId = _studentRepository.Get(s => s.ID == studentid);

                if (studentId != null)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter student new name");
                    string newName = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter student new surname");
                    string newSurname = Console.ReadLine();
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter student new age");
                    string newAge = Console.ReadLine();
                    byte StudentNewAge;
                    result = byte.TryParse(newAge, out StudentNewAge);
                GroupName: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter new group name");
                    string newGroupName = Console.ReadLine();

                    if (studentId.Group.Name.ToLower() == newGroupName)
                    {
                        studentId.Name = newName;
                        studentId.Surname = newSurname;
                        studentId.Age = StudentNewAge;
                        _studentRepository.Update(studentId);

                    }
                    else
                    {
                        var group = _groupRepository.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                        if (group != null)
                        {
                            studentId.Name = newName;
                            studentId.Surname = newSurname;
                            studentId.Age = StudentNewAge;
                            studentId.Group.CurrentSize--;
                            studentId.Group = group;
                            studentId.Group.CurrentSize++;

                            _studentRepository.Update(studentId);
                        }
                        else
                        {
                            Console.WriteLine("Group doesn't exist");
                            goto GroupName;
                        }
                    }
                    

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please correct student ID");
                    goto ID;
                }
            }

            
        }
        #endregion

        #region GetAllStudentsByGroup
        public void GetAllStudentsByGroup()
        {
            var groups = _groupRepository.GetAll();

        GroupAllList: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

            foreach (var group in groups)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);

            }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name");
            string groupName = Console.ReadLine();

            var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
                var groupStudents = _studentRepository.GetAll(s => s.Group.Id == dbGroup.Id);

                if (groupStudents.Count != 0)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "All students of the group");


                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name} {groupStudent.Surname} {groupStudent.Age} id:{groupStudent.ID}");
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, $"There is no student in this group - {dbGroup.Name}");

                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Including group doesn't exist");
                goto GroupAllList;
            }


        }

        #endregion

    }
}

