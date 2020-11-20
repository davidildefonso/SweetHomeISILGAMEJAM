using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public static Disappear instDis;
    public List<Enemigo> enemigoslist; 
   [SerializeField] private LifeMecanic Bar;
    private SpriteRenderer sprite;
    private bool InHide=false;
    Vector3 PosI;
    int OriginalSort;
    [SerializeField]private Animator Tutoanim;
   [SerializeField] bool canTuto ;
    private void Awake()
    {
        if (instDis == null)
        {
            instDis = this;
        }
        enemigoslist = new List<Enemigo>();
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        OriginalSort = sprite.sortingOrder;
      
    }

    // Update is called once per frame
    void Update()
    {
        print(InHide);
        PosI = transform.position;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hide") && Input.GetKeyDown(KeyCode.W)&&!InHide)
        {
            print("ENTRARRR");
            
        
            transform.position = collision.transform.position;
            sprite.sortingOrder = -10;
            InHide = true;
            Bar._Regenerate = true;
            for (int i = 0; i < enemigoslist.Count; i++)
            {
                enemigoslist[i].canAtack = false;
            }
          
          
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hide") && InHide)
        {
            print("SALIRRR");
            sprite.sortingOrder = OriginalSort;
            transform.position = PosI;
            InHide = false;
            Bar._Regenerate = false;
            for (int i = 0; i < enemigoslist.Count; i++)
            {
                enemigoslist[i].canAtack = true;
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Hide"))
        {
            if (Tutoanim != null && canTuto)
            {
                Tutoanim.SetBool("TUTOP2", true);
                canTuto = false;
            }
        }
    }
}
