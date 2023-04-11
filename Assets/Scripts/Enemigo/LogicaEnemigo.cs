using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo : MonoBehaviour
{
    public int vidas;
    public int danoArma;
    public int danoPuno;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ArmaImpacto")
        {
            if (animator != null)
            {
                animator.Play("AnimacionEnemigo");
            }
            vidas-=danoArma;
        }

        if (other.gameObject.tag == "PunoImpacto")
        {
            if (animator != null)
            {
                animator.Play("AnimacionEnemigo");
            }
            vidas -= danoPuno;
        }
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }
}
