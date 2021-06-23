using System;
using System.Collections.Generic;
using System.Text;

namespace CoinpaprikaApp.Models
{    public class OhlcvToday
    {
        private DateTime _time_open;        
        private DateTime _time_close;
        private decimal _open;
        private decimal _close;
        private decimal _high;
        private decimal _low;
        private decimal _volume;
        private decimal _market_cap;

        public DateTime Time_Open { get { return _time_open; } set { _time_open = value; } }
        public DateTime Time_Close { get { return _time_close; } set { _time_close= value; } }
        public decimal Open { get { return _open; } set { _open = value; } }
        public decimal High { get { return _high; } set { _high = value; } }
        public decimal Low { get { return _low; } set { _low = value; } }
        public decimal Close { get { return _close; } set { _close = value; } }
        public decimal Volume { get { return _volume; } set { _volume = value; } }
        public decimal Market_Cap { get { return _market_cap; } set { _market_cap = value; } }
    }
}
