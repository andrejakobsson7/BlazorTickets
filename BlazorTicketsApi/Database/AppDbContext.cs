using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorTicketsApi.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<ResponseModel> Responses { get; set; }
		public DbSet<TagModel> Tags { get; set; }
		public DbSet<TicketModel> Tickets { get; set; }
		public DbSet<TicketTag> TicketTags { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Set relationship for join table
			modelBuilder.Entity<TicketTag>().HasKey(tt => new { tt.TicketId, tt.TagId });

			//Set one-to-many relationship for ticket and responses
			modelBuilder.Entity<ResponseModel>()
				.HasOne(t => t.Ticket)
				.WithMany(t => t.Responses)
				.HasForeignKey(t => t.TicketId);

			//Set many-to-many relationship between Ticket and Tag
			modelBuilder.Entity<TicketTag>()
				.HasOne(tt => tt.Ticket)
				.WithMany(t => t.TicketTags)
				.HasForeignKey(t => t.TicketId);

			modelBuilder.Entity<TicketTag>().
				HasOne(tt => tt.Tag)
				.WithMany(t => t.TicketTags)
				.HasForeignKey(t => t.TagId);

			//Seed data
			modelBuilder.Entity<TicketModel>().HasData(
				new TicketModel()
				{
					Id = 1,
					Title = "Bug Fix",
					Description = "Application crashes on startup.",
					SubmittedBy = "John Doe",
					IsResolved = true
				},
				new TicketModel()
				{
					Id = 2,
					Title = "Feature Request",
					Description = "Add dark mode to settings.",
					SubmittedBy = "Alice Smith",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 3,
					Title = "Database Connection Issue",
					Description = "Users are unable to connect to the database server.",
					SubmittedBy = "Emily Johnson",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 4,
					Title = "UI Enhancement",
					Description = "Improve button styling on the login page.",
					SubmittedBy = "Mark Adams",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 5,
					Title = "Performance Optimization",
					Description = "Application response time is slow during data retrieval.",
					SubmittedBy = "Alex Chen",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 6,
					Title = "Missing Feature",
					Description = "Add export functionality for user data.",
					SubmittedBy = "Laura Lee",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 7,
					Title = "Broken Link",
					Description = "The \"Contact Us\" link leads to a 404 page.",
					SubmittedBy = "Michael Brown",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 8,
					Title = "Security Concern",
					Description = "Vulnerability in authentication process.",
					SubmittedBy = "Sophia Rodriguez",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 9,
					Title = "Localization Issue",
					Description = "Incorrect translations in the French version.",
					SubmittedBy = "Pierre Dupont",
					IsResolved = false
				},
				new TicketModel()
				{
					Id = 10,
					Title = "Data Import Error",
					Description = "CSV import fails for large datasets.",
					SubmittedBy = "Grace Liu",
					IsResolved = false
				});
			modelBuilder.Entity<ResponseModel>().HasData(
				new ResponseModel()
				{
					Id = 1,
					Response = "Thank you for reporting the issue.",
					SubmittedBy = "Support Team",
					TicketId = 3
				},
				new ResponseModel()
				{
					Id = 2,
					Response = "We have escalated your feature request.",
					SubmittedBy = "Product Manager",
					TicketId = 2
				},

				new ResponseModel()
				{
					Id = 3,
					Response = "Investigating the database connection issue.",
					SubmittedBy = "Database Administrator",
					TicketId = 1
				},

				new ResponseModel()
				{
					Id = 4,
					Response = "UI enhancement task assigned to design team.",
					SubmittedBy = "Project Lead",
					TicketId = 4
				},

				new ResponseModel()
				{
					Id = 5,
					Response = "Security vulnerability patched.",
					SubmittedBy = "Security Analyst",
					TicketId = 5
				});
			modelBuilder.Entity<TagModel>().HasData(
				new TagModel()
				{
					Id = 1,
					Name = "Python"
				},
				new TagModel()
				{
					Id = 2,
					Name = "CSharp"
				},
				new TagModel()
				{
					Id = 3,
					Name = "WebDevelopment"
				},
				new TagModel()
				{
					Id = 4,
					Name = "DataStructures"
				},
				new TagModel()
				{
					Id = 5,
					Name = "JavaScript"
				});
			modelBuilder.Entity<TicketTag>().HasData(
				new TicketTag()
				{
					TicketId = 1,
					TagId = 5,
				},
				new TicketTag()
				{
					TicketId = 1,
					TagId = 4
				},
				new TicketTag()
				{
					TicketId = 10,
					TagId = 1
				},
				new TicketTag()
				{
					TicketId = 6,
					TagId = 2
				},
				new TicketTag()
				{
					TicketId = 6,
					TagId = 5
				},
				new TicketTag()
				{
					TicketId = 6,
					TagId = 3
				},
				new TicketTag()
				{
					TicketId = 9,
					TagId = 3
				});
		}
	}
}
