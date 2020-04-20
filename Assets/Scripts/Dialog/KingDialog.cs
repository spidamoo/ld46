using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KingDialog : MonoBehaviour
{
    public UnityEvent finishEatingPlayerEvent;
    public float talkTimeLeft;

    private DialogManager manager;
    private Animator animator;
    void Awake()
    {
        manager = GameObject.Find("/DialogManager").GetComponent<DialogManager>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (talkTimeLeft > 0.0f)
        {
            talkTimeLeft -= Time.deltaTime;
        }
        animator.SetFloat("talk time left", talkTimeLeft);
    }

    public void FinishEatingPlayer()
    {
        finishEatingPlayerEvent.Invoke();
    }

    public void StartTalking(float time)
    {
        talkTimeLeft = time;
        animator.SetFloat("talk time left", talkTimeLeft);
    }

    public void FinishTalking() {}
}
