using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gone : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip explo;
    // Start is called before the first frame update
    void Awake()
    {
        audi = GetComponent<AudioSource>();
        audi.PlayOneShot(explo);
        Destroy(gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
