using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovepipeScript : MonoBehaviour
{

    public float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // moveSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

    }
}
