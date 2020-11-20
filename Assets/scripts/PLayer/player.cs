using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;    
    private BoxCollider2D boxCollider2d;
    [SerializeField]private Animator TUTOP1ANIM;
    Vector3 characterScale;
    float characterScaleX;   
    float lockPos = 0;
   [SerializeField] float valorx;

   public Transform hermano;
    public Transform mama;
    public Transform abuelo;
    public Transform hermana;

    [SerializeField] GameObject fin;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;

        Time.timeScale = 1;

        fin.SetActive(false);
    }


    
    public LayerMask groundLayers;

    bool isGrounded(){
        Vector2 position=transform.position;
        Vector2 direction = Vector2.down;
     
        
        RaycastHit2D hit = Physics2D.Raycast(position,direction,valorx,groundLayers);
        if(hit.collider !=null){
            return true;
        }
        return false;
    }

    
    void Update()
    {
        if (ButtonManager.instanciaBTNM._CanAnimateTUTORIAL)
        {
            TUTOP1ANIM.SetBool("TUTOP1", true);

        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h*speed,rb.velocity.y);
      
        if (Input.GetAxis("Horizontal") < 0) {
           
            sprite.flipX = true;
                anim.SetBool("isIddle", false);
                anim.SetBool("isWalk", true);
                anim.SetBool("isJump", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
                anim.SetBool("isIddle", false);
                anim.SetBool("isWalk", true);
                anim.SetBool("isJump", false);
                sprite.flipX = false;
        }
            if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("isIddle", true);
                anim.SetBool("isWalk", false);
                anim.SetBool("isJump", false);
            }
        transform.localScale = characterScale;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isGrounded())
                {
                    return;
                }
                else
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                    anim.SetBool("isJump", true);
                    anim.SetBool("isWalk", false);
                    anim.SetBool("isWalk", false);
                }


            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*valorx );
    }


    public void OnCollisionEnter2D(Collision2D col)
     {
       //  float step = speed2 * Time.deltaTime;
         if(col.transform.tag == "hermano")
         {
             Debug.Log("rescatado!"); 
             Destroy(col.gameObject);
             Transform  myHermano = Instantiate(hermano, new Vector3( gameObject.transform.position.x-1f, gameObject.transform.position.y+0.5f, 0), Quaternion.identity) as Transform ;
            myHermano.parent=transform;
           
          //  if(col.gameObject.tag=="hermano"){
                
            //}
                          
         }else if(col.transform.tag == "mama"){
             Destroy(col.gameObject);
             Transform  myMama = Instantiate(mama, new Vector3( gameObject.transform.position.x-0.5f, gameObject.transform.position.y+0.5f, 0), Quaternion.identity) as Transform ;
            myMama.parent=transform;
         }
         else if(col.transform.tag == "abuelo"){
             Destroy(col.gameObject);
             Transform  myAbuelo = Instantiate(abuelo, new Vector3( gameObject.transform.position.x-1.5f, gameObject.transform.position.y+0.5f, 0), Quaternion.identity) as Transform ;
            myAbuelo.parent=transform;
         }
         else if(col.transform.tag == "hermana"){
             Destroy(col.gameObject);
             Transform  myHermana = Instantiate(hermana, new Vector3( gameObject.transform.position.x-2f, gameObject.transform.position.y+0.5f, 0), Quaternion.identity) as Transform ;
            myHermana.parent=transform;
         }
   
     }
    public void OnTriggerEnter2D(Collider2D col)
    {
        //Casita
        if (col.gameObject.tag.Equals("Casa"))
        {
            print("Hola");
            fin.SetActive(true);
            Time.timeScale = 0;

        }
    }

}
