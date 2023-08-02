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
    public float rotationSpeed = 360.0f;         //회전 속도

    public float Player_rotate = 0.0f;          //회전 값을 누적
    //두 바퀴의 바닥 터치 여부
    private bool Front_Wheel_istouching = false;
    private bool Rear_Wheel_istouching = false;

    //Score
    private int Score = 0;
    private int Rotate_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Player_rotate = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        Front_Wheel_istouching = Front_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();
        Rear_Wheel_istouching = Rear_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();

        //최고 속도를 넘지 않고 두 바퀴가 바닥에 닿아있을 때만 가속
        if (Input.GetMouseButton(0) && (Front_Wheel_istouching && Rear_Wheel_istouching))
        {
            Accelerate_Player();

            //Debug.Log("속도 : " + playerRigidbody.velocity);
            //Debug.Log("가속");
        }
        
        //두 개의 바퀴가 바닥과 떨어질 경우 회전
        if (Input.GetMouseButton(0) && (!(Front_Wheel_istouching) && !(Rear_Wheel_istouching)))
        {
            Rotate_Player();
           // Debug.Log("회전");
        }
    }

    //가속 함수
    void Accelerate_Player()
    {
        Player_rotate = 0.0f;
        if (playerRigidbody.velocity.magnitude < new Vector2(Max_Speed, 0).magnitude)
        {
            playerRigidbody.AddForce(new Vector2(Speed, 0));
        }
        else
        {
            playerRigidbody.velocity = new Vector2(Max_Speed, 0);
        }
    }

    void Rotate_Player()
    {
        transform.Rotate(0f, 0f, rotationSpeed*Time.deltaTime);

        //Debug.Log(transform.eulerAngles.z);
        Player_rotate += Mathf.Abs(transform.eulerAngles.z- Player_rotate);
        // Debug.Log("플레이어 회전 상태 : " + Player_rotate);
        if(Player_rotate >= 360.0) 
        {
            Rotate_score++;
            Debug.Log("플레이어 회전 점수 : " + Rotate_score);
            Player_rotate = 0.0f;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }    

    public void Add_Score()
    {
        Score++;
        Debug.Log("현재 점수 : " + Score);
    }
}