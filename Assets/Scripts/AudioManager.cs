using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    //单例
    public static AudioManager Instance;
    //播放组件
    private AudioSource player;

    public AudioSource msPlayer;


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
    void Start()
    {
        //单例
        Instance=this;
        //获取播放组件
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            player = audioSources[0];
            msPlayer = audioSources[1];
        }
        
    }
    
    //播放音效
    public void Play(string name)
    {
        //通过名字获取音效资源
        AudioClip clip = Resources.Load<AudioClip>(name);
        //播放
        player.PlayOneShot(clip);
        
    }
    void Update()
    {
        
    }
    
    public void PlayAgain()
    {
        msPlayer.time = 0; // 将播放位置重置到开头
        msPlayer.Play();
    }
   
    

}
