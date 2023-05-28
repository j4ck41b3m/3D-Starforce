using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class LogicaCogerObjetos : MonoBehaviour
{
    public bool destruirConCursor;
    public bool destruirAutomatico;
    public PlayerController playerController;

    public int tipo;

    // 1 crece
    // 2 aumenta salto

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerController>(); 
        
    }

    public void Efecto()
    {
        switch (tipo)
        {
            case 1:
                playerController.gameObject.transform.localScale =
                    new Vector3(3, 3, 3);
                break;
            case 2:
                playerController.fuerzaSato *= 2;
                break;
            default:
                Debug.Log("Error, efecto switch");
                break;
        }
    }
}
