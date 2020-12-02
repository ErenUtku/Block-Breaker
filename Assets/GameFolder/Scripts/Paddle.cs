using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float MinX = 1f;
    [SerializeField] float MaxX = 15f;

    Status TheStatus;
    Ball TheBall;

    void Start()
    {
        TheStatus = FindObjectOfType<Status>();
        TheBall = FindObjectOfType<Ball>();
    }



    void Update()
    {
        
        float MousePosInUnits=Input.mousePosition.x / Screen.width * ScreenWidthInUnits ;
        Vector2 PaddlePos = new Vector2(MousePosInUnits, transform.position.y);
        PaddlePos.x = Mathf.Clamp(GetXPos(), MinX, MaxX);
        transform.position = PaddlePos;
        
    }

    private float GetXPos()
    {
        if (TheStatus.IsAutoPlayEnabled())
        {
            return TheBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }



}
