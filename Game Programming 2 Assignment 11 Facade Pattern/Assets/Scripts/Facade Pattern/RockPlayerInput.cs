/*
* (Christopher Green)
* (RockPlayerInput.cs)
* (Assignment 11)
* (This script defines what the rock player input button will do when it is pressed.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockPlayerInput : MonoBehaviour
{

    private GameManager gameMan;

    private void Awake()
    {
        gameMan = GameObject.FindObjectOfType<GameManager>();
    }

    public IEnumerator ThrowRock()
    {
        gameMan.playerHandNum = 1;

        gameMan.TurnButtonsOff();

        if (gameMan.playerHandNum == gameMan.computerHandNum)
        {
            gameMan.descriptionText.text = "You tied!";
            gameMan.NewRoundStart();
        }
        else if (gameMan.playerHandNum == 1 && gameMan.computerHandNum == 2)
        {
            gameMan.descriptionText.text = "You lost that round, too bad!";
            gameMan.totalLosesNum++;
            gameMan.NewRoundStart();
        }
        else if (gameMan.playerHandNum == 1 && gameMan.computerHandNum == 3)
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
