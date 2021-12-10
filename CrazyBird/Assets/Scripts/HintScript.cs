using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GameObject hint;

    private void Start()
    {
        hint = gameObject.transform.Find("Hint").gameObject;
        hint.SetActive(false);
    }

    public void HintDisplay()
    {
        if(hint.activeInHierarchy)
        {
            hint.SetActive(false);
        }
        else
        {
             hint.SetActive(true);
        }
    }

}
