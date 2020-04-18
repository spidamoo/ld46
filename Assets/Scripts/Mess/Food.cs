using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public const int TRASH_LAYER = 8;
    public float nutrition;
    public float poison;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameObject.layer = TRASH_LAYER;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var point = ray.origin + (ray.direction * 0);

        gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(
            Random.insideUnitCircle.normalized, point, ForceMode2D.Impulse
        );
        // Debug.Log( "World point " + point );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer != TRASH_LAYER)
            return;

        Destroy(gameObject);
    }
}
