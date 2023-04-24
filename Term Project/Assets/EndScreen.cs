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
        if(team == 0) { winner_text.text = "White Team Wins";}
        else if(team == 1 ) { winner_text.text = "Black Team Wins";}
        else { winner_text.text = "It's a Draw!"; }
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
