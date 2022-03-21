using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ClickerClicker.DB
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Unique]
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int Clicks { get; set; }
        public int Balance { get; set; }
    }
}
