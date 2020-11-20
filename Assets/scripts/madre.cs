using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class madre : MonoBehaviour
{
    private float speed = 50.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        
    }

    public void OnCollisionEnter2D(Collision2D col)
     {
         float step = -speed * Time.deltaTime;
         if(col.transform.tag == "Player")
         {
             Debug.Log("rescatado!"); 
             transform.parent = col.transform;
             transform.position = Vector2.MoveTowards(transform.position, target, step);
         }
     }
}
