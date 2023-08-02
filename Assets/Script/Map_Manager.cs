using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Manager : MonoBehaviour
{
    public GameObject Game_Manager;
    // Start is called before the first frame update
    void Start()
    {
        Game_Manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
