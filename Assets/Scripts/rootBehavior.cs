using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rootBehavior : MonoBehaviour {

    private float time;
    public float inter = 2f;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        this.GetComponent<Collider2D>().isTrigger = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update () {
        if (this.GetComponent<Collider2D>().isTrigger == true)
            time = Time.time;
        if (Time.time - time >= inter)
        {
            this.GetComponent<Collider2D>().isTrigger = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            playerController.unVisual();
        }
	}
}
