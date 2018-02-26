using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

   
    public Text TimerText;

    public float _timeCounter = 300;
    public bool _runCounter;

    public Slider SliderGO;

    private float startTime;

    public Animator HeartAnimator, TextAnimation;

    public AudioSource audiosource;

    public GameObject skiftpladser;


    private bool GameHasRunOnce;

    void Start()
    {
        startTime = _timeCounter;

        SliderGO.value = 0;
    }



	void Update()
	{

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timeCounter > 0)
            {
                _runCounter = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            audiosource.PlayOneShot(audiosource.clip);
        }


        // FIKSE KNAPPER 
        if(Input.GetKeyDown(KeyCode.Minus))
            {
            _timeCounter -= 10;

            if (GameHasRunOnce == false)
            {
                startTime = _timeCounter;
            }
            }

        if(Input.GetKeyDown(KeyCode.Plus))
        {
            _timeCounter += 10;

            if (GameHasRunOnce == false)
            {
                startTime = _timeCounter;
            }
        }

        int min = Mathf.FloorToInt(_timeCounter / 60);
        int sec = Mathf.FloorToInt(_timeCounter % 60);

        TimerText.text = min.ToString("00") + ":" + sec.ToString("00");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (_runCounter)
        {

            GameHasRunOnce = true;
            HeartAnimator.SetBool("runbeat",true);


           
            _timeCounter -= Time.deltaTime;

            if (_timeCounter <= 0)
            {
                _timeCounter = 0;
                TimerText.text = "00:00";
                _runCounter = false;
                audiosource.PlayOneShot(audiosource.clip);
                skiftpladser.SetActive(true);
                HeartAnimator.Stop();

                SliderGO.gameObject.SetActive(false);
                TimerText.gameObject.SetActive(false);

            }

            if (_timeCounter <= 11 && _timeCounter > 0)
            {
                TextAnimation.SetTrigger("panic");
                TimerText.color = Color.red;

            }



            SliderGO.value = (startTime - _timeCounter) / startTime;
        }

       
	}
}