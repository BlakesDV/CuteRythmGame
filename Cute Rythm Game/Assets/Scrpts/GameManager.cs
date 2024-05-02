using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioSource musicSource;
    public bool startPlaying;
    public BeatDrop beatDrop;
    public int currentScore;
    public int scorePerNote = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
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
        currentScore += scorePerNote;
    }

    public void NoteMissed()
    {
        Debug.Log("no");
    }
}
