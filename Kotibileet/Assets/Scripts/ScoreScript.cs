﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    int player1Score, player2Score, player3Score, player4Score;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int playerNumber)
    {
        switch(playerNumber)
        {
            case 1 :
                player1Score++;
                break;
            case 2:
                player2Score++;
                break;
            case 3:
                player3Score++;
                break;
            case 4:
                player4Score++;
                break;
        }    
    }

    public void printScores()
    {
        Debug.Log("player1score: " + player1Score);
        Debug.Log("player2score: " + player2Score);
        Debug.Log("player3score: " + player3Score);
        Debug.Log("player4score: " + player4Score);
    }
}