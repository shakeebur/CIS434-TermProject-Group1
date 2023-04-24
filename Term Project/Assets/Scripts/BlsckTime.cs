using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlsckTime : MonoBehaviour
{
    public Text timerText;
    public float timeLeftSeconds = 3F;
    public static bool TimesUp = false;
    public string GameName;

    public ChessBoard ChessBoard;

    private void Start()
    {
        // Starts the timer automatically
        TimesUp = false;
    }
    void Update()
    {
       if (ChessBoard.currentPlayer == ChessBoard.blackPlayer)
        {
            float t = timeLeftSeconds -= Time.deltaTime;

            string minutes = ((int) t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((int) (t*100f) % 100).ToString("00");

            timerText.text = minutes + ":" + seconds + ":" + milliseconds;

            if (timeLeftSeconds <= 0)
            {
                timeLeftSeconds = 0;
                timerText.text = minutes + ":" + seconds;
                TimesUp = true;
            }
        }

    }
    void OnGUI()
    {
        if(TimesUp == true)
        {
            ChessBoard.currentPlayer = ChessBoard.whitePlayer;
            //Put game over here
            ChessBoard.endGame();
        }
    }
}