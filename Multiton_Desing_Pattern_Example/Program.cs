

var mssql = Database.GetInstance("MSSQL");
mssql.ConnectionString("ASDASD");

var oracle = Database.GetInstance("Oracle","ASDASD");




var mssql2 = Database.GetInstance("MSSQL");
var oracle2 = Database.GetInstance("Oracle");

class Database
{
    Database()
    {
        Console.WriteLine($"{nameof(Database)} nesnesi oluşturuldu");

    }

    //static Database _database;
    static Dictionary<string, Database> _databases = new();
    public static Database GetInstance(string key)
    {
        if (!_databases.ContainsKey(key))
            _databases[key] = new Database();

        return _databases[key];
    }

    public static Database GetInstance(string key,string connectionString)
    {
       Database database =  GetInstance(key);
        database.ConnectionString(connectionString);
        return database;
        //.....
    }


    public void ConnectionString(string connectionString) { } 
}
