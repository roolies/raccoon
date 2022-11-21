using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public float ScoreValue;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + ScoreValue.ToString();

       

        PlayerPrefs.SetString("currentScore", "0");
    }

    void Update()
    {
        PlayerPrefs.SetString("currentScore", score.text);
    }




}
