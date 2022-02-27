using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public SnakeMove SnakeMScript;

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Food"))
        {
            //Todo : colllider carpýsýypr yýlan direk oluyor
            SnakeMScript.Score++;
           SnakeMScript.GrowSnake();
            Debug.Log("player");
            SnakeMScript.ChangePosition();
        }

        if (other.CompareTag("Poison"))
        {
            SnakeMScript.PoisonF();
            SnakeMScript.ChangePosition();
        }

        if (other.CompareTag("Velocity"))
        {
            SnakeMScript.VelocityF();
            SnakeMScript.ChangePosition();
        }

        if (other.CompareTag("Wall") || other.CompareTag("Tail"))
        {
            Debug.Log("Food icinde");
            SnakeMScript.Dead();
        }
    }
}
