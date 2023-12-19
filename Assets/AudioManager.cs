using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource bgmPrefab;
    [SerializeField] private AudioClip[] bgmClips;
    private AudioSource bgm;

    [SerializeField] private AudioSource sfxPrefab;
    private AudioSource sfx;

    private void Awake()
    {
        // singleton behaviour
        if(instance != null)
        {
            print("destroying dupes of singleton");
            //DestroySingleton();
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);


        // setup bgm 
        bgm = Instantiate(bgmPrefab);
        DontDestroyOnLoad(bgm);

        // setup sfx 
        sfx = Instantiate(sfxPrefab);
        DontDestroyOnLoad(sfx);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            print("hoy " + instance);
            instance = null;
            if (bgm != null)
            {
                Destroy(bgm.gameObject);
            }
            if (sfx != null)
            {
                Destroy(sfx.gameObject);
            }
        }
    }


    public void PlayBGM(int index)
    {
        if(bgm.clip == bgmClips[index]) { return; }

        bgm.clip = bgmClips[index];
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

}
