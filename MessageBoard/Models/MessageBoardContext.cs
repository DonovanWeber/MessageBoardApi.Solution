using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions<MessageBoardContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Message>()
            .HasData(
                new Message { MessageId = 1, Name = "Lunch Crew", Comment = "Burritos!!", User = "Employee_03" },
                new Message { MessageId = 2, Name = "Soccer", Comment = "VAR sucks", User = "Employee_02" },
                new Message { MessageId = 3, Name = "Gamers", Comment = "Play OW2!!", User = "Employee_03" }
            );
        }

        public DbSet<Message> Messages { get; set; }
    }
}

// DateTime date1 = DateTime.Now;