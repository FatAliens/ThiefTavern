using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class podval_controler : MonoBehaviour
{
    // Start is called before the first frame update
    
         public Transform ruputacia;
         public Transform resursi;
         
    
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
   


    
}
