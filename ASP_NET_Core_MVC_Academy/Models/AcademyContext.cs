﻿using Microsoft.EntityFrameworkCore;
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

			// Добавление начальных данных
			modelBuilder.Entity<Academy>().HasData(
				new Academy { Id = 1, Name = "Академия 1", EMail = "emailAcademy1@gmail.com" }
			);
		}
	}
}
