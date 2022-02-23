using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;

    private void Update()
    {
        transform.position += transform.forward * MoveSpeed*Time.deltaTime;
            //forward z ekseinnde ilerletiyor
    }



}
