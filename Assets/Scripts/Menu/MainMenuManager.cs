using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private string nextScene = "DialogScene";
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("/GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        if (gameManager.englishVersion)
        {
            GameObject.Find("/Canvas/Lang Toggles/Toggle En").GetComponent<Toggle>().isOn = true;
        }
        else
        {
            GameObject.Find("/Canvas/Lang Toggles/Toggle Ru").GetComponent<Toggle>().isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GoToScene(string scene)
    {
        var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
        curtainAnimator.SetTrigger("fadein");

        nextScene = scene;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
