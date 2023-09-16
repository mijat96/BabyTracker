using BabyTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTracker.SQLlite
{
    public class BabyEventDataBase
    {
        SQLiteAsyncConnection Database;

        public BabyEventDataBase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<BabyEvent>();
        }

        public async Task<List<BabyEvent>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<BabyEvent>().ToListAsync();
        }

        public async Task<BabyEvent> GetItemAsync(DateTime time)
        {
            await Init();
            return await Database.Table<BabyEvent>().Where(i => i.EventTime == time).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(BabyEvent item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(BabyEvent item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
