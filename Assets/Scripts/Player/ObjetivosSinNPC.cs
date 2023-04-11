using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjetivosSinNPC : MonoBehaviour
{

    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos=GameObject.FindGameObjectsWithTag("Objetivo").Length;
        textoMision.text="Cubos restantes " + numDeObjetivos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Objetivo")
        {
            Debug.Log("a");
            Destroy(other.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Cubos restantes " + numDeObjetivos;
            if (numDeObjetivos <=0)
            {
                textoMision.text = "Completado Objetivo";
                botonMision.SetActive(true);
            }

        }
    }

}
