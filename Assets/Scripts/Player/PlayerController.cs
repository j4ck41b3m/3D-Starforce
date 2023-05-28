using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    // Movimientos basicos
    public float velocidadMovimiento;
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
    public float velCorrer;
    

    // armas
    public bool conArma;
    public Transform muzzle;
    public GameObject Ball, curva;
    public int side;
    public AudioSource audi;
    public AudioClip pew;
    public GameObject[] reds;

    void Start()
    {
        audi = GetComponent<AudioSource>();
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
        if (transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        reds = GameObject.FindGameObjectsWithTag("Target");
        //Correr
        Correr();



        // leemos cursores
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Golpeo
        if (Input.GetKeyDown(KeyCode.Mouse0) && puedoSaltar && !estoyAtacando && reds.Length > 0)
        {
            
            audi.PlayOneShot(pew);
            side = Random.Range(0, 4);
            print(side);
            Instantiate(curva, transform.position, transform.rotation);
            estoyAtacando = true;

            if (x == 0 && y== 0)
            {
                //anim.SetTrigger("Golpeoo");
                anim.SetTrigger("Golpeo2");
            }
            

            
        }
        else
        {
            estoyAtacando = false;
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
        else if (Input.GetKeyUp(KeyCode.LeftControl))
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
