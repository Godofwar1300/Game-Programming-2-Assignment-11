/*
* (Christopher Green)
* (ScissorsPlayerInput.cs)
* (Assignment 11)
* (This script defines what the scissors player input button will do when it is pressed.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPlayerInput : MonoBehaviour
{

    public GameManager gameMan;

    private void Awake()
    {
        gameMan = GameObject.FindObjectOfType<GameManager>();
    }

    public IEnumerator ThrowScissors()
    {
        gameMan.playerHandNum = 3; // scissors

        // 1 = rock, 2 = paper, 3 = scissors

        gameMan.TurnButtonsOff();

        if (gameMan.playerHandNum == gameMan.computerHandNum)
        {
            gameMan.descriptionText.text = "You tied!";
            gameMan.NewRoundStart();
        }
        else if (gameMan.playerHandNum == 3 && gameMan.computerHandNum == 1)
        {
            gameMan.descriptionText.text = "You lost that round, too bad!";
            gameMan.totalLosesNum++;
            gameMan.NewRoundStart();
        }
        else if (gameMan.playerHandNum == 3 && gameMan.computerHandNum == 2)
        {
            gameMan.descriptionText.text = "You won that round!";
            gameMan.totalWinsNum++;
            gameMan.NewRoundStart();
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(gameMan.CountDown());
        yield return new WaitForSeconds(6f);
        gameMan.TurnButtonsOn();

    }
}
