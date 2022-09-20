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
    public InputField inputField;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        PlayerDataManager.Instance.LoadScore();
        inputField.text = PlayerDataManager.Instance.playerName;
        scoreText.text = $"Best Score: {PlayerDataManager.Instance.playerName} {PlayerDataManager.Instance.bestScore}";

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void StartGame()
    {
        PlayerDataManager.Instance.currentPlayerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                    Application.Quit(); // original code to quit Unity player
        #endif
    }
}
