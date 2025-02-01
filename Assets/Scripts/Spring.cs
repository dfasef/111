using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spring : MonoBehaviour
{

    public Ground1Control ground1Control;
    public Vector2 bounceForce = new Vector2(300f, 150f); // ������Щֵ����Ӧ�����Ϸ����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // ʹ�� AddForce ��������ָ�����ķ���ʹ�С
                playerRigidbody.AddForce(bounceForce, ForceMode2D.Impulse);
                ground1Control.BoostSpeed();
            }
        }
    }

    // �����Ҫ��̬������Ծ���ȣ������ṩ���������ķ���
    public void SetBounceForce(Vector2 force)
    {
        bounceForce = force;
    }
}
