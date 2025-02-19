using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluefire : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public Transform EnemyTransform;//敌人位置
    public Animator anim;
    public float Interval = 4f; // 火球间隔时间
    public List<GameObject> list = new List<GameObject>(); // 火球列表
    public static bluefire Instance;
    public bool canFire = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 在游戏对象上获取Rigidbody2D组件，以便控制物理行为。
        anim = GetComponent<Animator>();
    }

    // 发射火球的方法
    void ShootFireball()
    {
        
            // 确定火球生成的位置（例如，在敌人的前方）
            Vector2 fireballPosition = EnemyTransform.position;

            // 实例化火球预制体
            GameObject fireballInstance = GetComponent<pool>().Pop();
            list.Add(fireballInstance);
            fireballInstance.transform.position = fireballPosition;
            fireballInstance.SetActive(true);

            // 计算火球的方向(水平向右)
            Vector2 direction = Vector2.right;

            // 获取火球的刚体组件并应用速度
            Rigidbody2D fireballRb = fireballInstance.GetComponent<Rigidbody2D>();

            fireballRb.velocity = direction * 6f; // 调整速度值以适应你的需求
        
        
    }
    // 示例：每隔一段时间自动发射一次火球
    IEnumerator FireballRoutine()
    {
        
        while (canFire)
        {
            
            ShootFireball();
            yield return new WaitForSeconds(Interval);
        }
    }


    void OnEnable()
    {
        StartCoroutine(FireballRoutine());
    }


}