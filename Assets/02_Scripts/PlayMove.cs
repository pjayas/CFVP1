using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool isDown = false; // ���ȴ��� Ȯ���ϴ� ����
    bool beUsed = false; // Player�� ���ư��� ������ Ȯ���ϴ� ����

    Rigidbody2D rb; // Rigidbody2D ����� �̿��� ������ �����̶� Rigidbody2D Ŭ������ ���� rb���� ����

    Vector2 prevPos = Vector2.zero; // ���� ��ġ�� �����ϱ� ���� ����
    Vector2 inputPos = Vector2.zero;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // rb������ ���� ����� Rigidbody2D ������Ʈ�� ����

        if (rb == null) // ����ó��. rb�� ������ ���ٴ� ��� ���
        {
            Debug.Log("RigidBody2D is NULL"); // Rigidbody2D�� ������ �α׷� ���
            return; // �Լ� ����
        }
    }

    void Update()
    {
        if (beUsed == false && Input.GetMouseButton(0)) //���� player�� ���� ���� ���� ����(false)�̰� ���콺�� ������ �ʾҴٸ�
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //pos�� ����ī�޶��� ���콺 ������ ���� �Է¹޴´�.
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, Vector2.zero); //RaycastHit2D�� ���콺 Ŭ�� �� ���콺 �������� �浹 ��� ������ �� �� �ִ�.
            if (hit.collider != null && hit.collider.gameObject == this.gameObject) //���� hit(���콺 ������ ���)�� �ƹ��͵� �ƴ� �����̰ų�
                                                                                    //(�浹�� ����)�̰�
                                                                                    //�� �浹 ����� this.gameobject �� player�� ��쿡
            {
                isDown = true; //���콺 ���ȴٰ� ����
                rb.velocity = Vector2.zero; //?
                prevPos = pos; //PrevPos�� ��ġ�� ����ī�޶��� ���콺������ ��ġ�� ����
                Debug.Log(hit);
                

            }
            if (isDown == true) //���� ���콺�� �������¶��
            {
                inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //InputPos�� ��ġ�� ����ī�޶��� ���콺������ ��ġ�� ����
                transform.position = inputPos; //���콺������ ��ǥ�� ��ġ�� �̵�
            }
        }
    }
}