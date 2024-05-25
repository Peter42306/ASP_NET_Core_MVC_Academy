using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Academy
    {
        // инициализируется коллекция Groups типа HashSet<Group>(), используется для хранения групп в академии
        public Academy()
        {
            this.Groups = new HashSet<Group>();
        }

		// Идентификатор студента
		public int Id { get; set; }

		// Название академии
		[Required(ErrorMessage = "Запишите название академии")] // Обязательное поле
		[Display(Name = "Название академии")] // Отображаемое имя поля
		public string? Name { get; set; }

		// E-mail академии
		[Required(ErrorMessage = "Запишите e-mail академии")] // Обязательное поле
		[Display(Name = "E-mail академии")] // Отображаемое имя поля
		[EmailAddress] // Валидация формата email
		public string? EMail { get; set; }

        public ICollection<Group> Groups { get; set; } // коллекция групп, принадлежащих к данной академии
    }
}
