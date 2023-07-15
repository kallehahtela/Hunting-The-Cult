using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button LoadGameBTN;



    private void Start()
    {
        LoadGameBTN.onClick.AddListener(() =>
        {
            SaveManager.Instance.StartLoadedGame(1);
        });
    }

   public void NewGame()
    {
        SceneManager.LoadScene("StartingAnim");

        //SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
