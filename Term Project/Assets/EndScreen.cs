using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TMP_Text winner_text;

    public void Setup(int team)
    {
        gameObject.SetActive(true);
        if(team == 0) { winner_text.text = "Checkmate! \n White Team Wins";}
        else { winner_text.text = "Checkmate! \n Black Team Wins";}
    }

    public void newGameButton()
    {
        SceneManager.LoadScene("ChessGame");
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
