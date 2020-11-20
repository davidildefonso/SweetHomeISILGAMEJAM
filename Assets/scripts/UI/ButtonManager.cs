using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]private GameObject canvas;
   
    public static ButtonManager instanciaBTNM;
    private bool CanAnimateTUTORIAL=false;
    public bool _CanAnimateTUTORIAL
    {
        get { return CanAnimateTUTORIAL; }

    }
    public void Start()
    {
        if (instanciaBTNM == null)
        {
            instanciaBTNM = this;
        }
    }
 
    public void CONTINUAR()
    {
        canvas.SetActive(false);
        CanAnimateTUTORIAL = true;
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("NIVEL1");
    }

}
