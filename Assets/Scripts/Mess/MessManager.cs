using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MessManager : MonoBehaviour
{
    public Texture2D pushCursor;
    public DialogPhrase exitPhrase;

    private GameManager gameManager;
    private FoodGenerator generator;
    private King theKing;
    private bool levelFinished = false;
    private float exitTimer = -1.0f;
    private GameObject exitNotification;
    private AudioSource pushSound;
    void Awake()
    {
        theKing = GameObject.Find("/The King").GetComponent<King>();
        var gmo = GameObject.Find("/GameManager");
        if (gmo)
        {
            gameManager = gmo.GetComponent<GameManager>();
            var oldGenerator = GameObject.Find("/Food Generator").GetComponent<FoodGenerator>();
            Destroy( GameObject.Find("/Food Generator") );
            generator = Instantiate( gameManager.levels[gameManager.currentLevel].foodGenerator ).GetComponent<FoodGenerator>();
            generator.transform.position = oldGenerator.transform.position;

            gameManager.failed = false;
        }
        else
        {
            generator = GameObject.Find("/Food Generator").GetComponent<FoodGenerator>();
        }

        theKing.GetComponent<Animator>().SetFloat("open mouth speed", generator.conveyorSpeed);

        exitNotification = GameObject.Find("/Canvas/Exit Notification");

        pushSound = transform.Find("Push Sound").GetComponent<AudioSource>();
    }
    void Start()
    {
        exitNotification.SetActive(false);
        exitNotification.GetComponent<Text>().text = exitPhrase.GetText(gameManager && gameManager.englishVersion);
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButton(0) )
        {
            Cursor.SetCursor(pushCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        if ( generator.foodLeft <= 0 && !IsThereActiveFood() )
        {
            FinishLevel();
        }
        else
        {
            if (theKing.health <=0 || theKing.hunger <= 0)
            {
                FailLevel();
            }
        }

        if (exitTimer > 0.0f)
        {
            exitTimer -= Time.deltaTime;
            if (exitTimer <= 0.0f)
            {
                exitNotification.SetActive(false);
            }

            if ( Input.GetKeyDown("escape") )
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
        else
        {
            if ( Input.GetKeyDown("escape") )
            {
                exitTimer = 2.0f;
                exitNotification.SetActive(true);
            }
        }
    }

    public void FinishLevel()
    {
        if (levelFinished)
            return;

        levelFinished = true;
        if (gameManager)
        {
            gameManager.currentLevel++;
        }
        GoToDialog();
    }
    public void GoToDialog()
    {
        var curtainAnimator = GameObject.Find("/Canvas/Curtain").GetComponent<Animator>();
        curtainAnimator.SetTrigger("fadein");
    }
    public void LoadDialogScene()
    {
        SceneManager.LoadScene("DialogScene");
    }

    void FailLevel()
    {
        if (gameManager)
        {
            gameManager.failed = true;
        }
        GoToDialog();
    }

    public bool IsThereActiveFood()
    {
        Debug.Log("active food " + GameObject.FindGameObjectsWithTag("Food").Length);
        return GameObject.FindGameObjectsWithTag("Food").Length > 0;
    }

    public void PushFood(Food food)
    {
        pushSound.Play();
    }
}
