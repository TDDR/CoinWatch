using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using SQLite;

namespace CoinpaprikaApp.Models
{
    public class DBTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _coiniD;
        private DateTime _favoredOn;
        public string CoinID { get { return _coiniD; } set { _coiniD = value; } }
        public DateTime FavoredOn { get { return _favoredOn; } set { _favoredOn = value; } }
    }
}
