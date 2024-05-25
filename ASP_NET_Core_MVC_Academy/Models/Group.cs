using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Group
    {
        // инициализируется коллекция Students типа HashSet<Student>(), используется для хранения студентов в группе
        public Group()
        {
            this.Students = new HashSet<Student>();
        }

		// Идентификатор студента
		public int Id { get; set; }

		// Название группы
		[Required(ErrorMessage = "Запишите название группы")] // Обязательное поле
		[Display(Name = "Название группы")] // Отображаемое имя поля
		public string? Name { get; set; }

		// Имя и фамилия ведущего преподавателя группы
		[Required(ErrorMessage = "Запишите имя и фамилию ведущего преподавателя группы")] // Обязательное поле
		[Display(Name = "Имя и фамилия ведущего преподавателя группы")] // Отображаемое имя поля
		public string? Teacher { get; set; }

		// E-mail группы
		[Required(ErrorMessage = "Запишите e-mail группы")] // Обязательное поле
		[Display(Name = "E-mail группы")] // Отображаемое имя поля
		[EmailAddress] // Валидация формата email
		public string? EMail { get; set; }

		// внешний ключ для связи с академией, к которой принадлежит данная группа
		[Display(Name = "К какой академии относится группа")] // Обязательное поле
		public int AcademyId { get; set; }

		// свойство для доступа к академии, к которой принадлежит группа, группа может быть привязана только к одной академии
		public Academy? Academy { get; set; }

		// коллекция студентов, принадлежащих к данной группе
		public ICollection<Student> Students { get; set; } 
    }
}
