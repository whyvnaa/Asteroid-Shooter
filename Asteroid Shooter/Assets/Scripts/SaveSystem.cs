using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData gameData = new GameData(playerData);
        try 
        {
            formatter.Serialize(stream, gameData);
        }
        finally
        {
            stream.Close();
        }
    }

    public static GameData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.fun");
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            try
            {
                GameData data = formatter.Deserialize(stream) as GameData;
                Debug.Log("loaded data: " + data);
                return data;
            }
            finally
            {
                stream.Close();
            }
            
        }
        else
        {
            Debug.LogError("Savefile not found in: " + path);
            return null;
        }
    }
}
