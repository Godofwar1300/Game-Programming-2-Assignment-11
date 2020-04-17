/*
* (Christopher Green)
* (GameManager.cs)
* (Assignment 11)
* (This script defines and carries out the basic gameplay elements.)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text totalRoundsText;
    public Text winsText;
    public Text losesText;
    public Text descriptionText;
    public Text scoreText;

    public GameObject tutorialPanel;
    public Text tutorialTimerText;
    public float timerDuration;

    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;

    public RockPlayerInput rockPlayerInput;
    public PaperPlayerInput paperPlayerInput;
    public ScissorsPlayerInput scissorsPlayerInput;

    public int totalRoundsNum;
    public int totalWinsNum;
    public int totalLosesNum;
    public Text totalScoreNum;

    public int computerHandNum;
    public int playerHandNum;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        StartCoroutine(TutorialTimer());

        computerHandNum = Random.Range(1, 4);

        totalRoundsNum = 1;
        totalWinsNum = 0;
        totalLosesNum = 0;

        winsText.text = "Wins: " + totalWinsNum;
        losesText.text = "Loses: " + totalLosesNum;
        totalRoundsText.text = "Round: " + totalRoundsNum;

        TurnButtonsOff();
        StartCoroutine(CountDown());
        yield return new WaitForSeconds(6f);
        TurnButtonsOn();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        Debug.Log("1 = rock, 2 = paper, and 3 = scissors: \t" + computerHandNum);

        scoreText.text = "Score: " + totalScoreNum;
        winsText.text = "Wins: " + totalWinsNum;
        losesText.text = "Loses: " + totalLosesNum;

        if(totalLosesNum >= 3)
        {
            SceneManager.LoadScene(2);
        }
        else if(totalWinsNum >= 3)
        {
            SceneManager.LoadScene(3);
        }


    }

    public IEnumerator CountDown()
    {

        descriptionText.text = "Rock...";

        yield return new WaitForSeconds(2f);

        descriptionText.text = "Paper...";

        yield return new WaitForSeconds(2f);

        descriptionText.text = "Scissors...";

        yield return new WaitForSeconds(2f);

        descriptionText.text = "Ok, now try to guess what I've thrown!";

    }

    public void RockInput()
    {
        StartCoroutine(rockPlayerInput.ThrowRock());
    }
    public void PaperInput()
    {
        StartCoroutine(paperPlayerInput.ThrowPaper());
    }
    public void ScissorsInput()
    {
        StartCoroutine(scissorsPlayerInput.ThrowScissors());
    }

    public void NewRoundStart()
    {
        totalRoundsNum++;
        totalRoundsText.text = "Round: " + totalRoundsNum;

        computerHandNum = Random.Range(1, 4);
    }

    public void TurnButtonsOn()
    {
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;
    }
    public void TurnButtonsOff()
    {
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;
    }

    public IEnumerator TutorialTimer()
    {
        timerDuration = 2f;

        while(timerDuration > 0)
        {
            timerDuration -= Time.deltaTime;
            tutorialTimerText.text = "Timer: " + timerDuration.ToString("00");
            yield return null;
        }

        if(timerDuration <= 0)
        {
            StopCoroutine(TutorialTimer());
            tutorialPanel.SetActive(false);
        }
    }
}
