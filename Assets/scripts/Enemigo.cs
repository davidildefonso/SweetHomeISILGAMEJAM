using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public static Enemigo Instancia;
    //variables para patrulla
    public float speed = 5;
    public float leght;
    private float startPosition;
    private float counter;
  
    //variables para Mi intento de seguimiento
    public float visionRadius;
    public float limitX;
    [SerializeField]private float attack; //[es privado pero lo hace publico en el inspector]
    private float stop = 0;
    private Transform myTransform;
    Transform players;
    public Animator animator;
   public bool canAtack=true;
 

    void Awake()
    {if (Instancia == null) Instancia = this;
        myTransform = transform;
    }
    void Start()
    {
        Disappear.instDis.enemigoslist.Add(this);
        startPosition = transform.position.x;
        players = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        print(canAtack);
        //Seguimiento
        Vector3 target = new Vector3(players.position.x, transform.position.y,0);
        float fixedSpeed = attack * Time.deltaTime;
        
        //mi intento de seguimiento
        if (limitX < transform.position.x || limitX> transform.position.x)
        {
           float distance = Vector3.Distance(players.transform.position, transform.position);
            
            //if (distance < visionRadius)target = player.transform.position;     
            //transform.position = Vector2.MoveTowards(transform.position, target, fixedSpeed);
            if (distance < visionRadius&&canAtack)
            {
                Vector3 cosa= transform.position;
                //cosa =  new Vector3(Mathf.Lerp(transform.position.x,player.transform.position.x,attack*Time.deltaTime),transform.position.y,transform.position.z);
                cosa = Vector3.MoveTowards(transform.position,target,fixedSpeed);
                transform.position = cosa;
                animator.SetBool("IsIddle", false);
                animator.SetBool("IsAngry", true);
            }
            else
            {
               //Movimiento de patrullaje--------------------------------------------------------------------------
                counter += Time.deltaTime * speed;
                transform.position = new Vector3(Mathf.PingPong(counter, leght) + startPosition, transform.position.y, transform.position.z);
                animator.SetBool("IsAngry", false);
                animator.SetBool("IsIddle", true);
            }          
            Debug.DrawLine(transform.position, target, Color.green);
        }

        
    }
    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.transform.tag==("Player"))
        {
            Debug.Log("ESTUVE ACA");
            LifeMecanic.instLife._life -= 1*Time.deltaTime;
        }
    }

    
    void OnDrawGizmo()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position,visionRadius);
    }
}
