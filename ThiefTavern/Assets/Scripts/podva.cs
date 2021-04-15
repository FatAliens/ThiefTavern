using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podva : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform podval;
    public Transform aa;
         public Transform ruputacia;
         public Transform resursi;
         public Transform qvesty;
    public void OnClick_Podval_On() 
    {
        podval.gameObject.SetActive(true);
        aa.gameObject.SetActive(false);
    }
    public void OnClick_Podval_Off()
    {
        podval.gameObject.SetActive(false);
        aa.gameObject.SetActive(true);
    }
    public void OnClick_Podval_reputachia_on() 
    {
        ruputacia.gameObject.SetActive(true);
        
    }
    public void OnClick_Podval_reputachia_off() 
    {
        ruputacia.gameObject.SetActive(false);
       
    }
    public void OnClick_Podval_resursi_on() 
    {
        resursi.gameObject.SetActive(true);
       
    }
    public void OnClick_Podval_resursi_off()
    {
        resursi.gameObject.SetActive(false);
       
    }
    public void OnClick_Podval_qvesty_on() 
    {
        qvesty.gameObject.SetActive(true);
        
    }
    public void OnClick_Podval_qvesty_off()
    {
        qvesty.gameObject.SetActive(false);
    }


    
}
