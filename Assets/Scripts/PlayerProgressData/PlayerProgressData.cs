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


    public void Save()
    {
        path = DIR + fileName;

        if (!Directory.Exists(DIR))
        {
            Directory.CreateDirectory(DIR);
            Debug.Log($"Directory created : {DIR}");
        }

        if(!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log($"File created : {path}");
        }

        // dummy data
        data.coins = 200;
        if(data.levelProgresses == null)
        {
            data.levelProgresses = new();
        }
        data.levelProgresses.Add("LevelPackA", 3);
        data.levelProgresses.Add("LevelPackB", 5);

        //string content = "";
        //content += data.coins.ToString() + "\n";
        //foreach(KeyValuePair<string, int> kvp in data.levelProgresses)
        //{
        //    content += kvp.Key + "-" + kvp.Value.ToString() + ";";
        //}

        //File.WriteAllText(path, content);


        FileStream fileStream = File.Open(path, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();

        fileStream.Flush();
        formatter.Serialize(fileStream, data);

        Debug.Log($"File saved at : {path}");
    }

    public void Load()
    {

    }
}
