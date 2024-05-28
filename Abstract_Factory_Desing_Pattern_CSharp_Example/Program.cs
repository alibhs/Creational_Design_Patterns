

DatabaseCreator creator = new();
Database database = creator.Create(new OracleDatabaseFactory());


enum DatabaseType
{
    Oracle,
    MSSql,
    MySql,
    PostgreSql
}
class Database
{
    public Database()
    {
        
    }
    public Database(DatabaseType type, Connection connection, Command command)
    {
        Type=type;
        Connection=connection;
        Command=command;
    }

    public DatabaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }
}

enum ConnectionState
{
    Open,Close
}

#region Abstract Product
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState State { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();

}

abstract class AbstractCommand
{
    public abstract void Execute(string query);
}


#endregion

#region Concrete Product
class Connection : AbstractConnection
{
    string _connectionString;
    public Connection()
    {

    }
    public Connection(string connectionString) => _connectionString = connectionString;

    public override  string ConnectionString { get => _connectionString,set => _connectionString = value; }

    public override ConnectionState State  { get; set; }
    public override bool Connect()
    {
        //..işlemler
        State = ConnectionState.Open;
        return true;
    }

    public override bool Disconnect()
    {
        //..işlemler
        State = ConnectionState.Close;

        return true;
    }
}

class Command : AbstractCommand
{
    public override void Execute(string query)
    {
        //..executing...
    }
}
#endregion

#region Abstract Factory
abstract class DatabaseFactory
{
    public abstract AbstractConnection CreateConnection();
    public abstract AbstractCommand CreateCommand();

}
#endregion

#region Concrete Factory
class MsSqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MsSqlDatabase";
        return connection;
    }
}

class OracleDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "OracleDatabase";
        return connection;
    }
}
#endregion

#region Creator
class DatabaseCreator
{
    AbstractConnection _connection;
    AbstractCommand _command;
    public Database Create(DatabaseFactory databaseFactory)
    {
        _connection = databaseFactory.CreateConnection();
       _command = databaseFactory.CreateCommand();
        return new()
        {
            Command = _command,
            Connection = _connection,
            @Type = DatabaseType.MSSql
        };
    }

}
#endregion