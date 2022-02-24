using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;




    [SerializeField] private GameObject Tail;

    List<GameObject> Tails;
    Vector3 LastPosition = new Vector3();
    GameObject ExtractedTail/* = new GameObject()*/;//Cikarilan kuyruk 

    // Start is called before the first frame update
    void Start()
    {
        Tails = new List<GameObject>();
        for (int i = 0; i <= 5; i++)
        {
            GameObject NewTail = Instantiate(Tail, LastPosition, Quaternion.identity);
            Tails.Add(NewTail);
        }

        InvokeRepeating("Move", 0f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0, 90, 0);
        }
    }

    /*
     transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //forward z ekseinnde ilerletiyor

        float steerDirection = Input.GetAxis("Horizontal");
        //sol iken -1 sað iken +1 oluyor *****
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
        //dönder diyoruz
     */

    private void Move()
    {
        LastPosition = transform.position;
        transform.Translate(0, 0, Speed * Time.deltaTime);

        if (Tails.Count > 0)
        {
            Tails[0].transform.position = LastPosition;//ilk kuyrugun pozisyonu eski pozisyon oluyor 
            ExtractedTail = Tails[0];//ilk kuyruðu çýkarýcagýmýz kuyruða atadýk 
            Tails.RemoveAt(0);//ilk kuyrugu listeden çýkardýk 
            Tails.Add(ExtractedTail);//en sona ekledik
            //
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            GameObject NewTail = Instantiate(Tail, LastPosition, Quaternion.identity);
            Tails.Add(NewTail);
        }
        if (other.CompareTag("Tail"))//duvarý da ekle 
        {
            Debug.Log("Kuyruk yada duvar");
            //Todo: dead screen
        }
    }
}
