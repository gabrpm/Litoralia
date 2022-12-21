using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaSom : Singleton<SistemaSom>
{
    [SerializeField] List<AudioClip> songList = new List<AudioClip>();
    [SerializeField] int musicaAtual = 0;
    [SerializeField] AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (instancia == this)
        {
           DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

        m_AudioSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
    }

    public void MudarMusica(int i)
    {
        musicaAtual = musicaAtual + i;
        if(musicaAtual < 0)
        {
            musicaAtual = songList.Count-1;
        } else if (musicaAtual >= songList.Count){
            musicaAtual = 0;
        }

        m_AudioSource.clip = songList[musicaAtual];
        m_AudioSource.Play();
    }

    public float VolumeAtual()
    {
        return m_AudioSource.volume;
    }

    public void AlterarVolume(float v)
    {
        GetComponent<AudioSource>().volume = v;
    }

    public string MusicaAtual()
    {
        return songList[musicaAtual].name;
    }

}
