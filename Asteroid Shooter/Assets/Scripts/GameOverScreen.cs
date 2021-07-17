using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";

    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

}
