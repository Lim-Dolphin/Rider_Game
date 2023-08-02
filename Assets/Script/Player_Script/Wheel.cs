using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public GameObject player;

    private bool isTouched = false;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject; //부모 객체 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Get_Wheel_isTouched()
    {
        return isTouched;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isTouched = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isTouched = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouched = false;
    }
}
