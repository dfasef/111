using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    //����
    public static AudioManager Instance;
    //�������
    private AudioSource player;

    public AudioSource msPlayer;



    void Start()
    {
        //����
        Instance=this;
        //��ȡ�������
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            player = audioSources[0];
            msPlayer = audioSources[1];
        }
        
    }
    
    //������Ч
    public void Play(string name)
    {
        //ͨ�����ֻ�ȡ��Ч��Դ
        AudioClip clip = Resources.Load<AudioClip>(name);
        //����
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
