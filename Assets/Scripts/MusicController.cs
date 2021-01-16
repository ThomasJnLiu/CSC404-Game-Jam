using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update

    private Dictionary<string, AudioClip> soundsDict = new Dictionary<string, AudioClip>(); //soundsPool

    private float bgmVolume = 1;

    private bool muteBGM = false;

    private AudioSource bgmAudio = null;

    void Awake()
    {
        //base.Awake();
        for (int i = 0; i < 5; i++)
        {
            GameObject newObj = new GameObject("Audio");
            newObj.transform.SetParent(transform);
        }
        bgmAudio = gameObject.AddComponent<AudioSource>();
    }

    void Start()
    {
        PlayBGM("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            PlayBGM("Fight");
        }

        if (Input.GetKey("s"))
        {
            PlayBGM("Start");
        }

        if (Input.GetKey("m"))
        {
            PlayBGM("MainMenu");
        }
    }

    public void PlayBGM(string name)
    {
        Debug.Log(name + " played");

        bgmAudio.loop = true;
        bgmAudio.clip = GetClipByName(name);
        bgmAudio.volume = bgmVolume;
        bgmAudio.mute = muteBGM;
        bgmAudio.Play(0);
    }

    private AudioClip GetClipByName(string name)
    {
        if (!soundsDict.ContainsKey(name))
        {
            AudioClip clip = Resources.Load<AudioClip>("Sounds/" + name);
            soundsDict.Add(name, clip);
        }
        return soundsDict[name];
    }
}
