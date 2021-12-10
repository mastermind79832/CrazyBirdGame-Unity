using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public GameObject hintDispplay;

    private bool isGameOver;
    public bool isGameStart;

    public GameObject gameOverCanvas;
    public GameObject playButton;

    public GameObject title;

    public GameObject ground;

    public GameObject spwanPoint;

    public GameObject scoreText;

    public GameObject flyer;

    public GameObject getReady;
    public GameObject highScoreText;




    private void Start()
    {
        isGameStart = false;
        isGameOver = false;
        ground.GetComponent<Animator>().enabled = true;
        gameOverCanvas.SetActive(false);
        playButton.SetActive(true);
        title.SetActive(true);
        scoreText.SetActive(false);
        hintDispplay.SetActive(true);
        ScoreScript.GetHighScore();
        highScoreText.SetActive(true);
        highScoreText.GetComponent<Text>().text = "HIGHSCORE : " + ScoreScript.highScore.ToString();
    }

    public void GameOver()
    {

        gameOverCanvas.SetActive(true);
        playButton.SetActive(true);
        title.SetActive(false);
      //  Time.timeScale = 0;

        isGameOver = true;
        isGameStart = false;
        ground.GetComponent<Animator>().enabled = false;
        spwanPoint.GetComponent<PipeSpwanScript>().SetGameStart(false);

        ScoreScript.SetHighScore();
        
        //destroy all pipes
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
            GameObject.Destroy(pipe);
    }

   
    public void Replay()
    {
        if(isGameOver && !isGameStart)
        {
            SceneManager.LoadScene(0);
            isGameOver = false;
        }
        
        if(!isGameOver && !isGameStart)
        {
            //Time.timeScale = 1;
            title.SetActive(false);
            playButton.SetActive(false);
            
            isGameStart = true;
            scoreText.SetActive(true);
            hintDispplay.SetActive(false);
            HintScript.hint.SetActive(false);
            highScoreText.SetActive(false);
            StartCoroutine(SetFlyer());
        }
    }

     IEnumerator SetFlyer()
    {   
        getReady.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        flyer.GetComponent<Rigidbody2D>().simulated = true;
        getReady.SetActive(false);
        spwanPoint.GetComponent<PipeSpwanScript>().SetGameStart(true);
        
    }


}
