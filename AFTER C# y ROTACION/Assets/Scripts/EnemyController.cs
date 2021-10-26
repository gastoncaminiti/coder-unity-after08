using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //ENUMERACION PARA DEFINIR TIPO DE MOVIMIENTO
    enum TypesMovements { Linear , Around , Follow  };
    //VARIABLES PRIVADAS CON EDICION DESDE EL EDITOR DE UNITY
    [SerializeField] private TypesMovements typeMovement;
    [SerializeField] private float speedEnemy = 5.0f;
    [SerializeField] private GameObject aroundObject; //PIVOT
    //VARIABLES PRIVADAS SIN EDICION DESDE EL EDITOR DE UNITY
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //MoveEnemy(Vector3.forward);
        //LookAtLerp(player);
        //MoveTowards();
        //LookAtLerp(aroundObject);
        // MoveAround(aroundObject);
        switch (typeMovement)
        {
            case TypesMovements.Linear:
                MoveEnemy(Vector3.forward);
                break;
            case TypesMovements.Around:
                MoveAround(aroundObject);
                break;
            case TypesMovements.Follow:
                LookAtLerp(player);
                MoveTowards();
                break;
        }


    }
    //METODO PARA MOVER EL ENEMIGO EN UNA LINEA
    private void MoveEnemy(Vector3 direction)
    {
        transform.Translate(speedEnemy * Time.deltaTime * direction);
    }
    //METODO PARA SEGUIR AL JUGADOR
    private void MoveTowards()
    {

        //Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 direction = (player.transform.position - transform.position);
        //Debug.Log(direction.magnitude);
        if(direction.magnitude > 10)
        {
            transform.position += speedEnemy * direction.normalized * Time.deltaTime;
        }
        
    }
    //METODO PARA MIRAR OBJETO
    private void LookAt(GameObject lookObject)
    {
        Quaternion newRotation = Quaternion.LookRotation(lookObject.transform.position - transform.position);
        transform.rotation = newRotation;
    }

    //METODO PARA MIRAR OBJETO CON LERP
    private void LookAtLerp(GameObject lookObject)
    {
        Quaternion newRotation = Quaternion.LookRotation(lookObject.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1f * Time.deltaTime);
    }

    //METODO MOVE AROUND
    private void MoveAround(GameObject AroundObject)
    {
        transform.RotateAround(AroundObject.transform.position, Vector3.up, speedEnemy * Time.deltaTime);
    }
}
