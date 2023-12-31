
using System;
using UnityEngine;

//
// Sea Wolf v2021.01.31
//
// 2021.01.24
//

public class TimerController : MonoBehaviour
{
    public static TimerController timerController;

    public SpriteRenderer[] timer;

    public Sprite[] numberDigits;


    private void Awake()
    {
        timerController = this;
    }


    public void UpdateTimerDisplay(int seconds)
    {
        string timerText = seconds.ToString();

        for (int timerDigit = 0; timerDigit < timerText.Length; timerDigit++)
        {
            string digitText = timerText.Substring(timerDigit, 1);

            int digit = Convert.ToInt32(digitText);

            switch (timerText.Length)
            {
                // 00
                case 2:

                    timer[timerDigit].sprite = numberDigits[digit];

                    break;

                // 0
                case 1:

                    timer[timerDigit].sprite = numberDigits[0];
                    timer[timerDigit + 1].sprite = numberDigits[digit];

                    break;
            }
        }
    }


} // end of class
