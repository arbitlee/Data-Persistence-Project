using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public int bestScore;
    public string bestPlayerName;
    public string curPlayerName;
    public InputField inputName;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if(inputName.text == "")
        {
            Debug.Log("Input your name!!");
            return;
        }
        else
        {
            MenuUIManager.Instance.curPlayerName = inputName.text;
        }

        SceneManager.LoadScene(1);

     }

    public void Quit()
    {
        MenuUIManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void DisplayBestScoreText()
    {
        bestScoreText.text = "Best Score: " + MenuUIManager.Instance.bestPlayerName + ": " + MenuUIManager.Instance.bestScore;
    }
}

