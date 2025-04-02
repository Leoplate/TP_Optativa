using System.Data.Common;


namespace TP1.Service
{
    public class MySqlConfiguration
    {
        
        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; } = string.Empty;

    }
}
