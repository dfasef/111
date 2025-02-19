using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum SceneName
{
    Scene1,
    Scene2,
    Scene3,
    Scene4
}
public class KeyToNext : MonoBehaviour
{
    public static KeyToNext Instance;
    public SceneName currentScene = SceneName.Scene1;

    
    private void Awake()
    {
        // 如果实例已经存在，则销毁当前对象，保证只有一个实例
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // 保存唯一的实例
            Instance = this;
            // 确保在场景切换时不会被销毁
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    private void Update()
    {
        switch (currentScene)
        {
            case SceneName.Scene1:
                Scene1update();
                break;
            case SceneName.Scene2:
                Scene2update();
                break;
            case SceneName.Scene3:
                Scene3update();
                break;
            case SceneName.Scene4:
                Scene4update();
                break;
            
        }
       

    }
    
   
    void Scene1update()
    {
        Ground1Control.Instance.DataUpdate(-200f,351.9f);
       
    }
   
    void Scene2update()
    {
        Ground1Control.Instance.DataUpdate(-340f, 557.93f);
        PlayerControl.Instance.can2jump = true;
        bluefire.Instance.canFire = true;
        

    }

    void Scene3update()
    {

    }
    void Scene4update()
    { 
    }
}
