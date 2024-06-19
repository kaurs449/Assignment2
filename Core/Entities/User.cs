using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string email { get; set; }
        public  string phonenumber { get; set; }

    }
}
