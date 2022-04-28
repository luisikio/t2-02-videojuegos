using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _renderer;
    private Animator _animator;
   
    
    public float JumpForce = 10;
    public float velocity = 10;
    
    
    public GameObject bulletPrefabs;
    public GameObject bulletPrefabs2;
    public GameObject bulletPrefabs3;
    
    private static readonly int right = 1;
    private static readonly int left = -1;
    
    private static readonly int Animation_Ilde = 0;
    private static readonly int Animation_run = 1;
    private static readonly int Animation_run2 = 2;
    private static readonly int Animation_jump = 3;


    private float time = 0f;
    private float top = 3f;
    private float top2 = 5f;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        ChangeAnimation(Animation_Ilde);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(right);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(left);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
            ChangeAnimation(Animation_jump);
        }
        
        if (Input.GetKeyUp(KeyCode.X))
        {
            ChangeAnimation(Animation_run2);
            Disparar();
        }
        

        timekey();
    }

    void timekey()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            time = Time.time;
        }
         
        if(Input.GetKeyUp(KeyCode.X))
        {
            time = Time.time - time;
            Debug.Log("Pressed for : " + time + " Seconds");
            if (time>=top )
            {
                Debug.Log("Pressed for : " + time + " Seconds");
                Disparar2();
            }
            if (time>=top2 )
            {
                Debug.Log("Pressed for : " + time + " Seconds");
                Disparar3();
            }
            
        }
    }
    
    private void Desplazarse(int position)
    {
        _rigidbody2D.velocity = new Vector2(velocity * position, _rigidbody2D.velocity.y);
        _renderer.flipX = position == left;
        ChangeAnimation(Animation_run);
    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger("Estado", animation);
    }

    private void Disparar()
    {
        //crear elementos en tiempo de ejecuccion
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bullgo=Instantiate(bulletPrefabs,new Vector2(x,y),Quaternion.identity) as GameObject;
        var controller = bullgo.GetComponent<BolaController>();
        
        controller.SetController(this);
        
        if (_renderer.flipX)
        {
            
            controller.velocity = controller.velocity * -1;
        }
        
    }
    private void Disparar2()
    {
        //crear elementos en tiempo de ejecuccion
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bullgo=Instantiate(bulletPrefabs2,new Vector2(x,y),Quaternion.identity) as GameObject;
        var controller = bullgo.GetComponent<BolaController>();
        
        controller.SetController(this);
        
        if (_renderer.flipX)
        {
            
            controller.velocity = controller.velocity * -1;
        }
        
    }
    private void Disparar3()
    {
        //crear elementos en tiempo de ejecuccion
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var bullgo=Instantiate(bulletPrefabs3,new Vector2(x,y),Quaternion.identity) as GameObject;
        var controller = bullgo.GetComponent<BolaController>();
        
        controller.SetController(this);
        
        if (_renderer.flipX)
        {
            
            controller.velocity = controller.velocity * -1;
        }
        
    }
    

  
}
