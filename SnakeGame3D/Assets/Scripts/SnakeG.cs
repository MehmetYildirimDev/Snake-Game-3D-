using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeG : MonoBehaviour
{
    private GameObject[] SnakeList;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //index = PlayerPrefs.GetInt("SnakeSelected");
        SnakeList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)//tüm alt objeleri diziye attýk 
        {
            SnakeList[i] = transform.GetChild(i).gameObject;//alt objeye ulasmak için
        }

        foreach (GameObject item in SnakeList)//tu objeleri gorunmez yaptýk
        {
            item.SetActive(false);
        }

        SnakeList[index].SetActive(true);

    }

}
