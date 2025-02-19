using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{

    void Update()
    {
        //如果火球位置在屏幕外，则销毁
        if (transform.position.x > 20)
        {
            DestroyFire();
        }
    }
    void DestroyFire()
    {
        var poolManager = GameObject.FindObjectOfType<pool>(); // 假设pool是单例或全局可访问的
        if (poolManager != null)
        {
            poolManager.Push(gameObject);
            gameObject.SetActive(false); // 确保游戏对象被设置为非激活状态
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查碰撞对象是否是玩家
        if (other.gameObject.CompareTag("Player"))
        {

            Shield Shield = other.GetComponent<Shield>();

            // 如果玩家有护盾
            if (Shield != null && Shield.IsShieldActive())
            {
                DestroyFire();
            }
            else
            {
                // 这里可以调用任何需要执行的逻辑，比如减少玩家的生命值等
                PlayerControl.Instance.Died();
                // 如果使用了对象池，则将火球返回池中
                DestroyFire();
            }
            
        }
        
    }
}
