using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Point : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player_Controller player_controller = collision.transform.parent.GetComponent<Player_Controller>();
            if (player_controller != null)
            {
                player_controller.Die();
            }
            Debug.Log("Die");
        }
    }
}
