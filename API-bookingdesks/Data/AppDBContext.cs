using Microsoft.EntityFrameworkCore;

namespace bookingdesks.Data
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
                    Adress = $"Room {i}",
                    NumberOfDesks = 7
                };
            }
            modelBuilder.Entity<Room>().HasData(data: roomsToSeed);
        }
    }

}
