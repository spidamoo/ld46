using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public List<string> phrases;
    public int currentPhrase = 0;

    private GameManager gameManager;
    private Text text;

    void Awake()
    {
        text = GameObject.Find("/Canvas/Panel/Text").GetComponent<Text>();

        var gmo = GameObject.Find("GameManager");
        if (gmo)
        {
            gameManager = gmo.GetComponent<GameManager>();
            if (gameManager.failed)
            {
                phrases = gameManager.failWords;
            }
            else
            {
                if (gameManager.currentLevel >= gameManager.levels.Count)
                {
                    phrases = gameManager.lastWords;
                }
                else
                {
                    phrases = gameManager.levels[gameManager.currentLevel].introPhrases;
                }
            }
        }
    }
    void Start()
    {
        text.text = phrases[currentPhrase];
    }

    void Update()
    {
    }

    public void NextPhrase()
    {
        currentPhrase++;
        if (currentPhrase >= phrases.Count)
        {
            FinishDialog();
        }
        else
        {
            text.text = phrases[currentPhrase];
        }
    }

    public void FinishDialog()
    {
        if (gameManager)
        {
            if (gameManager.failed)
            {
                SceneManager.LoadScene("MessScene");
            }
            else
            {
                if (gameManager.currentLevel >= gameManager.levels.Count)
                {
                    SceneManager.LoadScene("CreditsScene");
                }
                else
                {
                    SceneManager.LoadScene("MessScene");
                }
            }
        }
        else
        {
            SceneManager.LoadScene("MessScene");
        }
    }
}
