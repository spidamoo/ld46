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
    private Text commentText;
    private GameManager gameManager;

    void Awake()
    {
        animator = GetComponent<Animator>();
        plateCollider = transform.Find("Plate").GetComponent<Collider2D>();
        commentText = GameObject.Find("/Canvas/King Comment").GetComponent<Text>();
        foodLayerMask = LayerMask.GetMask("Default");

        var gmo = GameObject.Find("GameManager");
        if (gmo)
        {
            gameManager = gmo.GetComponent<GameManager>();
        }
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

    public void EatFood(Food food)
    {
        hunger += food.nutrition;
        health -= food.poison;

        Debug.Log(string.Format("The King eats {0}, n: {1} p: {2}", food.name, food.nutrition, food.poison));
        if (food.poison > 0.0f || food.nutrition < 0.0f)
        {
            animator.SetTrigger("poisoned");
        }

        var comment = food.GetPhrase();
        if (comment != null)
        {
            if (comment.sound)
            {
                GetComponent<AudioSource>().clip = comment.sound;
                GetComponent<AudioSource>().Play();
            }
            commentText.text = comment.GetText(gameManager && gameManager.englishVersion);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == Food.TRASH_LAYER)
            return;

        var food = col.GetComponent<Food>();
        if (food)
        {
            EatFood(food);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == Food.TRASH_LAYER)
            return;

        Debug.Log("King exit " + col.name);
        Destroy(col.gameObject);
    }
}
