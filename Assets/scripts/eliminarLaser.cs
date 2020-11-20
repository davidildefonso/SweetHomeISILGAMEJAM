using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminarLaser : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag =="Bullet")
        {
            //Debug.Log("Target was hit!");          
                      
            Destroy(col.gameObject);
        }

       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
