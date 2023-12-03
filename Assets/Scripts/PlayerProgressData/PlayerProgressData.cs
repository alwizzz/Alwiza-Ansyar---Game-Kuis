using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PlayerProgressData",
    menuName = "QuizGame/PlayerProgressData"
)]
public class PlayerProgressData : ScriptableObject
{
    [System.Serializable]
    public struct ProgressData
    {
        public int coins;
        public Dictionary<string, int> levelProgresses;
    }

    public ProgressData data = new ProgressData();
    [SerializeField] private string fileName;
    readonly private string DIR = Application.dataPath + "/Temporary/";
    private string path;

    public void Setup()
    {
        path = DIR + fileName;
        if (!Directory.Exists(DIR))
        {
            Directory.CreateDirectory(DIR);
            Debug.Log($"Directory created : {DIR}");
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log($"File created : {path}");
        }
    }

    public void Save()
    {
        // dummy data
        if(data.levelProgresses == null)
        {
            data.levelProgresses = new();
        }

        FileStream fileStream = File.Open(path, FileMode.Open);
        fileStream.Flush();

        //// ==> By BinaryFormatter
        //BinaryFormatter formatter = new BinaryFormatter();
        //data.coins = 200;
        //data.levelProgresses.Add("LevelPackA", 3);
        //data.levelProgresses.Add("LevelPackB", 5);

        //formatter.Serialize(fileStream, data);

        // ==> By BinaryWriter
        TryBinaryWriter(fileStream);

        fileStream.Dispose();
        Debug.Log($"File saved at : {path}");
    }

    public bool Load()
    {
        bool isSuccess;
        FileStream fileStream = File.Open(path, FileMode.Open);

        //// ==> By BinaryFormatter
        //try
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();

        //    data = (ProgressData)formatter.Deserialize(fileStream);


        //    Debug.Log("File loaded successfully");
        //    isSuccess = true;
        //}
        //catch (System.Exception e)
        //{
        //    Debug.Log(e.Message);
        //    isSuccess = false;
        //}

        // ==> By BinaryReader
        isSuccess = TryBinaryReader(fileStream);
        Debug.Log("file loadeded " + (isSuccess ? "successfully" : "in failure"));

        fileStream.Dispose();
        return isSuccess;
    }

    private void TryBinaryWriter(FileStream fileStream)
    {
        BinaryWriter writer = new BinaryWriter(fileStream);

        writer.Write(data.coins);
        foreach(KeyValuePair<string, int> kvp in data.levelProgresses)
        {
            writer.Write(kvp.Key);
            writer.Write(kvp.Value);
        }

        writer.Dispose();
    }

    private bool TryBinaryReader(FileStream fileStream)
    {
        BinaryReader reader = new BinaryReader(fileStream);

        //if (fileStream.Length == 0) { Debug.Log("fail1"); return false; }
        //if(reader.PeekChar() == -1) { return false; }
        data.coins = reader.ReadInt32();

        //if (reader.PeekChar() == -1) { Debug.Log("fail2"); return false; }
        while (reader.PeekChar() != -1)
        {
            string key = reader.ReadString();

            //if (reader.PeekChar() == -1) { Debug.Log("fail3"); return false; }
            int value = reader.ReadInt32();

            data.levelProgresses.Add(key, value);
        }

        ////if (fileStream.Length == 0) { Debug.Log("fail1"); return false; }
        //if(reader.PeekChar() == -1) { reader.Dispose(); return false; }
        //data.coins = reader.ReadInt32();

        ////if (reader.PeekChar() == -1) { Debug.Log("fail2"); return false; }
        //while (reader.PeekChar() != -1)
        //{
        //    string key = reader.ReadString();

        //    //if (reader.PeekChar() == -1) { Debug.Log("fail3"); return false; }
        //    int value = reader.ReadInt32();

        //    data.levelProgresses.Add(key, value);
        //}

        //char[] charBuffer = new char[10];
        //int bytesRead = reader.Read(charBuffer, 0, 1);

        //if(bytesRead <= 0)
        //{
        //    Debug.Log("fail");
        //    return false;
        //}

        //data.coins = reader.ReadInt32();


        //if (data.levelProgresses == null)
        //{
        //    data.levelProgresses = new();
        //}


        //string key; int value;
        //key = reader.ReadString();
        //value = reader.ReadInt32();
        //data.levelProgresses.Add(key, value);

        //key = reader.ReadString();
        //value = reader.ReadInt32();
        //data.levelProgresses.Add(key, value);

        reader.Dispose();
        return true;
    }
}
