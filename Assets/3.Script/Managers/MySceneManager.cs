using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MySceneManager : Singleton<MySceneManager>
{
    public Image Transition_img;
    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        Transition_img.gameObject.SetActive(false);
        SceneManager.sceneLoaded += TransitionOut;
    }
    public void LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
    }
    public void TransitionIn(String sceneName)
    {
        Transition_img.transform.position = new Vector2(960,1620);
        Transition_img.transform.DOMoveY(540, 1f)
            .OnStart(() =>
            {
                Transition_img.gameObject.SetActive(true);
            })
            .OnComplete(() =>
            {
                LoadScene(sceneName);
            });
    }
    public void TransitionOut(Scene scene, LoadSceneMode mode)
    {
        Transition_img.transform.position = new Vector2(960,540);
        Transition_img.transform.DOMoveY(1620f, 1f).OnComplete(() =>
        {
            Transition_img.gameObject.SetActive(false);
        });
    }
}