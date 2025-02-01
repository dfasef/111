using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public Vector2 JumpForce = new Vector2(20f, 10f);
    //�������
    public Rigidbody2D rb;
    //�������
   public Animator anim;

    private bool IsGround;
    public  bool Die = false;
    public Ground1Control ground1Control; // ��ӶԱ����ƶ���������
    //��Ϊ����ģʽ
    public static PlayerControl Instance;
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
    

    //��Ծ
    public void Jump()
    {
        Debug.Log("Jump");
        //����ڵ����ϣ�������Ծ
        if (IsGround == true)
        {
            if (Die)
            {
                return;
            }
            //������һ�����ϵ���
            
            rb.AddForce(JumpForce, ForceMode2D.Impulse);

            
            //������Ծ��Ч

            //������Ծ����
            anim.SetBool("IsJump", true);
            anim.Update(0f);
        }

    }


    //������ײ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ж�����ǹ��͹�
        if (collision.collider.tag == "Die")
        {
            Die = true;
            //����һ����������
            anim.SetBool("IsDie", true);
            //����������Ч
            AudioManager.Instance.Play("Boss����");
        }
        //����ǵ���
        if (collision.collider.tag == "Ground")
        {
            IsGround = true;
            anim.SetBool("IsJump", false);
            
                // ����ŵأ����ñ����ٶ�
                if (ground1Control != null)
                {
                   ground1Control.ResetSpeed();
                }
            
        }

    }
    //�뿪��ײ
    private void OnCollisionExit2D(Collision2D collision)
    {
        //����뿪����
        if (collision.collider.tag == "Ground")
        {
            IsGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Circle"))
        {
           
            AudioManager.Instance.Play("Ȧ");
        }
        else if (collision.CompareTag ("star"))
        {
            
            AudioManager.Instance.Play("��");
        }

        else if(collision.CompareTag("Gold"))
        {
            
            AudioManager.Instance.Play("���");
        }
    }
    
    
}