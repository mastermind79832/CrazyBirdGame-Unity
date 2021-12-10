using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    
    public GameObject popUpScore;

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject popUp = Instantiate(popUpScore, transform.position , Quaternion.identity);
        
        popUp.transform.parent = gameObject.transform;

        Destroy(popUp, 0.9f);
        ScoreScript.score += 2;
    }

}
