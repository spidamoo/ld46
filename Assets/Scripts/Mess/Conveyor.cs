using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var generator = GameObject.FindObjectOfType<FoodGenerator>();
        Debug.Log("conveyor speed " + generator.conveyorSpeed);
        GetComponent<SurfaceEffector2D>().speed = generator.conveyorSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
