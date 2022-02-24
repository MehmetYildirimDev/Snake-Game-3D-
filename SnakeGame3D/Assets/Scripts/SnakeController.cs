using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float steerSpeed = 180f;
    [SerializeField] private float bodySpeed = 5f;
    [SerializeField] private int Gap = 15; //gap = bosluk demek yani iki kuyruk arasý boþluk

    [SerializeField] private GameObject BodyPrefab;

    private Transform position;

    private List<GameObject> BodyParts = new List<GameObject>();//kuyruk parcalarini içine atýyoruz
    private List<Vector3> PositionHistory = new List<Vector3>();//kuyruk takibi için öndekilerin v3 alicaz

    private void Start()
    {
        position = this.gameObject.transform;
       // GrowSnake();
    }

    private void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //forward z ekseinnde ilerletiyor

        float steerDirection = Input.GetAxis("Horizontal");
        //sol iken -1 sað iken +1 oluyor *****
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);
        //dönder diyoruz

        PositionHistory.Insert(0, this.transform.position);
        //0. indexe snakei atiyoruz ama bunu her update yapyoruz
        //bu listede sürekli yýlanýn basýný 0. konuma atýyor eðer normal bir þekilde eklese inanýlmaz fazla olurdu yani her update ayný yere ekliyor

        int index = 1;

        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * Gap, PositionHistory.Count - 1)];//bu kýsmý tam anlamadým ama içerdeki uzun yazý tamamen index 
            //Vector3 point = PositionHistory[index*Gap];
            //Farklý durma sebebi sanýrým burasý uzaklýk ile alakalý o yüzden farklý duruyor
            //index * gap => mesala 2.body uzaklýgý 20 oluyor ik noktayla farký 
            Vector3 MoveDirection = point - body.transform.position;
            body.transform.position += MoveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab,position.transform);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Debug.Log("foodTrigger");
            GrowSnake();
        }
    }

}
