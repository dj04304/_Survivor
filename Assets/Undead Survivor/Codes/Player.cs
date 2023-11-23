using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        // GetComponent �� Rigidbody2D������
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // edit -> projectSettings -> InputManager ���� Ȯ���� �� ����
        // input.GetAxis�� �Է� ���� �ε巯�� ��

        //inputVec.x = Input.GetAxis("Horizontal");
        //inputVec.y = Input.GetAxis("Vertical");

        // input.GetAxisRaw�� �� ��Ȯ�� ��Ʈ�� ����� �����Ѵ�.
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }

    // ���� ���� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    void FixedUpdate()
    {
        //// 1. ���� �ش�.
        //rigid.AddForce(inputVec);

        //// 2. �ӵ� ����
        //rigid.velocity = inputVec;

        // normalized � ũ��� ���Ͱ��� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ���̴�.(�����¿�� 1������, �밢���� ��Ʈ2�̱� ������ �����ӵ��� ���ؼ���)
        // fixedDelta fixedupdate���� ���Ǹ� ���� ������ �ϳ���ŭ �Ҹ�� �ð��� �ǹ��Ѵ�.
        Vector2 nextVector = inputVec.normalized * speed * Time.fixedDeltaTime;

        // 3. ��ġ �̵� MovePosition �� ��ġ �̵��̱� ������ ������ ��ġ�� ������� �Ѵ�.
        rigid.MovePosition(rigid.position + nextVector);

    }
}
