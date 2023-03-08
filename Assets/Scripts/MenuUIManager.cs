using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;
    public int bestScore;
    public string curPlayerName;
    public string bestPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class BestPlayerData
    {
        public int bestScore;
        public string bestPlayerName;
    }
    public void SavePlayerData()
    {
        BestPlayerData data = new BestPlayerData();
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayerData data = JsonUtility.FromJson<BestPlayerData>(json);

            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}
