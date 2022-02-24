using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System;

public class Database
{
    private IDbConnection _connection;
    private IDbCommand _command;
    private IDataReader _reader;
    private string _databasePath = "";
    private string _databaseName = "";
    private string _tableName = "";

    public Database(string databaseName)
    {
        _databaseName = databaseName;
        _databasePath = $"URI=file:{_databaseName}.db";
    }

    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        if (File.Exists(_databaseName))
            return;

        _connection = new SqliteConnection(_databasePath);
        _command = _connection.CreateCommand();
    }

    public void CreateTable(string tableName, string columns)
    {
        using IDbConnection connection = new SqliteConnection(_databasePath);
        connection.Open();

        using (IDbCommand command = connection.CreateCommand())
        {
            string sql = $"CREATE TABLE IF NOT EXISTS {tableName}({columns})";
            command.CommandText = sql;
            command.ExecuteNonQuery();

            _tableName = tableName;
        }

        connection.Close();
    }

    public void InsertData(string columns, string data)
    {
        using IDbConnection connection = new SqliteConnection(_databasePath);
        connection.Open();

        using (IDbCommand command = connection.CreateCommand())
        {
            string sql = $"INSERT INTO {_tableName} ({columns}) VALUES ('{data}')";
            Console.WriteLine(sql);
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        connection.Close();
    }

    public void UpdateData()
    {

    }

    public void DeleteData()
    {

    }

    public void ListData()
    {

    }

    public void FetchData()
    {

    }
}
