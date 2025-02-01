using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public Vector2 JumpForce = new Vector2(20f, 10f);
    //刚体组件
    public Rigidbody2D rb;
    //动画组件
   public Animator anim;

    private bool IsGround;
    public  bool Die = false;
    public Ground1Control ground1Control; // 添加对背景移动器的引用
    //设为单例模式
    public static PlayerControl Instance;
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        //获取刚体组件
        rb = GetComponent<Rigidbody2D>();
        //获取动画组件
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsJump", false);
        //如果按了空格键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //跳跃
            Jump();
        }
        
    }
    

    //跳跃
    public void Jump()
    {
        Debug.Log("Jump");
        //如果在地面上，允许跳跃
        if (IsGround == true)
        {
            if (Die)
            {
                return;
            }
            //给刚体一个向上的力
            
            rb.AddForce(JumpForce, ForceMode2D.Impulse);

            
            //播放跳跃音效

            //播放跳跃动画
            anim.SetBool("IsJump", true);
            anim.Update(0f);
        }

    }


    //发生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断如果是沟和怪
        if (collision.collider.tag == "Die")
        {
            Die = true;
            //播放一次死亡动画
            anim.SetBool("IsDie", true);
            //播放死亡音效
            AudioManager.Instance.Play("Boss死了");
        }
        //如果是地面
        if (collision.collider.tag == "Ground")
        {
            IsGround = true;
            anim.SetBool("IsJump", false);
            
                // 玩家着地，重置背景速度
                if (ground1Control != null)
                {
                   ground1Control.ResetSpeed();
                }
            
        }

    }
    //离开碰撞
    private void OnCollisionExit2D(Collision2D collision)
    {
        //如果离开地面
        if (collision.collider.tag == "Ground")
        {
            IsGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Circle"))
        {
           
            AudioManager.Instance.Play("圈");
        }
        else if (collision.CompareTag ("star"))
        {
            
            AudioManager.Instance.Play("星");
        }

        else if(collision.CompareTag("Gold"))
        {
            
            AudioManager.Instance.Play("金币");
        }
    }
    
    
}