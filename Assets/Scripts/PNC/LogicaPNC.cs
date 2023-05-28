using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicaPNC : MonoBehaviour
{
    public GameObject simboloMision;
    public PlayerController playerController;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panelNext;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision, completed;
    //public GameObject[] objetivos;
    public int numeroObjetivos;
    public GameObject botonDeMision;
    public GameObject[] enemies;
    public Transform tp;




    // Start is called before the first frame update
    void Start()
    {

        //numeroObjetivos = objetivos.Length;
        playerController = GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerController>();
        simboloMision.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("ToKill");
        numeroObjetivos = enemies.Length;
        textoMision.text = "Número de virus restantes: " + numeroObjetivos;
        if (numeroObjetivos <=0 && !completed)
        {
            panelNext.SetActive(true);
            playerController.transform.position = tp.position;
            completed = true;

        }

        if (Input.GetKeyDown(KeyCode.X) && !aceptarMision 
            && playerController.puedoSaltar && jugadorCerca)
        {
            Vector3 posicionPlayer = new Vector3(transform.position.x,
                playerController.gameObject.transform.position.y,
                transform.position.z);
            playerController.gameObject.transform.LookAt(posicionPlayer);
            playerController.anim.SetFloat("VelX", 0);
            playerController.anim.SetFloat("VelY", 0);
            playerController.enabled = false;
            panel2.SetActive(false);
            panel3.SetActive(true);
        }

       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (!aceptarMision)
            {
                panel2.SetActive(true);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && aceptarMision)
        {
            jugadorCerca=false;
            panel2.SetActive(false);
            panel1.SetActive(true);
        }
        else
        {
            panel2.SetActive(false);
            panel3.SetActive(false);
        }
    }

    public void No()
    {
        playerController.enabled = true;
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    public void Si()
    {
        playerController.enabled=true;
        aceptarMision = true;
        /*for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }*/
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    public void BotonOK(int level)
    {
        SceneManager.LoadScene(level);
    }


}
