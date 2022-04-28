using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 5;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private int cont = 0;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(-velocity, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = true;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var tag = col.gameObject.tag;

        if (tag=="bull")
        {
            cont +=1;
            Debug.Log(cont);
        }
        
    }
}
