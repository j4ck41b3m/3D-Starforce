using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{


    public BoxCollider[] armasBoxCollider;
    public BoxCollider punoBoxColliders;

    


    public GameObject[] armas;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        DesactivarBoxColliderArmas();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DesactivarArmas();
        }
        
    }

    public void ActivarArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);
        player.conArma = true;
    }

    public void DesactivarArmas()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        player.conArma = false;

    }

   public void DesactivarBoxColliderArmas()
    {
        for (int i = 0; i < armasBoxCollider.Length; i++)
        {
            if (armasBoxCollider[i] != null)
            {
                armasBoxCollider[i].enabled = false;
            }
        }
        punoBoxColliders.enabled = false;
    }


    public void ActivarBoxColliderArmas()
    {
        if (player.conArma)
        {
            for (int i = 0; i < armasBoxCollider.Length; i++)
            {
                if (armasBoxCollider[i] != null)
                {
                    armasBoxCollider[i].enabled = true;
                }
            }
            punoBoxColliders.enabled = false;
        }
        else
        {
            DesactivarBoxColliderArmas();
            punoBoxColliders.enabled = true;
        }
            
    }

}
