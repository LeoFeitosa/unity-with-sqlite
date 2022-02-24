using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataHero : MonoBehaviour
{
    Database _database;
    string _tableName;

    [SerializeField] TMP_InputField _name;

    void Awake()
    {
        _tableName = "Hero";
    }

    void Start()
    {
        _database = new Database("DatabaseHeroes");
        _database.Connect();
        _database.CreateTable(this._tableName, "id INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR(50)");
    }

    public void InsertName()
    {
        _database.InsertData("name", _name.text.Trim());
    }
}
