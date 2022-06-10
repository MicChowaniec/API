using Microsoft.EntityFrameworkCore;

namespace bookingdesks.Data
{
    internal static class RoomsRepository
    {
        internal async static Task<List<Room>> GetRoomsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Rooms.ToListAsync();
            }
        }
        internal async static Task<Room> GetRoomByIdAsync(int x)
        {
            using (var db = new AppDBContext())


            {
                return await db.Rooms.FirstOrDefaultAsync(room => room.RoomId == x);
            }
        }
        internal async static Task<bool> CreateRoomAsync(Room x)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Rooms.AddAsync(x);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception exc)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> UpdateRoomAsync(Room x)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Rooms.Update(x);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception exc)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> DeleteRoomAsync(int i)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Room roomToDelete =await GetRoomByIdAsync(i);

                    db.Remove(roomToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception exc)
                {
                    return false;
                }
            }
        }
    }
} 
