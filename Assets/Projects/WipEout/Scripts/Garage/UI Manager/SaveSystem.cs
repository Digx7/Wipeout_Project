using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{


    public static void Initialization (string name)
    {
      string path = Application.persistentDataPath + name;
      Directory.CreateDirectory(path);
    }

    public static void SavePlayerData (PlayerSaveData saveData)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/WipeoutClone/PlayerData.save";
      FileStream stream = new FileStream(path, FileMode.Create);

      formatter.Serialize(stream, saveData);
      stream.Close();
    }

    public static PlayerSaveData LoadPlayerData ()
    {
        string path = Application.persistentDataPath + "/WipeoutClone/PlayerData.save";
        if(File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter();
          FileStream stream = new FileStream(path, FileMode.Open);

          PlayerSaveData saveData = formatter.Deserialize(stream) as PlayerSaveData;
          stream.Close();

          return saveData;
        }
        else
        {
          Debug.Log ("Save file is not found in " + path);
          return null;
        }
    }

    public static void DeletePlayerData ()
    {
      string path = Application.persistentDataPath + "/WipeoutClone/PlayerData.save";

      File.Delete(path);
    }

    public static void SaveGData (int saveData)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/WipeoutClone/GData.save";
      FileStream stream = new FileStream(path, FileMode.Create);

      formatter.Serialize(stream, saveData);
      stream.Close();
    }

    public static int LoadGData ()
    {
        string path = Application.persistentDataPath + "/WipeoutClone/GData.save";
        if(File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter();
          FileStream stream = new FileStream(path, FileMode.Open);

          int saveData = (int)formatter.Deserialize(stream);
          stream.Close();

          return saveData;
        }
        else
        {
          Debug.Log ("Save file is not found in " + path);
          return 0;
        }
    }

    public static void DeleteGData ()
    {
      string path = Application.persistentDataPath + "/WipeoutClone/GData.save";

      File.Delete(path);
    }

    public static void SaveSelectedTrackData (Track saveData)
    {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/WipeoutClone/SelectedTrackData.save";
      FileStream stream = new FileStream(path, FileMode.Create);

      formatter.Serialize(stream, saveData);
      stream.Close();
    }

    public static Track LoadSelectedTrackData ()
    {
        string path = Application.persistentDataPath + "/WipeoutClone/SelectedTrackData.save";
        if(File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter();
          FileStream stream = new FileStream(path, FileMode.Open);

          Track saveData = (Track)formatter.Deserialize(stream);
          stream.Close();

          return saveData;
        }
        else
        {
          Debug.Log ("Save file is not found in " + path);
          return null;
        }
    }

    public static void DeleteSelectedTrackData ()
    {
      string path = Application.persistentDataPath + "/WipeoutClone/SelectedTrackData.save";

      File.Delete(path);
    }


}
