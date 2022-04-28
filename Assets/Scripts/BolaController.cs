using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaController : MonoBehaviour
{
    public float velocity = 10;
    
    public Rigidbody2D _Rigidbody2D;

    private PlayerController _playerController;

    private int cont = 0;
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Rigidbody2D.velocity =new Vector2(velocity, _Rigidbody2D.velocity.y);
        Destroy(this.gameObject, 5);
    }
    public void SetController(PlayerController playerController)
    {
        _playerController = playerController;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        var tag = col.gameObject.tag;
        
        cont = cont +1;
        Debug.Log(cont);
        
        if (tag=="enemy")
        { 
            Destroy(this.gameObject);
            Destroy(col.gameObject);

        }
    }
}
