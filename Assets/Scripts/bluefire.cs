using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluefire : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public Transform EnemyTransform;//����λ��
    public Animator anim;
    public float Interval = 4f; // ������ʱ��
    public List<GameObject> list = new List<GameObject>(); // �����б�
    public static bluefire Instance;
    public bool canFire = false;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ����Ϸ�����ϻ�ȡRigidbody2D������Ա����������Ϊ��
        anim = GetComponent<Animator>();
    }

    // �������ķ���
    void ShootFireball()
    {
        
            // ȷ���������ɵ�λ�ã����磬�ڵ��˵�ǰ����
            Vector2 fireballPosition = EnemyTransform.position;

            // ʵ��������Ԥ����
            GameObject fireballInstance = GetComponent<pool>().Pop();
            list.Add(fireballInstance);
            fireballInstance.transform.position = fireballPosition;
            fireballInstance.SetActive(true);

            // �������ķ���(ˮƽ����)
            Vector2 direction = Vector2.right;

            // ��ȡ����ĸ��������Ӧ���ٶ�
            Rigidbody2D fireballRb = fireballInstance.GetComponent<Rigidbody2D>();

            fireballRb.velocity = direction * 6f; // �����ٶ�ֵ����Ӧ�������
        
        
    }
    // ʾ����ÿ��һ��ʱ���Զ�����һ�λ���
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