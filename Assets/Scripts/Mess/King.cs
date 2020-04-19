using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class King : MonoBehaviour
{
    public float hunger;
    public float maxHunger = 10.0f;
    public float health;
    public float maxHealth = 10.0f;
    public float hungerPerSecond = 0.1f;

    public Image hungerBar;
    public Image healthBar;

    private Animator animator;
    private Collider2D plateCollider;
    private int foodLayerMask;

    void Awake()
    {
        animator = GetComponent<Animator>();
        plateCollider = transform.Find("Plate").GetComponent<Collider2D>();
        foodLayerMask = LayerMask.GetMask("Default");
    }
    void Start()
    {
        health = maxHealth;
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }

        hunger -= hungerPerSecond * Time.deltaTime;

        hungerBar.fillAmount = hunger / maxHunger;
        healthBar.fillAmount = health / maxHealth;

        animator.SetBool( "has food on plate", plateCollider.IsTouchingLayers(foodLayerMask) );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == Food.TRASH_LAYER)
            return;

        Debug.Log("King enter " + col.name);
        var food = col.GetComponent<Food>();
        hunger += food.nutrition;
        health -= food.poison;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == Food.TRASH_LAYER)
            return;

        Debug.Log("King exit " + col.name);
        Destroy(col.gameObject);
    }
}
