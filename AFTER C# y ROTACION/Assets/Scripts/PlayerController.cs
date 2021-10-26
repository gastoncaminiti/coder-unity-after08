using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //VARIABLES PRIVADAS CON EDICION DESDE EL EDITOR DE UNITY
    [SerializeField] private float speedPlayer = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    //VARIABLES PRIVADAS SIN EDICION DESDE EL EDITOR DE UNITY
    private float mouseAxisX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LLAMADA AL METODO PARA MOVER EL JUGADOR EN CADA FRAME;
        RotatePlayer2();
        MovePlayer();
    }

    //METODO PARA MOVER EL PLAYER EN FUNCION DE LOS AXIS HORIZONTAL Y VERTICAL
    private void MovePlayer()
    {
        //float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Translate(speedPlayer * new Vector3(0, 0, vAxis) * Time.deltaTime);
    }
    //METODO PARA ROTAR EL PLAYER EN FUNCION DE AXIS MOUSE X
    private void RotatePlayer()
    {
        mouseAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, mouseAxisX, 0);
        transform.rotation = newRotation;
    }

    //METODO PARA ROTAR EL PLAYER EN FUNCION DE AXIS VERTICAL
    private void RotatePlayer2()
    {
        float hAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hAxis * rotationSpeed * Time.deltaTime);
    }
}
