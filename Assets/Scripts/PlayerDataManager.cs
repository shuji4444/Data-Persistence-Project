using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance;
    public string playerName;
    public string currentPlayerName;
    public int bestScore = 0;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveScore(int score)
    {
        SaveData data = new SaveData();
        if (score> bestScore)
        {
            data.bestScore = score;
            data.playerName = currentPlayerName;
            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            playerName = data.playerName;
        }
    }


}


