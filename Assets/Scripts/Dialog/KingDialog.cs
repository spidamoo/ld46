using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KingDialog : MonoBehaviour
{
    public UnityEvent finishEatingPlayerEvent;

    private DialogManager manager;
    void Awake()
    {
        manager = GameObject.Find("/DialogManager").GetComponent<DialogManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishEatingPlayer()
    {
        finishEatingPlayerEvent.Invoke();
    }
}
