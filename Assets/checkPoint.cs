using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(1);
            gameManager.ReSetPos(this.gameObject);
        }
    }
}
