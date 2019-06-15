using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GameObject player;
    [SerializeField]
    private static Vector3 reSetPos=Vector3.zero;
    Camera mainCamera;
    private static Vector3 CameraPos = new Vector3(0.5f, 0f , -10f);

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        reSetPos = player.transform.position;
        CameraPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        mainCamera = Camera.main;
        ReSetPlayer();
    }

    public void ReSetPlayer()
    {
        Camera.main.transform.position = CameraPos;
        player.transform.position = reSetPos;
    }

    public void ReSetPos(GameObject temp)
    {
        Debug.Log(reSetPos);
        reSetPos = temp.transform.position;
    }

    public void SetCameraPos()
    {
        CameraPos = mainCamera.transform.position;
    }
}
