using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{

    private bool roundRunning = false;
    public int score;
    public float timeLeft;

    [SerializeField] private float roundLength;

    public TargetScript[] targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeleftText;

    private void Start()
    {
         roundRunning = false ;
    }

    private void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Three))
        {
            StartRound();
        }
    }

    private void FixedUpdate()
    {
        if (!roundRunning) { return; }
        if (timeLeft > 0)
        {
            timeLeft -= 0.02f;
        }
        else if (timeLeft <= 0)
        {
            timeLeft = 0;
        }
        SetTimeLeftToText();
    }

    public void AddToScore()
    {
        if (!roundRunning) { return; }
        score++;
        SetScoreToText();
    }

    private void StartRound()
    {
        if (roundRunning) { return; }
        ResetRound();
        timeLeft = roundLength;
        roundRunning = true;
        StartCoroutine(EndRound(roundLength));
    }

    IEnumerator EndRound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        roundRunning = false;
        //ResetRound();
    }

    private void ResetRound()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].StartCoToGoDown(0.01f);
        }

        score = 0;
        timeLeft = 0;
        SetScoreToText();
        SetTimeLeftToText();
    }

    private void SetScoreToText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void SetTimeLeftToText()
    {
        float _newTimeLeft = Mathf.RoundToInt(timeLeft);
        timeleftText.text = "Time: " + _newTimeLeft.ToString() + " seconds";
    }

}
