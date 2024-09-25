using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool isDown = false; // 눌렸는지 확인하는 변수
    bool beUsed = false; // Player가 날아가는 중인지 확인하는 변수

    Rigidbody2D rb; // Rigidbody2D 기능을 이용해 움직일 예정이라 Rigidbody2D 클래스를 담을 rb변수 선언

    Vector2 prevPos = Vector2.zero; // 이전 위치를 저장하기 위한 변수
    Vector2 inputPos = Vector2.zero;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // rb변수에 실제 사용할 Rigidbody2D 컴포넌트를 대입

        if (rb == null) // 예외처리. rb가 없으면 없다는 경고 출력
        {
            Debug.Log("RigidBody2D is NULL"); // Rigidbody2D가 없음을 로그로 출력
            return; // 함수 종료
        }
    }

    void Update()
    {
        if (beUsed == false && Input.GetMouseButton(0)) //만약 player가 날고 있지 않은 상태(false)이고 마우스가 눌리지 않았다면
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //pos는 메인카메라의 마우스 포인터 값을 입력받는다.
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, Vector2.zero); //RaycastHit2D는 마우스 클릭 후 마우스 포인터의 충돌 대상 정보를 알 수 있다.
            if (hit.collider != null && hit.collider.gameObject == this.gameObject) //만약 hit(마우스 포인터 대상)이 아무것도 아닌 상태이거나
                                                                                    //(충돌된 상태)이고
                                                                                    //이 충돌 대상이 this.gameobject 즉 player일 경우에
            {
                isDown = true; //마우스 눌렸다고 변경
                rb.velocity = Vector2.zero; //?
                prevPos = pos; //PrevPos의 위치를 메인카메라의 마우스포인터 위치로 지정
                Debug.Log(hit);
                

            }
            if (isDown == true) //만약 마우스가 눌린상태라면
            {
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //InputPos의 위치를 메인카메라의 마우스포인터 위치로 선언
                transform.position = inputPos; //마우스포인터 좌표값 위치로 이동
            }
        }
    }
}