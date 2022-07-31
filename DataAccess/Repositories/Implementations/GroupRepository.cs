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
    public class GroupRepository : IRepository<Group>
    {
        private static int id;  
        public Group Create(Group entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Groups.Add(entity);
                return entity;
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public void Delete(Group entity)
        {
            try
            {
                DbContext.Groups.Remove(entity);
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
            
        }

        public void Update(Group entity)
        {
            try
            {
                var group = DbContext.Groups.Find(g => g.Id == entity.Id);
                if (group != null)
                {
                    group.Name = entity.Name;
                    group.MaxSize = entity.MaxSize;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
            }
        }
        public Group Get(Predicate<Group> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Groups[0];
                }
                else
                {
                    return DbContext.Groups.Find(filter);

                }
            }
            catch (Exception)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Groups;
                }
                else
                {
                    return DbContext.Groups.FindAll(filter);
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
