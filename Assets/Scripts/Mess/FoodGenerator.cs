using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public List<GameObject> foodOptions;
    public AnimationCurve delayUntilNext;
    public int foodLeft = 20;
    public float conveyorSpeed = 1.0f;

    private float nextIn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextIn < 0.0f)
        {
            if (foodLeft > 0)
            {
                foodLeft--;
                SpawnFood();
                nextIn = delayUntilNext.Evaluate(Random.value);
            }
        }
        else
        {
            nextIn -= Time.deltaTime;
        }
    }

    void SpawnFood()
    {
        var prefab = foodOptions[Random.Range(0, foodOptions.Count)];
        var newObj = Instantiate(prefab);
        newObj.transform.position = transform.position;
    }
}
