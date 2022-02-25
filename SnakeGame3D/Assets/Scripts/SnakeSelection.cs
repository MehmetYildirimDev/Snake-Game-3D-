using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSelection : MonoBehaviour
{
    List<GameObject> SnakeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
      //      SnakeList.Add(gameObject.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
