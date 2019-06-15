using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platDisaper : MonoBehaviour {

    private float time;
    private float inter = 2f;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - time >= inter)
            Destroy(this.gameObject);
	}
}
