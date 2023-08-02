using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Point : MonoBehaviour
{
    public int Map_half_size = 60;
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
        Debug.Log("체크 포인트");
        if (collision.tag == "Player")
        {
            collision.transform.parent.GetComponent<Player_Controller>().Add_Score();
            gameObject.SetActive(false);
            GameManager gameManager = gameObject.transform.parent.GetComponent<Map_Manager>().Game_Manager.GetComponent<GameManager>();
            gameManager.Map_Move();
            collision.transform.parent.position = new Vector2(collision.transform.parent.position.x - Map_half_size, collision.transform.parent.position.y);
        }
    }
}
