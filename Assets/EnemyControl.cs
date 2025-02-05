using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public    Rigidbody2D rb;
    public float jumpSpeed = 200f;
    public Ground1Control ground1Control;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("EnemyObs"))
        {
           
            Jump();
        }
        if (collision.collider.tag == "Ground")
        {
            //IsGround = true;
            //anim.SetBool("IsJump", false);

            // 玩家着地，重置背景速度
            if (ground1Control != null)
            {
               
                ground1Control.ResetSpeed();
            }

        }

    }

    void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
    
        
        // Update is called once per frame
        void Update()
    {
        
    }
}
