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
        if (PlayerControl.Instance.Die)
        {
            msPlayer.Stop();
        }
        
        
    }
    
    
   
    

}
