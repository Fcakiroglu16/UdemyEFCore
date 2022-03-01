using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}