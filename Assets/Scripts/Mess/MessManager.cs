using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessManager : MonoBehaviour
{
    private GameManager gameManager;
    private FoodGenerator generator;
    private King theKing;
    private bool levelFinished = false;
    void Awake()
    {
        theKing = GameObject.Find("The King").GetComponent<King>();
        var gmo = GameObject.Find("GameManager");
        if (gmo)
        {
            gameManager = gmo.GetComponent<GameManager>();
            Destroy( GameObject.Find("Food Generator") );
            var oldGenerator = GameObject.Find("Food Generator").GetComponent<FoodGenerator>();
            generator = Instantiate( gameManager.levels[gameManager.currentLevel].foodGenerator ).GetComponent<FoodGenerator>();
            generator.transform.position = oldGenerator.transform.position;

            gameManager.failed = false;
        }
        else
        {
            generator = GameObject.Find("Food Generator").GetComponent<FoodGenerator>();
        }

        theKing.GetComponent<Animator>().SetFloat("open mouth speed", generator.conveyorSpeed);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
        var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
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
}
