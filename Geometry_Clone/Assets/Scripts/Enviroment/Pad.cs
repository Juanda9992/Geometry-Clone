using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))] //Requiere el componente SpriteRenderer
public class Pad:MonoBehaviour
{
    public enum typeOfPad {yellow,pink,red,blue} //Todos los tipos de pad posibles
    [SerializeField] private typeOfPad padType; //Permite seleccionar el tipo de pad en el inspector
    [SerializeField] float jumpForce; //La fuerza con la que el pad lanza al jugador
    [HideInInspector] public SpriteRenderer sprite; //El spriteRenderer del jugador

    private void Start() 
    {
        UpdateStats(); //Al iniciar el juego se actualizan los valores segun el tipo de pad
    }
    public virtual void Launch(Rigidbody2D rigidbody) //Lanza el rigidbody seleccionado hacia arriba con la fuerza que tenga
    {
        if(jumpForce != float.NaN) //Si la fuerza de salto es un numero
        {
            rigidbody.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Al colisionar con el jugador se activa la funcion de lanzar al jugador
    {
        Launch(other.attachedRigidbody);
    }
    private void Reset()
    {
        sprite = GetComponent<SpriteRenderer>(); //Al actualizar el inspector se obtiene el spriteRenderer
    }

    private void OnDrawGizmos() //Al seleccionar el objeto en el inspector se actualizan los valores 
    {
        UpdateStats();
    }

    private void UpdateStats() //Depende el tipo de pad se actualiza el color (si el pad es rojo,obtiene el color rojo), y la fuerza de lanzamiento
    {
        switch(padType) 
        {
            case typeOfPad.yellow:
                jumpForce = 18.5f;
                sprite.color = Color.yellow;
                break;
            case typeOfPad.blue:
                sprite.color = Color.blue;
                jumpForce = float.NaN;
                break;
            case typeOfPad.red:
                jumpForce = 24;
                sprite.color = Color.red;
                break;
            case typeOfPad.pink:
                jumpForce = 13;
                sprite.color = Color.magenta;
                break;
        }   
    }
}

