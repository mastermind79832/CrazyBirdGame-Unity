using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{

    public GameObject gameManager;
    public float speed = -1;
    public float slowTime = 10f;
    private Rigidbody2D rb;

    bool isTimeChange = false;

    public GameObject popUpScore;
    
    private void Awake()
    {
        if(isTimeChange)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime =Time.fixedDeltaTime * slowTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().enabled = true;
        transform.GetComponent<SpriteRenderer>().flipY = false;
        rb.simulated = false;
        transform.GetComponent<SpriteRenderer>().color = Color.white;
       
       
    }


    private void DeathEnable()
    {
        gameManager.GetComponent<GameManager>().GameOver();
            // transform.GetComponent<SpriteRenderer>().flipY = true;
        GetComponent<Animator>().enabled = false;
        transform.GetComponent<SpriteRenderer>().color = Color.red;
        Time.timeScale = 1/slowTime;
        Time.fixedDeltaTime =Time.fixedDeltaTime / slowTime;
        isTimeChange = true;

        
    }
    // IEnumerator Restart()
    // {

    //     Time.timeScale = 1/slowTime;
    //     Time.fixedDeltaTime =Time.fixedDeltaTime / slowTime;

    //     yield return new WaitForSeconds(1f / slowTime);

    //     Time.timeScale = 1f;
    //     Time.fixedDeltaTime =Time.fixedDeltaTime * slowTime;
    // }

    // Update is called once per frame
    void Update()
    {

        
        
         if( ScoreScript.score < 0 )
        {
            DeathEnable();
        }

        //input mouse ( or spaceto be added)

        if ( Input.GetMouseButtonDown(0) && gameManager.GetComponent<GameManager>().isGameStart || Input.GetButtonDown("Jump"))
        {

            //jump
            rb.velocity = Vector2.up * speed;

        }


        
        

        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if( other.gameObject.tag == "Ground")
        {
            DeathEnable();
        }

        if( other.gameObject.tag == "Pipe" )
        {
            GameObject popUp = Instantiate(popUpScore, transform.position , Quaternion.identity);
            popUp.GetComponent<TextMesh>().text = "-1";
            popUp.GetComponent<TextMesh>().color = Color.red;
            popUp.transform.parent = gameObject.transform;
            Destroy(popUp, 0.9f);
            ScoreScript.score -= 1;
            ScoreScript.pipePassed += 1;

            other.transform.parent.gameObject.transform.Find("ScoreObject").gameObject.SetActive(false);



        }
      
    }


   

    private void OnTriggerExit2D(Collider2D other)
    {
        
            GameObject popUp = Instantiate(popUpScore, transform.position , Quaternion.identity);
            popUp.GetComponent<TextMesh>().text = "+1";
            popUp.GetComponent<TextMesh>().color = Color.white;
            popUp.transform.parent = gameObject.transform;
            Destroy(popUp, 0.9f);
            ScoreScript.score += 1;
            ScoreScript.pipePassed += 1;
        
    }
}
