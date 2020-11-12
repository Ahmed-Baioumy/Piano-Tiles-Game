using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class DBInterface : MonoBehaviour
{
    /*private MySqlConnectionStringBuilder stringBuilder;
    public string Server;
    public string Database;
    public string UserID;
    public string Password;*/

    
    // Start is called before the first frame update
    void Start()
    {
        /*stringBuilder = new MySqlConnectionStringBuilder();
        stringBuilder.Server = Server;
        stringBuilder.Database = Database;
        stringBuilder.UserID = UserID;
        stringBuilder.Password = Password;*/
    }
    public void Insert_score(string Player_Code, int Player_Score)
    {
        string Date = DateTime.Now.ToShortDateString();
        string Time = DateTime.Now.ToShortTimeString();
        string Datetime = DateTime.Now.ToString();
        //string[] Data;
        //Data = args;
        try
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=instrumented_glove;port=3306;password=2911996");
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO instrumented_glove.gamescore (Code, GameScore,Date,Time,DateTime) VALUES ('" + Player_Code + "', '" + Convert.ToInt32(Player_Score) + "','" + Date + "','" + Time + "','" + Datetime + "')";
            command.ExecuteNonQuery();
        }
        catch { }
        /*using (MySqlConnection connection = new MySqlConnection(stringBuilder.ConnectionString))
        {
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO scores (Player_Code, Player_Score) VALUES (@Player_Code, @Player_Score)";
                command.Parameters.AddWithValue("@Player_Code", Player_Code);
                command.Parameters.AddWithValue("@Player_Score", Player_Score);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("DBInterface: Could not insert the score! " + System.Environment.NewLine + ex.Message);
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
