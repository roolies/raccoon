using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public GameObject currentScore;

    private Text CurrentScoreText;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScoreText = currentScore.GetComponent<Text>();

        CurrentScoreText.text = PlayerPrefs.GetString("currentScore");
    }
}
