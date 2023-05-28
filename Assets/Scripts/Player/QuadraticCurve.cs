using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform[] Control;
    public GameObject[] reds;
    public PlayerController play;
    public GameObject bola,Ball;
    int lado;
    bool ded;

    private void Awake()
    {
        reds = GameObject.FindGameObjectsWithTag("Target");
        if (reds.Length != 0)
        {
            B.position = reds[Random.Range(0, reds.Length)].transform.position;

        }
        else
        {
            Destroy(gameObject);
        }
        bola.GetComponent<Projectile>().curveSystem = gameObject;

        play = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        A = GameObject.Find("Muzzle").transform;
        lado = play.side;
         bola = Instantiate(Ball, A.transform.position, A.transform.rotation);
    }
    public Vector3 evaluate(float t)
    {

        Vector3 AC = Vector3.Lerp(A.position, Control[lado].position, t);
        Vector3 CB = Vector3.Lerp(Control[lado].position, B.position, t);
        return Vector3.Lerp(AC, CB, t);
    }

    private void OnDrawGizmos()
    {
        if (A == null || B == null || Control == null)
        {
            return;

        }
        for (int i = 0; i < 10; i++)
        {
            Gizmos.DrawWireSphere(evaluate(i / 20), 0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {

        ded = bola.GetComponent<Projectile>().done;
        if (ded == true)
        {
            Destroy(gameObject);
        }

    }
}
