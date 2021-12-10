using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwanScript : MonoBehaviour
{

    private float maxTime = 2;
    private float timer = 1;
    public GameObject pipe;
    private float height = 0.6f;
    private float dTime = 5f;

    private bool isGameStart;


    // Start is called before the first frame update
    void Start()
    {
       isGameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer > maxTime && isGameStart)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0 , Random.Range(-height ,height) , 0);
            
            Destroy(newPipe, dTime);

            timer = 0;
        }
        

        timer += Time.deltaTime;

    }

    public void SetGameStart(bool value)
    {
        isGameStart = value;
    }

    public static void ScoreActive (bool isactive)
    {
        

    }
}
