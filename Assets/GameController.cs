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

    void Start()
    {
        startTime = _timeCounter;
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


        if (_runCounter)
        {
            HeartAnimator.SetBool("runbeat",true);


            int min = Mathf.FloorToInt(_timeCounter / 60);
            int sec = Mathf.FloorToInt(_timeCounter % 60);

            TimerText.text = min.ToString("00") + ":" + sec.ToString("00");
            _timeCounter -= Time.deltaTime;

            if (_timeCounter <= 0)
            {
                _timeCounter = 0;
                TimerText.text = "00:00";
                _runCounter = false;

                HeartAnimator.Stop();
            }

            if (_timeCounter <= 10 && _timeCounter > 0)
            {
                TextAnimation.SetTrigger("panic");
                TimerText.color = Color.red;

            }



            SliderGO.value = (startTime - _timeCounter) / startTime;
        }

       
	}
}