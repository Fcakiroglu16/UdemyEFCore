namespace UdemyEFCore.CodeFirst.DAL
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}