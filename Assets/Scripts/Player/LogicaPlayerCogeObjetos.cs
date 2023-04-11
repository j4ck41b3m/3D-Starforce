using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LogicaPlayerCogeObjetos : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "CuboCoger" &&
                        hitInfo.collider.gameObject.GetComponent<LogicaCogerObjetos>()
                        .destruirConCursor)
                        {
                    hitInfo.collider.gameObject.GetComponent<LogicaCogerObjetos>().Efecto();
                    Destroy(hitInfo.collider.gameObject);

                }
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CuboCoger" &&
                other.GetComponent<LogicaCogerObjetos>().destruirAutomatico)
        {

            other.GetComponent<LogicaCogerObjetos>().Efecto();
            Destroy(other.gameObject);

        }
        if (other.tag == "CuboCoger")
        {
            if (Input.GetMouseButton(1) &&
                !other.GetComponent<LogicaCogerObjetos>().destruirAutomatico)
            {

                other.GetComponent<LogicaCogerObjetos>().Efecto();
                Destroy(other.gameObject);
            }

        }
    }
}
