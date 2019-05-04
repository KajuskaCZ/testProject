using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ToDoModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Check { get; set; }
    }
}
