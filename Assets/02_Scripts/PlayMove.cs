using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool IsDown = false; //���ȴ��� Ȯ���ϴ� ����
    bool BeUsed = false; //Player�� ���ư��� ������ Ȯ���ϴ� ����

    Rigidbody2D rb; //Rigidbody2D ����� �̿��� ������ �����̶� Rigidbody2D Ŭ������ ���� rb���� ����

    Vector2 PrevPos = Vector2.zero;
    Vector2 InputPos = Vector2.zero;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); //rb������ ���� ����� Rigidbody2D ������Ʈ ����

        if (rb == null) //����ó��. rb�� ������ ���ٴ� ��� ���
        {
            Debug.Log("RigidBody2D is NULL");
            return;
        }

    }

    void Update()
    {
        if (BeUsed == false && Input.GetMouseButton(0)) //���� player�� ���� ���� ���� ����(false)�̰� ���콺�� ������ �ʾҴٸ�
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //pos�� ����ī�޶��� ���콺 ������ ���� �Է¹޴´�.
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, Vector2.zero); //RaycastHit2D�� ���콺 Ŭ�� �� ���콺 �������� �浹 ��� ������ �� �� �ִ�.

            if (hit.collider != null && hit.collider.gameObject == this.gameObject) //���� hit(���콺 ������ ���)�� �ƹ��͵� �ƴ� �����̰ų�(�浹�� ����)�̰� �� �浹 ����� this.gameobject �� player�� ��쿡
            {
                IsDown = true; //���콺 ���ȴٰ� ����
                rb.velocity = Vector2.zero; //?
                PrevPos = pos; //PrevPos�� ��ġ�� ����ī�޶��� ���콺������ ��ġ�� ����
                Debug.Log(hit);

            }
        }
        if (IsDown == true) //���� ���콺�� �������¶��
        {
            InputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //InputPos�� ��ġ�� ����ī�޶��� ���콺������ ��ġ�� ����
            transform.position = InputPos; //���콺������ ��ǥ�� ��ġ�� �̵�
        }
    }
}