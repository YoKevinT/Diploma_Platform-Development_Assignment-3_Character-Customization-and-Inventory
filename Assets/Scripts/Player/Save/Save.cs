using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save // Static -> "Only one" That saves
{
    public static void SaveData(Player player)
    {
        // Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        // Save Path
        // string path = Application.persistentDataPath + "/" + player.name + ".format";
        string path = Application.persistentDataPath + "/TheCakeIsALie.format";
        // File Stream
        FileStream stream = new FileStream(path, FileMode.Create);
        // Data
        Data data = new Data(player);
        // Converts to Binary and dave the path
        formatter.Serialize(stream, data);
        // End
        stream.Close();
    }

    public static Data LoadData()
    {
        // Have a Path
        string path = Application.persistentDataPath + "/TheCakeIsALie.format";
        // Check to see if the path exists
        if (File.Exists(path))
        {
            // Formatter
            BinaryFormatter formatter = new BinaryFormatter();
            // Stream Open
            FileStream stream = new FileStream(path, FileMode.Open);
            // Data Deserialize
            Data data = formatter.Deserialize(stream) as Data;
            // End
            stream.Close();
            // Return
            return data;
        }
        // Else
        else
        {

            // Debug Error
            Debug.Log("Error");
            // Return Null
            return null;
        }
    }
}