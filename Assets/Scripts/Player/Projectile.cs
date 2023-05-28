using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private QuadraticCurve curve;
    public GameObject curveSystem;
    public float speed;
    private float sampleTime;
    public bool done;
    
    // Start is called before the first frame update
    void Awake()
    {
        done = false;
        sampleTime = 0f;
        curve = curveSystem.GetComponent<QuadraticCurve>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curve == null)
        {
            return;
        }
        else
        {
            sampleTime += Time.deltaTime + (speed / 100);
            transform.position = curve.evaluate(sampleTime);
            transform.forward = curve.evaluate(sampleTime + 0.001f) - transform.position;
            if (sampleTime >= 1f)
            {
                Debug.Log("boom");
                done = true;
                Destroy(gameObject, 0.1f);


            }
        }
       

    }
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LockedOn"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
    }
}
