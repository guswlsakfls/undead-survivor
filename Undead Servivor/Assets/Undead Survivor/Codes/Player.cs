using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // 물리 연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate()
    {
        // 3. 위치 이동
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        // 애니매이션 크기만 준다.
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            sr.flipX = inputVec.x < 0;
        }
    }
}
