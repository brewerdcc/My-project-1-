using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer_Script : MonoBehaviour
{
    public GameObject NameText;
    public float TimerLeft;
    public float IntroDelay = 2;
    public bool TimerOn = false;

    public GameObject LoseScreen;
    public GameObject LoseButton;

    public GameObject StartScreen;

    public TextMeshProUGUI TimerTxt;

    public GameObject Player1;
    public GameObject WinScreen;

    public AudioClip loseSound;
    public AudioClip startSound;


    public bool loser = false;
    public bool inGame = false;

    void Start()
    {
        LoseScreen.SetActive(false);
        LoseButton.SetActive(false);
        StartScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(startSound, Player1.transform.position);
        Player1.SetActive(false);
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(IntroDelay > 0)
        {
            IntroDelay -= Time.deltaTime;
        }
        else if(inGame == false)
        {
            StartScreen.SetActive(false);
            Player1.SetActive(true);
            inGame = true;
        }



        if(WinScreen.activeSelf)
        {
        }
        else if(TimerLeft > 0)
        {
            TimerLeft -= Time.deltaTime;
            updateTimer(TimerLeft);
        }
        else if(loser == false)
        {
            TimerLeft = 0;
            TimerOn = false;
            ///other.CompareTag("losetag").SetActive(true);
            AudioSource.PlayClipAtPoint(loseSound, Player1.transform.position);
            Player1.SetActive(false);
            LoseScreen.SetActive(true);
            LoseButton.SetActive(true);
            loser = true;
        }
        
    }
    void updateTimer(float currentTime)
{
    currentTime += 1;

    float minutes = Mathf.FloorToInt(currentTime / 60);
    float seconds = Mathf.FloorToInt(currentTime % 60);

    TimerTxt.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
}

}
