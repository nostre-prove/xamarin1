using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Services
{
    public class ItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Post>().Wait();
        }

        public Task<List<Post>> GetItemsAsync()
        {
            return database.Table<Post>().ToListAsync();
        }

        public Task<List<Post>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Post>("SELECT * FROM [Post] WHERE [id] < 10");
        }

        public Task<Post> GetItemAsync(int id)
        {
            return database.Table<Post>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Post item)
        {
            return database.InsertAsync(item);
            /*
                if (item.id != 0)
            {
                Console.WriteLine("added");
                return database.UpdateAsync(item);
            }
            else 
            {
                return database.InsertAsync(item);
            }
            */
        }

        public Task<int> DeleteItemAsync(Post item)
        {
            return database.DeleteAsync(item);
        }
    }
}
