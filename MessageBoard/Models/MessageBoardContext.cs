using Microsoft.EntityFrameworkCore;
using System;



namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Message>()
            .HasData(
                new Message { MessageId = 1, Name = "Lunch Crew", Comment = "Burritos!!", User = "Employee_03",PostDate = "16 August 2022" },
                new Message { MessageId = 2, Name = "Soccer", Comment = "VAR sucks", User = "Employee_02", PostDate = "16 August 2022" },
                new Message { MessageId = 3, Name = "Gamers", Comment = "Play OW2!!", User = "Employee_03", PostDate = "16 August 2022" }
            );
        }

    }
}

// DateTime date1 = DateTime.Now;