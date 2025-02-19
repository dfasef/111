using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldVisual; // 护盾视觉效果（需在Inspector中拖入）
    public float shieldDuration = 1f;//护盾持续时间
    public float cooltime = 2f;// 冷却时间
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
        // 激活护盾
        isShieldActive = true;
        anim.SetBool("Block", true);
        shieldVisual.SetActive(true);
        

        // 持续3秒
        yield return new WaitForSeconds(shieldDuration);
        
        // 关闭护盾
        isShieldActive = false;
        anim.SetBool("Block", false);
        shieldVisual.SetActive(false);

        // 进入冷却
        isOnCool = true;
        yield return new WaitForSeconds(cooltime);
        isOnCool = false;
    }

    // 提供给火球检测的公共方法
    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
