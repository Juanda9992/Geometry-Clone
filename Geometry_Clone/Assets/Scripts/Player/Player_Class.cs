using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //Requiere RigidBody para funcionar
public class Player_Class : MonoBehaviour
{
    [SerializeField] private float jumpForce; //La fuerza de salto
    [SerializeField]private float moveSpeed; //La verlocidad de movimiento
    public Rigidbody2D rb; //El RigidBody del jugador
    Vector2 initialPosition; //La posiicon inicial del jugador
    float yAxis {get {return Mathf.Clamp(rb.gravityScale,-1,1); } } //Es el valor de la gravedad del jugador pero limitada a 1 y -1

    private void Start() 
    {
        initialPosition = transform.position; //Asigna la posicion que tenga el jugador al crearse al cmapo initialPosition
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y); //Mover el jugador hacia la derecha
    }

    void Update()
    {   

        if(Input.GetMouseButtonDown(0)) //Si se oprime el click izquierdo el personaje salta depende de la escala de la gravedad que posea: Si es positiva el jugador salta hyacia arriba, si es negativa el jugador salta hacia abajo; la razon de que sea 1 o -1 es para no afectar la escala del salto independientemente su gravedad
        {
            rb.AddForce(Vector2.up * jumpForce * yAxis, ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.R)) //Si se oprime la tecla R el jugador vuelve a su posicion inicial
        {
            rb.velocity = Vector2.zero;
            transform.position = initialPosition;
        }
    }

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>(); //Al actualizar el componente en el inspector, se asigna automaticamente el RigidBody
    }

}
