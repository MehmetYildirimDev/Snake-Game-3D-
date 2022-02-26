using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeSelection : MonoBehaviour
{

    private GameObject[] SnakeList;
    private int index = 0;
    private void Start()
    {
        index = PlayerPrefs.GetInt("SnakeSelected");

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
    

    public void Next()
    {
        SnakeList[index].SetActive(false);

        index++;

        if (index == SnakeList.Length)
        {
            index =0;
        }

        SnakeList[index].SetActive(true);

    }
    public void Back()
    {
        SnakeList[index].SetActive(false);

        index--;

        if (index<0)
        {
            index = SnakeList.Length - 1;
        }

        SnakeList[index].SetActive(true);
    }
    public void Confrim() 
    {
        PlayerPrefs.SetInt("SnakeSelected", index);
        SceneManager.LoadScene(1);
    }

}


