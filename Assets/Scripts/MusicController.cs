using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameManager gameManager;

    // Enum for state
    public enum MusicState {
        MAIN_MENU,
        FIGHT,
        START,
        PHASE_1,
        PHASE_2,
        PHASE_3
    }

    // Start is called before the first frame update
    private Dictionary<string, AudioClip> soundsDict = new Dictionary<string, AudioClip>(); //soundsPool
    private MusicState state;

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
        state = MusicState.START;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        string clipName = "";

        if (state != MusicState.FIGHT) {
            if (gameManager.config[GameManager.PHASE_STATE] == GameManager.PhaseState.PHASE_1) {
                state = MusicState.PHASE_1;
            } else if (gameManager.config[GameManager.PHASE_STATE] == GameManager.PhaseState.PHASE_2) {
                state = MusicState.PHASE_2;
            } else if (gameManager.config[GameManager.PHASE_STATE] == GameManager.PhaseState.PHASE_3) {
                state = MusicState.PHASE_3;
            } else {
                state = MusicState.START;
            }
        }

        Debug.Log(state);

        switch (state) {
            case MusicState.START:
                clipName = "Start";
                break;
            case MusicState.FIGHT:
                clipName = "Fight";
                break;
            case MusicState.PHASE_1:
                clipName = "musicloop1";
                break;
            case MusicState.PHASE_2:
                clipName = "musicloop2";
                break;
            case MusicState.PHASE_3:
                clipName = "musicloop3";
                break;
            default:
                clipName = "MainMenu";
                break;
        }

        PlayBGM(clipName);
    }

    public void PlayBGM(string name)
    {
        if (bgmAudio.clip == GetClipByName(name)) {
            return;
        }

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
