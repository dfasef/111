using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    void Update()
    {
        //�������λ������Ļ�⣬������
        if (transform.position.x > 20)
        {
            DestroyFire();
        }
    }
    void DestroyFire()
    {
        var poolManager = GameObject.FindObjectOfType<pool>(); // ����pool�ǵ�����ȫ�ֿɷ��ʵ�
        if (poolManager != null)
        {
            poolManager.Push(gameObject);
            gameObject.SetActive(false); // ȷ����Ϸ��������Ϊ�Ǽ���״̬
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����ײ�����Ƿ������
        if (other.gameObject.CompareTag("Player"))
        {

            Shield Shield = other.GetComponent<Shield>();

            // �������л���
            if (Shield != null && Shield.IsShieldActive())
            {
                DestroyFire();
            }
            else
            {
                // ������Ե����κ���Ҫִ�е��߼������������ҵ�����ֵ��
                PlayerControl.Instance.Died();
                // ���ʹ���˶���أ��򽫻��򷵻س���
                DestroyFire();
            }
            
        }
        
    }
}
