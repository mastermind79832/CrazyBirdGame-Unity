using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public static int score = 0;
    public static int highScore ;

    public static int pipePassed;

    private bool isIncreased ;

    private void Start()
    {
        score = 0;
        GetHighScore();
        pipePassed = 0;
        Time.timeScale = 1;
        isIncreased = false;

    }


    void ScoreIncrease()
    {
        if(!isIncreased)
        {
            Time.timeScale += 0.2f;
            isIncreased =true;
        }
    }

    public static void SetHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
    }

    public static void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        if(pipePassed % 10 == 0 && pipePassed != 0 && Time.timeScale < 2)
        {
            ScoreIncrease();
        }
        else
        {
            isIncreased = false;
        }
    }
}
