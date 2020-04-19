using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Curtain : MonoBehaviour
{
    public UnityEvent finishFadeinEvent;
    public UnityEvent finishFadeoutEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
