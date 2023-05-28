using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public Transform[] Targeto;
    public GameObject[] reds;
    public AudioClip found;
    public AudioSource audi;
    public GameObject Diana;
    public int enemies;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemigo"))
        {
           GameObject red = Instantiate(Diana, other.transform.position, other.transform.rotation);
            GameObject enemy = other.gameObject;
            enemy.GetComponent<LogicaEnemigo2>().dia = red;
            other.tag = "LockedOn";
            audi.PlayOneShot(found);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("LockedOn"))
        {
            other.tag = "Enemigo";
            Destroy(other.GetComponent<LogicaEnemigo2>().dia);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemies++;
        }
    }
}
