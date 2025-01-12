﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //string path = Application.persistentDataPath + "/player.savedgame";
        string path = Path.Combine(Application.persistentDataPath, "player.savedgame");
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.savedgame";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            //print("no save file found");
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static bool DeleteSaveFile()
    {
        string path = Application.persistentDataPath + "/player.savedgame";
        bool deleted = false;
        if (File.Exists(path))
        {
            File.Delete(path);
            deleted = true;
        }
        return deleted;
    }
}
