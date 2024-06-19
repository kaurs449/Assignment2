using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repo : IRepo
    {
        private DataContext dataContext {  get; set; }  
        public Repo() { 
            dataContext=new DataContext();
        
        
        }

        public void create<T>(T entity) where T : BaseEntity
        {
           var dbSet= dataContext.Set<T>();
            entity.DateTime = DateTime.Now;
            entity.DateTime = DateTime.Now;
            dbSet.Add(entity);
            dataContext.SaveChanges();
        }

        public T Read<T>(int id) where T : BaseEntity
        {
            var dbSet =dataContext.Set<T>();
            var entity =dbSet.FirstOrDefault(x => x.Id == id);
            if(entity != null)
            {
                return entity;
            }
            else {
                Console.WriteLine("Select a valid id");
                return null;
}
        }

        public void update<T>(T entity) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            var foundEntity = dbSet.First(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                entity.DateTime = DateTime.Now;
                foundEntity = entity;
                dataContext.SaveChanges();
            }
        }

        public void delete<T>(int id) where T : BaseEntity
        {
            var dbSet = dataContext.Set<T>();
            var entity=dbSet.First(x => x.Id == id);
            if (entity != null) {
                entity.IsDeleted = true;
            }
            dataContext.SaveChanges();
        }
    }
}
