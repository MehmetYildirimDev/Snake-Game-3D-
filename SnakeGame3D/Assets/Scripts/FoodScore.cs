using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodScore : MonoBehaviour
{
    public Text ScoreText;
    public Text HealtText;

    [SerializeField] private float FoodSpeed = 5f;

    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreText.text = score.ToString();
        }
    }
    private int healt;

    public int Healt
    {
        get { return healt; }
        set
        {
            healt = value;
            HealtText.text = healt.ToString();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Healt = 3;

        InvokeRepeating("Food", 0f, FoodSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Food()
    {
        float x = (int)Random.Range(-10f, 11f);
        float z = (int)Random.Range(-10f, 11f);

        Vector3 FoodPosition = new Vector3(x, 0.5f, z);
        transform.position = FoodPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            Debug.Log("Snakle carpýstý");
            CancelInvoke();
            ReplayFood();
            Score++;
            
        }

        if (other.CompareTag("Tail"))
        {
            Debug.Log("Kuyrukla carpýstý");
            ReplayFood();
        }
    }

    private void ReplayFood()
    {
        CancelInvoke();
        InvokeRepeating("Food", 0f, FoodSpeed);
    }
}
