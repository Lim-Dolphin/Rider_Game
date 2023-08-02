using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public GameObject Player;

    //카메라 x, y, z 위치
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;
    public float offsetZ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        offsetX = Mathf.Abs(Player.transform.position.x-transform.position.x);
        offsetY = Mathf.Abs(Player.transform.position.y-transform.position.y);
        offsetZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x+offsetX, Player.transform.position.y+offsetY,-10);
    }
}
