using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClickerClicker.DB
{
    public class DataAccess
    {
        readonly SQLiteConnection db;

        public DataAccess(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Table<User>();
        }

        public int DelUser(int id) 
        { 
            return db.Delete<User>(id); 
        }

        public int SaveUser(User user)
        {
            if (user.Id != 0)
            {
                db.Update(user);
                return user.Id;
            }
            else
                return db.Insert(user);
        }

        public int UpdateClicks(User user)
        {
            return db.Update(user);
        }
    }
}
