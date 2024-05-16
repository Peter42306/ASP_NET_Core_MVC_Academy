namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? EMail { get; set; }

        public int GroupId { get; set; } // внешний ключ (Foreign Key), который связывает студента с его группой
        public Group? Group { get; set; } // свойство для доступа к группе, к которой принадлежит студент, студент может быть привязан только к одной группе 
    }
}
