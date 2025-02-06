using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public    Rigidbody2D rb;
    
    bool fly = false;
    private Vector2 targetPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ����Ϸ�����ϻ�ȡRigidbody2D������Ա����������Ϊ��
        
    }

    void FixedUpdate()
    {
        if (fly)
        {
            targetPosition = new Vector2(transform.position.x, -9.2f);
        }
        else
        {
            targetPosition = new Vector2(transform.position.x, -12.25f);
        }

        rb.MovePosition(Vector2.Lerp(rb.position, targetPosition, Time.fixedDeltaTime*5));
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("EnemyObs"))
        {
            fly = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyObs"))
        {
            fly = false;
        }
    }

}
