using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeMecanic : MonoBehaviour
{
    public static LifeMecanic instLife;
    public Slider vida;
    private float Life=50;
    public float _life
    {
        get
        {
            return Life;
        }
        set
        {
            Life = value;
        }
    }
    private bool Regenerate = false;
    [SerializeField] GameObject death;
    
    public bool _Regenerate {
        get { return Regenerate; }
        set { Regenerate = value; }
    }
    private void Awake()
    {
        if (instLife == null)
        {
            instLife = this;
        }
    }
    void Start()
    {
        death.SetActive(false);
    }

   public 
    void Update()
    {
      
        vida.value = Life;
        if (ButtonManager.instanciaBTNM._CanAnimateTUTORIAL)
        {
            if (Regenerate)
            {
                Life += 1 * Time.deltaTime;
            }
            else
            {
                Life -= 1 * Time.deltaTime;
            }
        }
        if (Life <= 0)
        {
            death.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
