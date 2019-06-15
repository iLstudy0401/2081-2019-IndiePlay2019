using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggle1 : MonoBehaviour {

    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;
    private float time=0;
    private float inter1 = 0.4f;
    private float inter2 = 4f;

    private void Update()
    {
        if (time != 0)
        {
            if (Time.time - time > inter1)
            {
                stone2.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
            if (Time.time - time > inter2)
            {
                stone3.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stone1.GetComponent<Rigidbody2D>().gravityScale = 1f;
            time = Time.time;
        }
    }
}
