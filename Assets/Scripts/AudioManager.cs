using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxAudioSource;
    public GameObject sfxSwitchOn;
    public GameObject sfxSwitchOff;

    private void Start(){
        PlayBGM();
    }

    public void PlayBGM(){
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPosition){
        GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
    }
    public void PlayON(Vector3 spawnPosition){
        GameObject.Instantiate(sfxSwitchOn, spawnPosition, Quaternion.identity);
    }
    public void PlayOFF(Vector3 spawnPosition){
        GameObject.Instantiate(sfxSwitchOff, spawnPosition, Quaternion.identity);
    }
}
