using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = 0;
        }
        public int Id { get; set; }
    }
}
