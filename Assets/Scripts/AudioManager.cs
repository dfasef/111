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


    private void Awake()
    {
        // ���ʵ���Ѿ����ڣ������ٵ�ǰ���󣬱�ֻ֤��һ��ʵ��
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // ����Ψһ��ʵ��
            Instance = this;
            // ȷ���ڳ����л�ʱ���ᱻ����
            DontDestroyOnLoad(this.gameObject);
        }
    }
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
        
    }
    
    public void PlayAgain()
    {
        msPlayer.time = 0; // ������λ�����õ���ͷ
        msPlayer.Play();
    }
   
    

}
