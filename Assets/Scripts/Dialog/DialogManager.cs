using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public List<DialogPhrase> phrases;
    public int currentPhrase = -1;
    public string nextScene = "MessScene";

    private GameManager gameManager;
    private Text text;
    private AudioSource phraseAudio;

    void Awake()
    {
        text = GameObject.Find("/Canvas/Panel/Text").GetComponent<Text>();
        phraseAudio = GetComponent<AudioSource>();

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
        // NextPhrase();
    }

    void Update()
    {
    }

    public void EatPlayer()
    {
        var panel = GameObject.Find("Canvas/Panel");
        panel.SetActive(false);
        var kingAnimator = GameObject.Find("Canvas/The King").GetComponent<Animator>();
        kingAnimator.SetTrigger("eatplayer");
    }
    public void GoToMess()
    {
        var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
        curtainAnimator.SetTrigger("fadein");
        nextScene = "MessScene";
    }
    public void GoToCredits()
    {
        var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
        curtainAnimator.SetTrigger("fadein");
        nextScene = "CreditsScene";
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
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
            text.text = phrases[currentPhrase].GetText(gameManager && gameManager.englishVersion);
            phraseAudio.clip = phrases[currentPhrase].sound;

            if (phraseAudio.clip)
            {
                phraseAudio.Play();
                GameObject.Find("Canvas/The King").GetComponent<KingDialog>().StartTalking(phraseAudio.clip.length - 1.0f);
            }
            else
            {
                GameObject.Find("Canvas/The King").GetComponent<KingDialog>().StartTalking(3.0f);
            }
        }
    }

    public void FinishDialog()
    {
        if (gameManager)
        {
            if (gameManager.failed)
            {
                EatPlayer();
            }
            else
            {
                if (gameManager.currentLevel >= gameManager.levels.Count)
                {
                    GoToCredits();
                }
                else
                {
                    GoToMess();
                }
            }
        }
        else
        {
            GoToMess();
        }
    }
}
