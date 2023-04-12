using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // Movimientos basicos
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 100f;
    public float x, y;

    // animacion
    public Animator anim;

    // Salto
    public Rigidbody rb;
    public float fuerzaSato = 8f;
    public bool puedoSaltar;
    //


    // Agachado
    public float velocidaInicial;
    public float velocidadAgachado;
    //

    //Golpeo
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;

    // Correr
    public float velCorrer = 10f;


    // armas
    public bool conArma;

   

    void Start()
    {
        anim = GetComponent<Animator>();

        // Salto
        puedoSaltar = true;
        //

        //Agachado
        velocidaInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        //


    }

    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Correr
        Correr();



        // leemos cursores
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Golpeo
        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
            if (conArma)
            {

                anim.SetTrigger("Golpeo2");
                estoyAtacando = true;
            }
            else
            {

                anim.SetTrigger("Golpeoo");
                estoyAtacando = true;
            }
        }
        //


        // pasamos datos para animacion
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // Salto
        Saltar();
        Agachado();

    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && puedoSaltar && !estoyAtacando)
        {
            velocidadMovimiento = velCorrer;
            if (y > 0)
            {
                anim.SetBool("Correr", true);
            }
            else
            {
                anim.SetBool("Correr", false);
                if (puedoSaltar)
                {
                    velocidadMovimiento = velocidaInicial;
                }
            }
        }
        else
        {
            anim.SetBool("Correr", false);
            velocidadMovimiento = velocidaInicial;

        }

    }

    private void Agachado()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("Agachado",true);
            ///////////////////todo
            velocidadMovimiento = velocidadAgachado;
            ///
        }
        else
        {
            anim.SetBool("Agachado", false);
            ///////////////////todo
            velocidadMovimiento = velocidaInicial;
            ///

        }
    }

    private void Saltar()
    {
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Saltee", true);
                rb.AddForce(new Vector3(0,fuerzaSato,0),ForceMode.Impulse);
            }
            anim.SetBool("TocoSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    private void EstoyCayendo()
    {
        anim.SetBool("TocoSuelo",false);
        anim.SetBool("Saltee", false);
    }

    public void DejoDeGolpear()
    {
        estoyAtacando=false;
    }
    public void AvanzoSolo()
    {
        avanzoSolo=true;
    }
    public void DejoDeAvanzar()
    {
        avanzoSolo= false;
    }

  
}
