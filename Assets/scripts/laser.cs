using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private float laserYValue;
    public float laserSpeed;

    // Start is called before the first frame update
    void Start()
    {
        laserYValue = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       laserYValue -= laserSpeed;
       gameObject.transform.position = new Vector2(gameObject.transform.position.x,laserYValue); 
    }
}
