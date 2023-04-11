using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjetivos : MonoBehaviour
{
    public LogicaPNC logicaNPC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            logicaNPC.numeroObjetivos--;
            logicaNPC.textoMision.text = "Cubos restantes " + logicaNPC.numeroObjetivos;
            transform.parent.gameObject.SetActive(false);
        }
        if (logicaNPC.numeroObjetivos <= 0)
        {
            logicaNPC.textoMision.text = "Objetivo cumplido";
            logicaNPC.botonDeMision.SetActive(true);
        }
    }

}
