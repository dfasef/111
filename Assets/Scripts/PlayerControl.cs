using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static KeyToNext;

public class PlayerControl : MonoBehaviour
{
    //public Vector2 JumpForce = new Vector2(20f, 10f);
    
    //刚体组件
    public Rigidbody2D rb;
    //动画组件
    public Animator anim;
    public int MaxJumps = 2;//最大跳跃次数
    private int remainingJumps; // 剩余跳跃次数
    public  bool  can2jump=false;

    private bool IsGround;
    public  bool Die = false;
    public Ground1Control ground1Control; // 添加对背景移动器的引用
    //设为单例模式
    public static PlayerControl Instance;
    public float jumpSpeed=200f;
    
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
        remainingJumps = MaxJumps; // 初始化跳跃次数
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

    public void Died()
    {
        Die = true;
        
        //播放一次死亡动画
        anim.SetTrigger("Die");
        //播放死亡音效
        AudioManager.Instance.Play("Boss死了");
        
        
    }
    //跳跃
    public void Jump()
    {
        
        //如果在地面上，允许1次跳跃
        if (IsGround == true&&can2jump==false)
        {
            if (Die)
            {
                return;
            }
            //给刚体一个向上的力
            //rb.AddForce(JumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //播放跳跃音效

            //播放跳跃动画
            anim.SetBool("IsJump", true);
            anim.Update(0f);
        }
        else if (can2jump == true&& remainingJumps>0)
        {
            if (Die)
            {
                return;
            }
            if (remainingJumps == 2)
            {
                //给刚体一个向上的力
                //rb.AddForce(JumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

            }

            if (remainingJumps == 1)
            {
                ground1Control.BoostSpeed();
                //rb.AddForce(JumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            
            //播放跳跃音效

            //播放跳跃动画
            anim.SetBool("IsJump", true);
            anim.Update(0f);
            remainingJumps--;
          
            if (remainingJumps == 0)
            {
                anim.SetBool("IsJump", false);
            }
        }

    }

    
    //发生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断如果是沟和怪
        if (collision.collider.tag == "Die" || collision.collider.tag == "Enemy")
        {
            
            Died();
            
        }
        //如果是地面
        if (collision.collider.tag == "Ground")
        {
            IsGround = true;
            anim.SetBool("IsJump", false);

            // 玩家着地，重置背景速度
            if (ground1Control != null)
            {
                remainingJumps = MaxJumps;
                ground1Control.ResetSpeed();
            }

         }
        else if (collision.collider.CompareTag("Sping"))
        {
            IsGround = true;
            remainingJumps = MaxJumps;
        }

    }
    //离开碰撞
    private void OnCollisionExit2D(Collision2D collision)
    {
        //如果离开地面
        if (collision.collider.tag == "Ground"||collision.collider.tag=="Sping")
        {
            IsGround = false;
        }
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Key2"))
        {
            SwitchScene("Scene2"); // "NextSceneName" 替换为你想切换到的实际场景名称
            KeyToNext.Instance.currentScene = SceneName.Scene2;
        }
        else if (other.gameObject.CompareTag("Key3"))
        {
            SwitchScene("Scene3");
            KeyToNext.Instance.currentScene = SceneName.Scene3;
        }

    }
   
    

}