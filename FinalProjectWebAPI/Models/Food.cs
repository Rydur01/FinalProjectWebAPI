using System.Collections.Generic;
using System.Reflection.Emit;

namespace FinalProjectWebAPI.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string? Name { get; set; }
        public string? Group { get; set; }
        public double Price { get; set; }
        public int Calories { get; set; }
    }
}

