using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public float maxDistance = 50.0f;
    public float flashSpeed = 10.0f;
    private Outline outline;
    private Image filler;
    private float flip = 1.0f;
    
    void Awake()
    {
        filler = transform.Find("Hunger Filler").GetComponent<Image>();
        outline = GetComponent<Outline>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (filler.fillAmount < 0.5f)
        {
            outline.effectDistance += Vector2.one * flip * flashSpeed * Time.deltaTime;

            if (flip > 0.0f && outline.effectDistance.x > maxDistance)
                flip = -1.0f;
            else if (flip < 0.0f && outline.effectDistance.x < 0.0f)
                flip = 1.0f;
        }
        else
        {
        }
    }
}
