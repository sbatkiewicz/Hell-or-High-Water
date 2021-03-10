using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine;

public class OperateDB : MonoBehaviour
{

    public PlayerResources PlayerManager;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerResources>();

    }

    public void LoadData(int id)
    {
        string conn = "URI=file:" + Application.dataPath + "/SaveDataDB.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * " + "FROM PlayerInfo WHERE ID = " + id + "";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            
            PlayerManager.SetFood(reader.GetInt32(1));
            PlayerManager.SetGold(reader.GetInt32(2));

            PlayerManager.SetCrewMate("sword", reader.GetInt32(3));
            PlayerManager.SetCrewMate("axe", reader.GetInt32(4));
            PlayerManager.SetCrewMate("gunner", reader.GetInt32(5));
            PlayerManager.SetCrewMate("looter", reader.GetInt32(6));
           
            PlayerManager.SetBankedGold(reader.GetInt32(7));
            PlayerManager.SetLevel(reader.GetInt32(8));
            PlayerManager.SetChoice(reader.GetInt32(9));
            PlayerManager.SetSex(reader.GetInt32(10));

            Debug.Log("Everything has been loaded.");
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    public Boolean CheckSavedData()
    {
        Boolean hasData = false;
        string conn = "URI=file:" + Application.dataPath + "/SaveDataDB.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT choice FROM PlayerInfo WHERE ID = 2";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int checkData = reader.GetInt32(0);
            if (checkData > 0)
            {
                Debug.Log("There is already saved data.");
                hasData = true;
            }

            else
            {
                Debug.Log("There is no saved data.");
            }
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        return hasData;
    }


    public void SaveData()
    {
        string conn = "URI=file:" + Application.dataPath + "/SaveDataDB.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "UPDATE PlayerInfo "+
            "SET Food = " + PlayerManager.GetFood() + "," +
            " Gold = " + PlayerManager.GetGold() + "," +
            " Sword = " + PlayerManager.GetSword() + "," +
            " Axe = " + PlayerManager.GetAxe() + "," +
            " Gunner = " + PlayerManager.GetGunner() + "," +
            " Looter = " + PlayerManager.GetLooter() + "," +
            " BankedGold = " + PlayerManager.GetBankedGold() + "," +
            " Level = " + PlayerManager.GetLevel() + "," +
            " Choice = " + PlayerManager.GetChoice() + "," +
            " Sex = " + PlayerManager.GetSex() + " " +


            "WHERE ID = 2;";
      
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        Debug.Log("Updated!");

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
