using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SnakeMove : MonoBehaviour
{
    [SerializeField] private Transform CameraPosition;
    private Vector3 AreaLimit = new Vector3(-9, 0.25f, 9);//yemler için .25f

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float steerSpeed = 180f;
    [SerializeField] private float Gap = 40;

    public GameObject TailPrefab;
    public GameObject Food;
    public GameObject Poison;
    public GameObject Velocity;

    List<GameObject> TailParts = new List<GameObject>();
    List<Vector3> PositionHistory = new List<Vector3>();

    [SerializeField] private Text ScoreText;
    [SerializeField] private Text GOScoreText;
    [SerializeField] private Text HealtText;
    [SerializeField] private Image Background;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreText.text = "Score: " + score;
        }
    }
    private int healt;
    public int Healt
    {
        get { return healt; }
        set
        {
            healt = value;
            HealtText.text = "Healt: " + healt;
        }
    }


    private void Start()
    {
        Time.timeScale = 1;

        ScoreText.gameObject.SetActive(true);
        HealtText.gameObject.SetActive(true);
        Background.gameObject.SetActive(false);

        Score = 0;
        Healt = 3;
        ChangePosition();
    }

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
            Vector3 point = PositionHistory[Mathf.Clamp(index * (int)Gap, 0, PositionHistory.Count - 1)];

            Vector3 moveDirection = point - tail.transform.position;
            tail.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            tail.transform.LookAt(point);
            index++;
        }



    }


    public void ChangePosition()
    {
        Vector3 newFoodPosition;
        Vector3 newVeloPosition;
        Vector3 newPoisonPosition;
        do
        {
            var x = (int)Random.Range(-8, 8);
            var z = (int)Random.Range(-8, 8);
            newFoodPosition = new Vector3(x, 0.25f, z);

            var x1 = (int)Random.Range(-8, 8);
            var z1 = (int)Random.Range(-8, 8);
            newVeloPosition = new Vector3(x1, 0.25f, z1);

            var x2 = (int)Random.Range(-8, 8);
            var z2 = (int)Random.Range(-8, 8);
            newPoisonPosition = new Vector3(x2, 0.4f, z2);

        } while (!CanSpawn(newFoodPosition) && !CanSpawn(newVeloPosition) && !CanSpawn(newPoisonPosition));

        Food.transform.position = newFoodPosition;
        Velocity.transform.position = newVeloPosition;
        Poison.transform.position = newPoisonPosition;
    }

    public bool CanSpawn(Vector3 newposition)
    {
        foreach (var item in TailParts)
        {
            var x = Mathf.RoundToInt(item.transform.position.x);
            var z = Mathf.RoundToInt(item.transform.position.z);

            if (item.transform.position == newposition)
            {
                return false;
            }
        }
        return true;
    }


    public void GrowSnake()
    {
        GameObject tail = Instantiate(TailPrefab, PositionHistory[PositionHistory.Count-1],Quaternion.identity);
        TailParts.Add(tail);

    }

    public void PoisonF()
    {
        Healt--;
        if (Healt <= 0)
        {
            Dead();
        }

        int rand = (int)Random.Range(1, 3);

        if (rand == 1)
        {
            moveSpeed *= 0.9f;
            //Gap *= 0.9f;
        }
        if (rand == 2 && TailParts.Count > 1)
        {
            Destroy(TailParts[TailParts.Count - 1]);
            TailParts.RemoveAt(TailParts.Count - 1);
            Score--;
        }

    }
    public void VelocityF()
    {
        moveSpeed *= 1.1f;
        //Gap *= 1.1f;
    }

    public void Dead()
    {
        Time.timeScale = 0;
        Background.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(false);
        HealtText.gameObject.SetActive(false);
        GOScoreText.text = "Score: " + Score;
    }

}
