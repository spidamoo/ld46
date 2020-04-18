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
    // Start is called before the first frame update
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
        var food = col.GetComponent<Food>();
        hunger += food.nutrition;
        health -= food.poison;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit " + other);
        Destroy(other.gameObject);
    }
}
