using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessManager : MonoBehaviour
{
    private GameManager gameManager;
    private FoodGenerator generator;
    private King theKing;
    void Awake()
    {
        var gmo = GameObject.Find("GameManager");
        if (gmo)
        {
            gameManager = gmo.GetComponent<GameManager>();
            Destroy( GameObject.Find("Food Generator") );
            generator = Instantiate( gameManager.levels[gameManager.currentLevel].foodGenerator ).GetComponent<FoodGenerator>();

            gameManager.failed = false;
        }
        else
        {
            generator = GameObject.Find("Food Generator").GetComponent<FoodGenerator>();
        }

        theKing = GameObject.Find("The King").GetComponent<King>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ( generator.foodLeft <= 0 && !IsThereActiveFood() )
        {
            var curtainAnimator = GameObject.Find("Canvas/Curtain").GetComponent<Animator>();
            curtainAnimator.SetTrigger("fadein");
            if ( curtainAnimator.GetCurrentAnimatorStateInfo(0).IsName("Dark") )
            {
                FinishLevel();
            }
        }
        else
        {
            if (theKing.health <=0 || theKing.hunger <= 0)
            {
                FailLevel();
            }
        }
    }

    void FinishLevel()
    {
        if (gameManager)
        {
            gameManager.currentLevel++;
            SceneManager.LoadScene("DialogScene");
        }
    }

    void FailLevel()
    {
        gameManager.failed = true;
        SceneManager.LoadScene("DialogScene");
    }

    public bool IsThereActiveFood()
    {
        Debug.Log("active food " + GameObject.FindGameObjectsWithTag("Food").Length);
        return GameObject.FindGameObjectsWithTag("Food").Length > 0;
    }
}
