using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Todos
{
    public class Todo : Entity<Guid>
    {
        public string Content { get; set; }
        public bool IsDone { get; set; }
    }
}
