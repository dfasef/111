using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Key2")
        {
            
                Debug.Log(" ��ײ�ɹ�");
                // ����ǰ��Ϸ��������Ϊ��ײ������Ӷ���
                transform.SetParent(collision.transform);
            
        }
    }
}
