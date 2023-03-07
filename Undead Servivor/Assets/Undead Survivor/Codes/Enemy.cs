using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        isLive = true;
    }

    void FixedUpdate()
    {
        if (!isLive)
            return ;

        Vector2 dir = target.position - rb.position;
        dir.Normalize();
        
        Vector2 nextVec = dir * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
            return ;

        sr.flipX = target.position.x < rb.position.x;
    }

    // 활성화 될 때 자동으로 실행, target을 찾는다.
    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
