using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public const int TRASH_LAYER = 8;
    public float nutrition;
    public float poison;
    public List<DialogPhrase> phrases;
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

        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // var point = ray.origin + (ray.direction * 0);

        float sideForce = Random.Range(-5.0f, 2.0f);
        float upForce = Random.Range(3.5f, 7.0f);
        float rotation = Random.Range(0.2f, 0.4f);
        gameObject.GetComponent<Rigidbody2D>().AddForce(
            Vector2.right * sideForce + Vector2.up * upForce, ForceMode2D.Impulse
        );
        gameObject.GetComponent<Rigidbody2D>().AddTorque(rotation, ForceMode2D.Impulse);

        // Debug.Log( "World point " + point );
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer != TRASH_LAYER)
            return;

        Destroy(gameObject);
    }

    public DialogPhrase GetPhrase()
    {
        if (phrases.Count == 0)
            return null;

        return phrases[Random.Range(0, phrases.Count)];
    }
}
