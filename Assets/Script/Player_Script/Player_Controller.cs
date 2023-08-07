using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody = null;
    public GameObject Front_Wheel = null;
    public GameObject Rear_Wheel = null;
    public GameObject GameManager = null;

    public float Speed = 3.0f;                  //�ӵ�
    public float Max_Speed = 10.0f;             //�ִ� �ӵ�
    public float rotationSpeed = 360.0f;         //ȸ�� �ӵ�

    public float Player_rotate = 0.0f;          //ȸ�� ���� ����

    //�ϴ��� ���� �ִ��� ����
    private bool isFly = false;

    //�� ������ �ٴ� ��ġ ����
    private bool Front_Wheel_istouching = false;
    private bool Rear_Wheel_istouching = false;

    //Score
    private int Score = 0;
    private int Rotate_score = 0;

    //Score UI
    public GameObject Score_UI = null;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Player_rotate = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetComponent<GameManager>().Get_isPlay())
        {
            if(Score_UI.activeSelf == false)
            {
                Score_UI.SetActive(true);
            }    
      
            Front_Wheel_istouching = Front_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();
            Rear_Wheel_istouching = Rear_Wheel.GetComponent<Wheel>().Get_Wheel_isTouched();

            if(isFly && (Front_Wheel_istouching && Rear_Wheel_istouching))
            {
                Score += Rotate_score;
                isFly = false;
            }

            //�ְ� �ӵ��� ���� �ʰ� �� ������ �ٴڿ� ������� ���� ����
            if (Input.GetMouseButton(0) && (Front_Wheel_istouching && Rear_Wheel_istouching))
            {
                isFly = false;
                Accelerate_Player();

                //Debug.Log("�ӵ� : " + playerRigidbody.velocity);
                //Debug.Log("����");
            }

            //�� ���� ������ �ٴڰ� ������ ��� ȸ��
            if (Input.GetMouseButton(0) && (!(Front_Wheel_istouching) && !(Rear_Wheel_istouching)))
            {
                Rotate_Player();
                isFly = true;
                // Debug.Log("ȸ��");
            }

            Score_Update();
        }
    }

    //���� �Լ�
    void Accelerate_Player()
    {
        Player_rotate = transform.eulerAngles.z;
        if (playerRigidbody.velocity.magnitude < new Vector2(Max_Speed, 0).magnitude)
        {
            playerRigidbody.AddForce(transform.right * Speed);
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
        // Debug.Log("�÷��̾� ȸ�� ���� : " + Player_rotate);
        if(Player_rotate >= 360.0) 
        {
            Rotate_score++;
            Debug.Log("�÷��̾� ȸ�� ���� : " + Rotate_score);
            Player_rotate = 0.0f;
        }
    }

    public void Die()
    {
        Score_UI.SetActive(false);
        gameObject.SetActive(false);
        GameManager.GetComponent<GameManager>().Set_Score(Score);
        Reset_Player();
        GameManager.GetComponent<GameManager>().Restart();
    }    

    public void Add_Score()
    {
        Score++;
        Debug.Log("���� ���� : " + Score);
    }

    public void Reset_Player()
    {
        Score = 0;
        Rotate_score = 0;
        Player_rotate = 0f;
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        gameObject.SetActive(true);
    }

    public void Score_Update()
    {
        Score_UI.transform.GetChild(0).GetComponent<Text>().text = Score.ToString();
    }
}