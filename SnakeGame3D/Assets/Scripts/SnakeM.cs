using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeM : MonoBehaviour
{
    [SerializeField] private float moveSpeed=5f;
    [SerializeField] private float steerSpeed=180f;
    [SerializeField] private int Gap = 40;

    public GameObject TailPrefab;

    List<GameObject> TailParts = new List<GameObject>();
    List<Vector3> PositionHistory = new List<Vector3>();

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);


        PositionHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var tail in TailParts)
        {
            Vector3 point = PositionHistory[Mathf.Clamp(index * Gap, 0, PositionHistory.Count - 1)];

            Vector3 moveDirection =point - tail.transform.position;
            tail.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }


    }

    private void GrowSnake()
    {
        GameObject tail = Instantiate(TailPrefab);
        TailParts.Add(tail);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("food");
            GrowSnake();
            //todo change transform and score
        }if (other.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            //todo Dead Screen
        //    Time.timeScale = 0;
        }
    }

}
