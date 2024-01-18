using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Set Sounds")]
    [SerializeField]
    public Sound[] musicSounds;

    [SerializeField]
    public Sound[] sfxSounds;

    [Header("Settings")]
    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private float musicChangeFade;

    private bool isInFade;

    private bool isOutFade;

    private bool isNeedToPlayNextMusic;

    private float currentVolume;

    private Sound nextMusic;

    private Sound currentMusic;


    void Awake() {
        if(instance==null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        //"OverheatinNOvercooling" "SummerWalk" "WinterWalk"
        PlayMusicWithoutChange("SummerWalk");
    }

    void Update() {
        
        TryNextMusic();

        if(EnvironmentState.isGame) {
            if(EnvironmentState.lastState != EnvironmentState.getInstance()) {
                switch(EnvironmentState.getInstance()) {
                    case EnvStateEnum.TooHigh: {
                        if(EnvironmentState.lastState != EnvStateEnum.TooLow) {
                            setPlayNextMusic();
                            nextMusic = Array.Find(musicSounds, x => x.name == "OverheatingNOvercooling");
                        }
                        break;
                    }
                    case EnvStateEnum.TooLow : {
                        if(EnvironmentState.lastState != EnvStateEnum.TooHigh) {
                            setPlayNextMusic();
                            nextMusic = Array.Find(musicSounds, x => x.name == "OverheatingNOvercooling");
                        }
                        break;
                    }
                    case EnvStateEnum.High : {
                        if(EnvironmentState.lastState != EnvStateEnum.Normal) {
                            setPlayNextMusic();
                            nextMusic = Array.Find(musicSounds, x => x.name == "SummerWalk");
                        }
                        break;
                    }
                    case EnvStateEnum.Normal : {
                        if(EnvironmentState.lastState != EnvStateEnum.High) {
                            setPlayNextMusic();
                            nextMusic = Array.Find(musicSounds, x => x.name == "SummerWalk");
                        }
                        break;
                    }
                    case EnvStateEnum.Low : {
                        setPlayNextMusic();
                        nextMusic = Array.Find(musicSounds, x => x.name == "WinterWalk");
                        break;
                    }
                }
            }
        }



    }

    private void TryNextMusic() {
        if(isInFade) {
            currentVolume = Mathf.Clamp(currentVolume - Time.deltaTime*musicChangeFade, 0, currentMusic.volume);
            musicSource.volume = currentVolume;
            if(currentVolume == 0) {
                isInFade = false;
            }
        }
        if(!isInFade && isNeedToPlayNextMusic) {
            PlayNextMusic();
        }
        if (!isInFade && !isNeedToPlayNextMusic && isOutFade) {
            currentVolume = Mathf.Clamp(currentVolume + Time.deltaTime*musicChangeFade, 0, nextMusic.volume);
            musicSource.volume = currentVolume;
            if(currentVolume == nextMusic.volume) {
                isOutFade = false;
            }
        }
    }

    public void PlayMusicWithoutChange(string name) {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null) {
            Debug.Log("SoundNotFound");
        } else {
            musicSource.clip = s.clip;
            currentVolume = s.volume;
            musicSource.volume = s.volume;
            nextMusic = s;
            currentMusic = s;
            musicSource.Play();
        }

    }

    public void PlayMusic(string name) {
        setPlayNextMusic();
        nextMusic = Array.Find(musicSounds, x => x.name == name);
    }

    private void setPlayNextMusic() {
        isInFade = true;
        isNeedToPlayNextMusic = true;
        isOutFade = true;
    }

    private void PlayNextMusic() {
        musicSource.clip = nextMusic.clip;
        musicSource.volume = currentVolume;
        musicSource.Play();
        EnvironmentState.lastState = EnvironmentState.getInstance();
        isNeedToPlayNextMusic = false;
        currentMusic = nextMusic;
    }

    public void PlaySfx(string name) {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null) {
            Debug.Log("SoundNotFound");
        } else {
            sfxSource.PlayOneShot(s.clip, s.volume);
        }
    }

    public void PlaySfXForCompanion(string name, AudioSource companionSource) {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null) {
            Debug.Log("SoundNotFound");
        } else {
            companionSource.PlayOneShot(s.clip, s.volume);
        }
    }

}
