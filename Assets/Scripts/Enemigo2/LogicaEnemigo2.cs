using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo2 : MonoBehaviour
{
    public int vidas;
    public int danoArma;
    public int danoPuno;
    public Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArmaImpacto")
        {
            
            vidas -= danoArma;
        }

        if (other.gameObject.tag == "PunoImpacto")
        {
            
            vidas -= danoPuno;
        }
        if (vidas <= 0)
        {

            animator.SetTrigger("MataRonaldo");
        }
    }
}
