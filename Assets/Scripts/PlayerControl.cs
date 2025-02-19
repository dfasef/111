using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static KeyToNext;

public class PlayerControl : MonoBehaviour
{
    //public Vector2 JumpForce = new Vector2(20f, 10f);
    
    //�������
    public Rigidbody2D rb;
    //�������
    public Animator anim;
    public int MaxJumps = 2;//�����Ծ����
    private int remainingJumps; // ʣ����Ծ����
    public  bool  can2jump=false;

    private bool IsGround;
    public  bool Die = false;
    public Ground1Control ground1Control; // ��ӶԱ����ƶ���������
    //��Ϊ����ģʽ
    public static PlayerControl Instance;
    public float jumpSpeed=200f;
    
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        //��ȡ�������
        rb = GetComponent<Rigidbody2D>();
        //��ȡ�������
        anim = GetComponent<Animator>();
        remainingJumps = MaxJumps; // ��ʼ����Ծ����
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsJump", false);
        //������˿ո��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //��Ծ
            Jump();
            
        }
        
    }

    public void Died()
    {
        Die = true;
        
        //����һ����������
        anim.SetTrigger("Die");
        //����������Ч
        AudioManager.Instance.Play("Boss����");
        
        
    }
    //��Ծ
    public void Jump()
    {
        
        //����ڵ����ϣ�����1����Ծ
        if (IsGround == true&&can2jump==false)
        {
            if (Die)
            {
                return;
            }
            //������һ�����ϵ���
            //rb.AddForce(JumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //������Ծ��Ч

            //������Ծ����
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
                //������һ�����ϵ���
                //rb.AddForce(JumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

            }

            if (remainingJumps == 1)
            {
                ground1Control.BoostSpeed();
                //rb.AddForce(JumpForce, ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            
            //������Ծ��Ч

            //������Ծ����
            anim.SetBool("IsJump", true);
            anim.Update(0f);
            remainingJumps--;
          
            if (remainingJumps == 0)
            {
                anim.SetBool("IsJump", false);
            }
        }

    }

    
    //������ײ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж�����ǹ��͹�
        if (collision.collider.tag == "Die" || collision.collider.tag == "Enemy")
        {
            
            Died();
            
        }
        //����ǵ���
        if (collision.collider.tag == "Ground")
        {
            IsGround = true;
            anim.SetBool("IsJump", false);

            // ����ŵأ����ñ����ٶ�
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
    //�뿪��ײ
    private void OnCollisionExit2D(Collision2D collision)
    {
        //����뿪����
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
            SwitchScene("Scene2"); // "NextSceneName" �滻Ϊ�����л�����ʵ�ʳ�������
            KeyToNext.Instance.currentScene = SceneName.Scene2;
        }
        else if (other.gameObject.CompareTag("Key3"))
        {
            SwitchScene("Scene3");
            KeyToNext.Instance.currentScene = SceneName.Scene3;
        }

    }
   
    

}