using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource musicSource;
    public bool startPlaying;
    public BeatDrop beatDrop;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGreatNote = 125;
    public int scorePerPerfectNote = 150;
    public TMP_Text scoreText;
    public TMP_Text streakText;

    public int currentStreak;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public float totalScore;
    public float okHits;
    public float greatHits;
    public float perfectHits;
    public float missedHits;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "0";
        streakText.text = "x0";
        currentStreak = 1;
        totalScore = FindObjectsOfType<NoteController>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            //change any key to space, specify in canvas "press space to start"
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                beatDrop.hasStarted = true;
                musicSource.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("si");

        if(currentStreak - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentStreak - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentStreak++;
            }
        }
        currentScore += scorePerNote * currentStreak;
        scoreText.text = "" + currentScore;
        streakText.text = "x" + currentStreak;
    }

    public void OkHit()
    {
        currentScore += scorePerNote * currentStreak;
        NoteHit();
    }
    public void GreatHit()
    {
        currentScore += scorePerGreatNote * currentStreak;
        NoteHit();
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentStreak;
        NoteHit();
    }
    public void NoteMissed()
    {
        Debug.Log("no");
        currentStreak = 1;
        multiplierTracker = 0;
        streakText.text = "x" + currentStreak;
    }
}
