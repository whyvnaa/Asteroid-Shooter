using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    private TextMeshProUGUI Score;

    private void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Score.text = scoreValue.ToString();
    }
}
