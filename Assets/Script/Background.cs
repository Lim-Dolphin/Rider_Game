using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject Player;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(x, y, 0);
    }
}
