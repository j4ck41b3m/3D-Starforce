using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDePies : MonoBehaviour
{

    public PlayerController playerController;

    


    private void OnTriggerStay(Collider other)
    {
        
        // Debug.Log("stay");
         playerController.puedoSaltar = true;
         
    }
    private void OnTriggerExit(Collider other)
    {
      //  Debug.Log("exit");
        playerController.puedoSaltar=false;
    }
}
