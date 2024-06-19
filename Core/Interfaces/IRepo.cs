using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepo
    {
         void create <T>( T entity ) where T : BaseEntity;
        T Read <T>(int id) where T : BaseEntity;
        void update <T>(T entity) where T : BaseEntity;
        void delete <T>(int id) where T : BaseEntity;

    }
}
