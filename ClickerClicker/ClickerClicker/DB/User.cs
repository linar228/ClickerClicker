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
        public long PhoneNum { get; set; }
        public string Email { get; set; }
        public long Clicks { get; set; }
        public long Balance { get; set; }
        public long EarnCount { get; set; }
        public int MaxLvl { get; set; }
        public int MaxDamage { get; set; }
        public int MaxUpgrades { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string UpgradeLevels { get; set; }
    }
}
