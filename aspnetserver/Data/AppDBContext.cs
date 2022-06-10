using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDBContext :DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Room[] roomsToSeed = new Room[6];

            for (int i=1;i<=6;i++)
            {
                roomsToSeed[i - 1] = new Room
                {
                    RoomId = i,
                    Title = $"Room {i}",
                    Content = $"This is room {i} and it has some very interesting content. Bla bla bla "
                };
            }
            modelBuilder.Entity<Room>().HasData(data: roomsToSeed);
        }
    }

}
