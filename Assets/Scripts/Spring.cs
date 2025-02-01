using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spring : MonoBehaviour
{

    public Ground1Control ground1Control;
    public Vector2 bounceForce = new Vector2(300f, 150f); // 调整这些值以适应你的游戏需求

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                // 使用 AddForce 方法，并指定力的方向和大小
                playerRigidbody.AddForce(bounceForce, ForceMode2D.Impulse);
                ground1Control.BoostSpeed();
            }
        }
    }

    // 如果需要动态调整跳跃力度，可以提供类似这样的方法
    public void SetBounceForce(Vector2 force)
    {
        bounceForce = force;
    }
}
