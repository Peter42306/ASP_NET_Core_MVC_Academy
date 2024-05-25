using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASP_NET_Core_MVC_Academy.Models
{
    public class AcademyContext : DbContext
    {
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Academy> Academies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			int academyNumber = 4;
			int groupsPerAcademyMin = 3;
			int groupsPerAcademyMax = 7;
			int studentsPerGroupMin = 5;
			int studentsPerGroupMax = 10;
			int studentAgeMin = 18;
			int studentAgeMax = 30;

			Random random = new Random();

			int academyId = 1;
			int groupId = 1;
			int studentId = 1;			
			int groupPerAcademy;
			int studentsPerGroup;
			int studentAge;

			for (int i = 1; i <= academyNumber; i++)
			{
				modelBuilder.Entity<Academy>().HasData(new Academy { Id = academyId, Name = $"Academy {i}", EMail = $"academy_{i}@.gmail" });

				groupPerAcademy = random.Next(groupsPerAcademyMin, groupsPerAcademyMax);
				
				for (int j = 1; j <= groupPerAcademy; j++)
				{
					//modelBuilder.Entity<Group>().HasData(new Group { Id = groupId, Name = $"Group {i}-{j}", Teacher = $"Teacher {groupId}", EMail = $"academy_{i}_Group_{i}-{j}@.gmail.com", AcademyId = academyId });
					modelBuilder.Entity<Group>().HasData(new Group { Id = groupId, Name = $"Group {i}-{j}", Teacher = $"Teacher {groupId}", EMail = $"academy_{i}_Group_{i}-{j}@.gmail.com", AcademyId = academyId });

					studentsPerGroup = random.Next(studentsPerGroupMin, studentsPerGroupMax);

					for (int k = 1; k <= studentsPerGroup; k++)
					{
						studentAge = random.Next(studentAgeMin, studentAgeMax);

						//modelBuilder.Entity<Student>().HasData(new Student { Id = studentId, Name = $"Student {studentId}", Age = studentAge, EMail = $"academy_{i}_group_{i}-{j}_student_{studentId}@.gmail.com", GroupId = groupId });
						modelBuilder.Entity<Student>().HasData(new Student { Id = studentId, Name = $"Student {studentId}", Age = studentAge, EMail = $"student_{studentId}@.gmail.com", GroupId = groupId });

						studentId++;
					}

					groupId++; // Увеличиваем groupId для следующей группы
				}				
				academyId++; // Увеличиваем academyId для следующей академии
			}



			//for (int i = 1; i <= academyNumber; i++)
			//{
			//	modelBuilder.Entity<Academy>().HasData(new Academy { Id = academyId, Name = $"Академия {academyId}", EMail = $"emailAcademy_{academyId}" });

			//	groupPerAcademy = random.Next(groupsPerAcademyMin, groupsPerAcademyMax);

			//	for (int j = 0; j <= groupPerAcademy; j++)
			//	{
			//		modelBuilder.Entity<Group>().HasData(new Group { Id = groupId, Name = $"Группа {j}", Teacher = $"Учитель {teacherId}", EMail = $"emailAcademy_{academyId}_Group_{groupId}.gmail.com",AcademyId=academyId });

			//		studentsPerGroup = random.Next(studentsPerGroupMin, studentsPerGroupMax);

			//		for (int k = 0; k <= studentsPerGroup; k++)
			//		{
			//			studentAge = random.Next(studentAgeMin, studentAgeMax);

			//			modelBuilder.Entity<Student>().HasData(new Student { Id = studentId, Name = $"Student {studentId}", Age = studentAge, EMail = $"emailAcademy_{academyId}_Group_{groupId}_Student_{studentId}.gmail.com",GroupId=groupId });

			//			studentId++;
			//		}

			//		groupId++;
			//	}

			//	academyId++;
			//}


			//// Добавление начальных данных для академий
			//modelBuilder.Entity<Academy>().HasData(
			//	new Academy { Id = 1, Name = "Академия 1", EMail = "emailAcademy_1@gmail.com" },
			//	new Academy { Id = 2, Name = "Академия 2", EMail = "emailAcademy_2@gmail.com" },
			//	new Academy { Id = 3, Name = "Академия 3", EMail = "emailAcademy_3@gmail.com" }
			//	);

			//// Добавление начальных данных для групп
			//modelBuilder.Entity<Group>().HasData(
			//	new Group { Id = 1, Name = "Группа 1", Teacher = "Учитель 1", EMail = "emailAcademy_1_Group_1@gmail.com", AcademyId = 1 },
			//	new Group { Id = 2, Name = "Группа 2", Teacher = "Учитель 2", EMail = "emailAcademy_1_Group_2@gmail.com", AcademyId = 1 },
			//	new Group { Id = 3, Name = "Группа 3", Teacher = "Учитель 3", EMail = "emailAcademy_1_Group_3@gmail.com", AcademyId = 1 },
			//	new Group { Id = 4, Name = "Группа 4", Teacher = "Учитель 4", EMail = "emailAcademy_1_Group_4@gmail.com", AcademyId = 1 },
			//	new Group { Id = 5, Name = "Группа 1", Teacher = "Учитель 5", EMail = "emailAcademy_2_Group_1@gmail.com", AcademyId = 2 },
			//	new Group { Id = 6, Name = "Группа 2", Teacher = "Учитель 6", EMail = "emailAcademy_2_Group_2@gmail.com", AcademyId = 2 },
			//	new Group { Id = 7, Name = "Группа 3", Teacher = "Учитель 7", EMail = "emailAcademy_2_Group_3@gmail.com", AcademyId = 2 },
			//	new Group { Id = 8, Name = "Группа 1", Teacher = "Учитель 8", EMail = "emailAcademy_3_Group_1@gmail.com", AcademyId = 3 },
			//	new Group { Id = 9, Name = "Группа 2", Teacher = "Учитель 9", EMail = "emailAcademy_3_Group_2@gmail.com", AcademyId = 3 },
			//	new Group { Id = 10, Name = "Группа 3", Teacher = "Учитель 10", EMail = "emailAcademy_3_Group_3@gmail.com", AcademyId = 3 },
			//	new Group { Id = 11, Name = "Группа 4", Teacher = "Учитель 11", EMail = "emailAcademy_3_Group_4@gmail.com", AcademyId = 3 },
			//	new Group { Id = 12, Name = "Группа 5", Teacher = "Учитель 12", EMail = "emailAcademy_3_Group_5@gmail.com", AcademyId = 3 }
			//	);

			//// Добавление начальных данных для студентов
			//modelBuilder.Entity<Student>().HasData(
			//	new Student { Id = 1, Name = "Студент 1", Age = 24, EMail = "emailStudent_1@gmail.com", GroupId = 1 },
			//	new Student { Id = 2, Name = "Студент 2", Age = 24, EMail = "emailStudent_2@gmail.com", GroupId = 1 },
			//	new Student { Id = 3, Name = "Студент 3", Age = 24, EMail = "emailStudent_3@gmail.com", GroupId = 2 },
			//	new Student { Id = 4, Name = "Студент 4", Age = 24, EMail = "emailStudent_4@gmail.com", GroupId = 2 },
			//	new Student { Id = 5, Name = "Студент 5", Age = 24, EMail = "emailStudent_5@gmail.com", GroupId = 3 },
			//	new Student { Id = 6, Name = "Студент 6", Age = 24, EMail = "emailStudent_6@gmail.com", GroupId = 3 },
			//	new Student { Id = 7, Name = "Студент 7", Age = 24, EMail = "emailStudent_7@gmail.com", GroupId = 4 },
			//	new Student { Id = 8, Name = "Студент 8", Age = 24, EMail = "emailStudent_8@gmail.com", GroupId = 4 },
			//	new Student { Id = 9, Name = "Студент 9", Age = 24, EMail = "emailStudent_9@gmail.com", GroupId = 5 },
			//	new Student { Id = 10, Name = "Студент 10", Age = 24, EMail = "emailStudent_10@gmail.com", GroupId = 5 },
			//	new Student { Id = 11, Name = "Студент 11", Age = 24, EMail = "emailStudent_11@gmail.com", GroupId = 6 },
			//	new Student { Id = 12, Name = "Студент 12", Age = 24, EMail = "emailStudent_12@gmail.com", GroupId = 6 },
			//	new Student { Id = 13, Name = "Студент 13", Age = 24, EMail = "emailStudent_13@gmail.com", GroupId = 7 },
			//	new Student { Id = 14, Name = "Студент 14", Age = 24, EMail = "emailStudent_14@gmail.com", GroupId = 7 },
			//	new Student { Id = 15, Name = "Студент 15", Age = 24, EMail = "emailStudent_15@gmail.com", GroupId = 8 },
			//	new Student { Id = 16, Name = "Студент 16", Age = 24, EMail = "emailStudent_16@gmail.com", GroupId = 8 },
			//	new Student { Id = 17, Name = "Студент 17", Age = 24, EMail = "emailStudent_17@gmail.com", GroupId = 9 },
			//	new Student { Id = 18, Name = "Студент 18", Age = 24, EMail = "emailStudent_18@gmail.com", GroupId = 9 },
			//	new Student { Id = 19, Name = "Студент 19", Age = 24, EMail = "emailStudent_19@gmail.com", GroupId = 10 },
			//	new Student { Id = 20, Name = "Студент 20", Age = 24, EMail = "emailStudent_20@gmail.com", GroupId = 10 },
			//	new Student { Id = 21, Name = "Студент 21", Age = 24, EMail = "emailStudent_21@gmail.com", GroupId = 11 },
			//	new Student { Id = 22, Name = "Студент 22", Age = 24, EMail = "emailStudent_22@gmail.com", GroupId = 11 },
			//	new Student { Id = 23, Name = "Студент 23", Age = 24, EMail = "emailStudent_23@gmail.com", GroupId = 12 },
			//	new Student { Id = 24, Name = "Студент 24", Age = 24, EMail = "emailStudent_24@gmail.com", GroupId = 12 }
			//	);
		}
	}
}
