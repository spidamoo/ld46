using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Curtain : MonoBehaviour
{
    public UnityEvent finishFadeinEvent;
    public UnityEvent finishFadeoutEvent;

    private GameManager gameManager;
    private King theKing;
    private Animator animator;
    void Awake()
    {
        var kingObj = GameObject.Find("The King");
        if (kingObj)
        {
            theKing = kingObj.GetComponent<King>();
        }

        var gmObj = GameObject.Find("GameManager");
        if (gmObj)
        {
            gameManager = gmObj.GetComponent<GameManager>();
        }

        animator = GetComponent<Animator>();
    }
    void Start()
    {
        if (gameManager && gameManager.failed)
        {
            animator.SetBool("stress", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (theKing)
        {
            if (theKing.hunger < theKing.maxHunger * 0.5f)
            {
                animator.SetBool("stress", true);
            }
            else
            {
                animator.SetBool("stress", false);
            }
        }
    }

    public void FinishFadein()
    {
        finishFadeinEvent.Invoke();
    }
    public void FinishFadeout()
    {
        finishFadeoutEvent.Invoke();
    }
}
