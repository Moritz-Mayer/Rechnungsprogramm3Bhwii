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
            Produkt newProdukt = new Produkt();
            newProdukt.produktId = (int)reader["produktId"];
            newProdukt.breite = (int)reader["produktId"];
            newProdukt.normpreis = (double)reader["produktId"];
            newProdukt.hoehe = (int)reader["produktId"];
            newProdukt.name = (string)reader["produktId"];
            newProdukt.laenge = (int)reader["produktId"];

        }
        //Datensätze in Objekte umwandeln 
        //mit Return zurückfügen
        myConnection.Close();
        return new List<Produkt>();
    }

    public void CreateProdukt(Produkt produkt)
    {
        
    }

    public void DeleteProdukt (int produktId)
    {
        
    }

    public void UpdateProdukt(Produkt produkt)
    {
        
    }
    
}

