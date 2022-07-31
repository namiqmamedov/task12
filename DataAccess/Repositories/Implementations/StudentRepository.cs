using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository : IRepository<Student>
    {
        private static int id;
        public Student Create(Student entity)
        {
            id++;
            entity.ID = id;
            try
            {
                DbContext.Students.Add(entity);
                return entity;
            }
            catch (Exception e) 
            {

                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public void Delete(Student entity)
        {
            try
            {
                DbContext.Students.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            
        }

        public void Update(Student entity)
        {
            try
            {
                var student = DbContext.Students.Find(s => s.ID == entity.ID);
                if (student != null)
                {
                    student.Name = entity.Name;
                    student.Surname = entity.Surname;
                    student.Age = entity.Age;
                    student.Group = entity.Group;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            
            
        }
        public Student Get(Predicate<Student> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Students[0];
                }
                else
                {
                    return DbContext.Students.Find(filter);

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Students;
                }
                else
                {
                    return DbContext.Students.FindAll(filter);
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }
    }
}
