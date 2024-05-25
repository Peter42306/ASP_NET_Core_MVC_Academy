using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Core_MVC_Academy.Annotation
{
	public class MyForbiddenStudentsNamesAttribute:ValidationAttribute
	{
		// Поле для хранения запрещенных имен студентов.
		// В конструкторе атрибута устанавливается значение этого поля из переданного массива запрещенных имен
		private static string[] myForbiddenStudentsNames;

        public MyForbiddenStudentsNamesAttribute(string[] ForbiddenStudentsNames)
        {
            myForbiddenStudentsNames = ForbiddenStudentsNames;
        }

		// метод выполняет проверку значения на соответствие запрещенным именам
		public override bool IsValid(object? value)
		{
			if (value!=null)
			{
				// Получаем строковое представление значения
				string? stringValue=value.ToString();

				foreach (var forbiddenName in myForbiddenStudentsNames)
				{
					if (stringValue==forbiddenName)
					{
						return false; // значение равно одному из запрещенных имен, не проходит валидацию
					}
				}				
			}
			return true; // значение не равно одному из запрещенных имен, проходит валидацию
		}
	}
}
