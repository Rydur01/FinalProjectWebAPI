using System.Collections.Generic;
using System.Reflection.Emit;

namespace FinalProjectWebAPI.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DueDate { get; set; }
    }
}

