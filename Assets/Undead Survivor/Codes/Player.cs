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
        // GetComponent 로 Rigidbody2D가져옴
        rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // edit -> projectSettings -> InputManager 가면 확인할 수 있음
        // input.GetAxis는 입력 값이 부드러워 짐

        //inputVec.x = Input.GetAxis("Horizontal");
        //inputVec.y = Input.GetAxis("Vertical");

        // input.GetAxisRaw는 더 명확한 컨트롤 기능을 구현한다.
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

    }

    // 물리 연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate()
    {
        //// 1. 힘을 준다.
        //rigid.AddForce(inputVec);

        //// 2. 속도 제어
        //rigid.velocity = inputVec;

        // normalized 어떤 크기든 벡터값의 크기가 1이 되도록 좌표를 수정한 값이다.(상하좌우는 1이지만, 대각선은 루트2이기 때문에 같은속도를 위해서임)
        // fixedDelta fixedupdate에서 사용되며 물리 프레임 하나만큼 소모된 시간을 의미한다.
        Vector2 nextVector = inputVec.normalized * speed * Time.fixedDeltaTime;

        // 3. 위치 이동 MovePosition 은 위치 이동이기 때문에 현재의 위치도 더해줘야 한다.
        rigid.MovePosition(rigid.position + nextVector);

    }
}
