using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldVisual; // �����Ӿ�Ч��������Inspector�����룩
    public float shieldDuration = 1f;//���ܳ���ʱ��
    public float cooltime = 2f;// ��ȴʱ��
    private bool isShieldActive = false;
    private bool isOnCool = false;
    public  bool Block =false;

    public Animator anim;

    public static Shield Instance;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Instance = this;
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isShieldActive && !isOnCool&& Block)
        {
            StartCoroutine(ActivateShield());
        }
    }

    System.Collections.IEnumerator ActivateShield()
    {
        // �����
        isShieldActive = true;
        anim.SetBool("Block", true);
        shieldVisual.SetActive(true);
        

        // ����3��
        yield return new WaitForSeconds(shieldDuration);
        
        // �رջ���
        isShieldActive = false;
        anim.SetBool("Block", false);
        shieldVisual.SetActive(false);

        // ������ȴ
        isOnCool = true;
        yield return new WaitForSeconds(cooltime);
        isOnCool = false;
    }

    // �ṩ��������Ĺ�������
    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
