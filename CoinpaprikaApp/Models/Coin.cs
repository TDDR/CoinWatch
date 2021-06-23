using System;

namespace CoinpaprikaApp.Models
{
    public class Coin
    {
        private string _id;
        private string _name;
        private string _symbol;
        private int _rank;
        private bool _is_new;
        private bool _is_active;
        private string _type;

        private OhlcvToday _currentNumbers = new OhlcvToday();

        private string _description;
        private bool _open_source;
        private DateTime _started_at;
        private string _development_status;
        private string _proof_type;
        private string _org_structure;
        private string _hash_algorithm;
        private DateTime _first_data_at;
        private DateTime _last_data_at;

        public string Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Symbol { get { return _symbol; } set { _symbol = value; } }
        public int Rank { get { return _rank; } set { _rank = value; } }
        public bool Is_New { get { return _is_new; } set { _is_new = value; } }
        public bool Is_Active { get { return _is_active; } set { _is_active = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public OhlcvToday CurrentNumbers { get { return _currentNumbers; } set { _currentNumbers = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public bool Open_Source { get { return _open_source; } set { _open_source = value; } }
        public DateTime Started_At { get { return _started_at; } set { _started_at = value; } }
        public string Development_Status { get { return _development_status; } set { _development_status = value; } }
        public string Proof_Type { get { return _proof_type; } set { _proof_type = value; } }
        public string Org_Structure { get { return _org_structure; } set { _org_structure = value; } }
        public string Hash_Algorithm { get { return _hash_algorithm; } set { _hash_algorithm = value; } }
        public DateTime First_Data_At { get { return _first_data_at; } set { _first_data_at = value; } }
        public DateTime Last_Data_At { get { return _last_data_at; } set { _last_data_at = value; } }
    }
}
