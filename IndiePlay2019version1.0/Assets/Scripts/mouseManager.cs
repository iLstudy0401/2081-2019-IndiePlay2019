using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour {

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, 2f);
            Debug.Log(colliders.Length);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].tag == "root")
                {
                    Debug.Log(0);
                    GameObject temp = colliders[i].gameObject;
                    if (temp.GetComponent<Collider2D>().isTrigger == true)
                    {
                        temp.GetComponent<Collider2D>().isTrigger = false;
                        temp.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }       
    }
}
