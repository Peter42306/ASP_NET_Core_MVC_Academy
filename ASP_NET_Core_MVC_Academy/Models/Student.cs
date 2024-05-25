using ASP_NET_Core_MVC_Academy.Annotation;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Core_MVC_Academy.Models
{
    public class Student
    {
		// Идентификатор студента
		public int Id { get; set; }

		// Имя и фамилия студента
		[Required(ErrorMessage ="Запишите имя и фамилию студента")] // Обязательное поле
		[Display(Name ="Имя и фамилия студента")] // Отображаемое имя поля
		[MyForbiddenStudentsNames(new string[] { "Рихтер", "Страуструп", "Троэлсен", "Richter","Stroustrup","Troelsen"},ErrorMessage="Недопустимый студент")] // Проверка на недопустимые имена
        public string? Name { get; set; }

		// Возраст студента
		[Required(ErrorMessage = "Запишите возраст студента")] // Обязательное поле
		[Display(Name = "Возраст студента")] // Отображаемое имя поля
		[Range(15,80,ErrorMessage ="Недопустимый возраст")]
		public int? Age { get; set; }

		// Электронный адрес
		[Required(ErrorMessage = "Запишите e-mail студента")] // Обязательное поле
		[Display(Name = "E-mail студента")] // Отображаемое имя поля
		[EmailAddress] // Валидация формата email
		public string? EMail { get; set; }

		// внешний ключ (Foreign Key), который связывает студента с его группой
		[Display(Name = "Группа")] // Отображаемое имя поля
		public int GroupId { get; set; }

		// Навигационное свойство для группы
		public Group? Group { get; set; } // свойство для доступа к группе, к которой принадлежит студент, студент может быть привязан только к одной группе 

		/* !!! НАПОМИНАЛКА !!!
		 * 
	   [DataType(DataType.Password)]
	   public string Password { get; set; }

	   [Compare("Password",ErrorMessage="Пароли не совпадают")]
	   [DataType(DataType.Password)]
	   public  string PasswordConfirm { get; set; }

	   Currency Отображает текст в виде валюты
	   DateTime Отображает дату и время
	   Date Отображает только дату, без времени
	   Time Отображает только время
	   Text Отображает однострочный текст
	   MultilineText Отображает многострочный текст (элемент textarea)
	   Password Отображает символы с использованием маски
	   Url  Отображает строку URL
	   EmailAddress Отображает электронный адрес
		* */
	}
}
