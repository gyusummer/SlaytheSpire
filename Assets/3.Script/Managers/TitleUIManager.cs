using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    public GameObject CharSelecWindo;

    public void SelectAndStartGame(string sceneName)
    {
        MySceneManager.Instance.LoadScene(sceneName);
    }
    public void ShowCharSelectionWindow()
    {
        CharSelecWindo.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
