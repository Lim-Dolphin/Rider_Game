using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody = null;
    public GameObject Front_Wheel = null;
    public GameObject Rear_Wheel = null;

    public float Speed = 3.0f;                  //속도
    public float Max_Speed = 10.0f;             //최대 속도

    //두 바퀴의 바닥 터치 여부
    private bool Front_Wheel_istouching = false;
    private bool Rear_Wheel_istouching = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Front_Wheel_istouching = Front_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();
        Rear_Wheel_istouching = Front_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();

        //최고 속도를 넘지 않고 두 바퀴가 바닥에 닿아있을 때만 가속
        if (Input.GetMouseButton(0) && (Front_Wheel_istouching && Rear_Wheel_istouching))
        {
            Accelerate_Player();

            Debug.Log("속도 : " + playerRigidbody.velocity);
            Debug.Log("가속");
        }
        
        if (Input.GetMouseButton(0) && (!(Front_Wheel_istouching) || !(Rear_Wheel_istouching)))
        {
            Debug.Log("회전");
        }
    }

    void Accelerate_Player()
    {
        if (playerRigidbody.velocity.magnitude < new Vector2(Max_Speed, 0).magnitude)
        {
            playerRigidbody.AddForce(new Vector2(Speed, 0));
        }
        else
        {
            playerRigidbody.velocity = new Vector2(Max_Speed, 0);
        }
    }
}