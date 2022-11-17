using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWebAPI.Controllers
{
    public class Hobbies
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Hobby { get; set; }
        public string? Reason { get; set; }
        public string? Days { get; set; }
    }
   
}
