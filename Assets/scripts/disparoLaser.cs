using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoLaser : MonoBehaviour
{
    public GameObject laser;
    bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(canShoot==true)
        {

            Instantiate(laser,
                new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0),
                new Quaternion(0,0,0,0));
                canShoot=false;
                StartCoroutine(Reload());
            
        }
        
        
        
        
        
    }

    
    IEnumerator Reload(){   
           
        yield return new WaitForSeconds(3);
        canShoot=true;
    }
}
