using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelRain : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
    public GameObject prefab;
    public int numberOfObjects = 35;
    private float radius;
    private float timer;
    void Start()
    {
        Rain();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer > 1f)
        {
            Rain();

            timer = 0f;

        }
    }

    public void Rain ()
    {
        radius = Random.Range(400, 1000);
        float i = Random.Range(0, numberOfObjects);
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(prefab, pos, rot);
        
    }
}
