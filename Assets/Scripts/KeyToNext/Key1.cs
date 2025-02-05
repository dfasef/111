using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Key2")
        {
            
                Debug.Log(" 碰撞成功");
                // 将当前游戏对象设置为碰撞对象的子对象
                transform.SetParent(collision.transform);
            
        }
    }
}
