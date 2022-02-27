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
            SnakeMScript.Score++;
            SnakeMScript.GrowSnake();
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
            SnakeMScript.Dead();
        }
    }
}
