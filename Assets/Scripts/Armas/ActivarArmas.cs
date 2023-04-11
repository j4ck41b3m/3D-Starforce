using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmas : MonoBehaviour
{
    public CogerArmas cogerArmas;
    public int numeroArma;


    // Start is called before the first frame update
    void Start()
    {
        cogerArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<CogerArmas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cogerArmas.ActivarArma(numeroArma);
            Destroy(gameObject);
        }
    }

}
