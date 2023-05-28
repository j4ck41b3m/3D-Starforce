using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo2 : MonoBehaviour
{
    public int vidas;
    public int danoArma;
    public int danoPuno;
    public Animator animator;
    public bool hit, dead;
    public LayerMask bullet;
    private Renderer render;
    public GameObject dia, body, boom;
    AudioSource audi;
    public AudioClip blip;
    private void Start()
    {
        // animator = GetComponent<Animator>();
        render = body.GetComponent<Renderer>();
        audi = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, 0.5f, bullet))
        {
            if (!hit)
            {
                audi.PlayOneShot(blip);
                Damage();
                hit = true;
            }
        }

        if (vidas <= 0 && dead == false)
        {
            dead = true;
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
            Destroy(dia);

        }
    }
   /* private void OnTriggerEnter(Collider other)
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

            // animator.SetTrigger("MataRonaldo");
            Destroy(gameObject, 0.1f);
        }
    }*/

    void Damage()
    {
        vidas -= danoArma;
        render.material.color = Color.red;
        Invoke("notOver", 0.1f);
    }

    void notOver()
    {
        hit = false;
        render.material.color = Color.white;

    }


}
