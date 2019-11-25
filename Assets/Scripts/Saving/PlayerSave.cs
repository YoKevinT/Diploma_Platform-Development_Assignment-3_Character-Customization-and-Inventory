using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class PlayerSave // Static -> "Only one" That saves
{
    public static void SaveData(CustomisationSet customisationset)
    {
        // Binary Formatter
        BinaryFormatter formatter = new BinaryFormatter();
        // Save Path
        // string path = Application.persistentDataPath + "/" + player.name + ".format";
        string path = Application.persistentDataPath + "/TheCakeIsALie.format";
        // File Stream
        FileStream stream = new FileStream(path, FileMode.Create);
        // Data
        PlayerData playerdata = new PlayerData(customisationset);
        // Converts to Binary and dave the path
        formatter.Serialize(stream, playerdata);
        // End
        stream.Close();
    }

    public static PlayerData LoadData()
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
            PlayerData playerdata = formatter.Deserialize(stream) as PlayerData;
            // End
            stream.Close();
            // Return
            return playerdata;
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