using Npgsql;
using RechnungsprogrammWebApplication.Models;

namespace RechnungsprogrammWebApplication.Repositories;

public class Produktrepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=RechnungsprogramDatabase;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
        
    public List<Produkt> GetAllProdukte()
    {
        //Connect to DB
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL QUery ausführern
        
        using NpgsqlCommand cmd = new NpgsqlCommand(cmdText:"select * from Produkt", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        List<Produkt> produkts = new List<Produkt>();
        while (reader.Read())
        {
        //Datensätze in Objekte umwandeln 
            Produkt newProdukt = new Produkt();
            newProdukt.produktId = (int)reader["produktId"];
            newProdukt.name = (string)reader["name"];
            newProdukt.laenge = (double)reader["laenge"];
            newProdukt.breite = (double)reader["breite"];
            newProdukt.hoehe = (double)reader["hoehe"];
            newProdukt.normpreis = (double)reader["normalpreis"];
            
            produkts.Add(newProdukt);
        }
        //mit Return zurückfügen
        myConnection.Close();
        return produkts;
    }

    public void CreateProdukt(Produkt produkt)
    {
        NpgsqlConnection myConnection = ConnectToDB();
        
        using NpgsqlCommand cmd = new NpgsqlCommand(
            "INSERT INTO produkt (name, normalpreis, laenge, breite, hoehe) VALUES (:v1, :v2, :v3, :v4, :v5)", myConnection);
        cmd.Parameters.AddWithValue("v1", produkt.name);
        cmd.Parameters.AddWithValue("v2", produkt.laenge);
        cmd.Parameters.AddWithValue("v3", produkt.breite);
        cmd.Parameters.AddWithValue("v4", produkt.hoehe);
        cmd.Parameters.AddWithValue("v5", produkt.normpreis);


        int rowsAffected = cmd.ExecuteNonQuery();
        myConnection.Close();
    }

    public void DeleteProdukt (int produktId)
    {
            
    }

    public void UpdateProdukt(Produkt produkt)
    {
        
    }
    
}

