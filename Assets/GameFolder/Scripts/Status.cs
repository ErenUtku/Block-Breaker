using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float Speed = 1f;
    [SerializeField] int PointPerBlock = 300;
    [SerializeField] int Score = 0;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] bool isAutoPlayEnabled;


   


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Status>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    void Update()
    {
        Time.timeScale = Speed;
    }

    public void AddToScore()
    {
        Score += PointPerBlock;
        scoretext.text = Score.ToString();
    }

    public void reset()
    {

        Destroy(gameObject);
        //scoretext.text = "0";
        //Score = 0;    
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
