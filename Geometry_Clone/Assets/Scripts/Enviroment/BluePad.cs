using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePad : Pad //Deriva de la clase padre Pad
{
    bool isPortal;
    public override void Launch(Rigidbody2D rigidbody)  //Sobreescribe el metodo de lanzar al jugador para invertir la gravedad
    {
        rigidbody.gravityScale = -rigidbody.gravityScale; //Si la gravedad es 5, esta pasa a ser -5
    }

}
