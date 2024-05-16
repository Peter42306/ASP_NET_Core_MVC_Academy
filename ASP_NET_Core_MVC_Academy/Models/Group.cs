namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Group
    {
        // инициализируется коллекция Students типа HashSet<Student>(), используется для хранения студентов в группе
        public Group()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Teacher { get; set; }
        public string? EMail { get; set; }

        public int AcademyId { get; set; } // внешний ключ для связи с академией, к которой принадлежит данная группа
        public Academy? Academy { get; set; } // свойство для доступа к академии, к которой принадлежит группа, группа может быть привязана только к одной академии

        public ICollection<Student> Students { get; set; } // коллекция студентов, принадлежащих к данной группе
    }
}
