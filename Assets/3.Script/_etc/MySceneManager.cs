using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance = null;

    public CanvasGroup Fade_img;
    float fadeDuration = 10f;
    bool isFading = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }
    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName);
        //FadeIn();
        SceneManager.LoadScene(sceneName);
        //FadeOut();
    }
    void FadeIn()
    {
        isFading = true;
        Fade_img.alpha = 0;


    }
    void FadeOut()
    {
        isFading = true;

        // TODO: 페이드 인 아웃 구현

        isFading = false;
    }
}