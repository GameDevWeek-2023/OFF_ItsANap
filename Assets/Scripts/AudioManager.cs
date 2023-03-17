using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer GameAudioMixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEffectSoundVolume(float volume) {
        GameAudioMixer.SetFloat("EffectsVolume", volume);
    }


    // 2DO: Methode zur Anpassung der Musiklautstärke implementieren
    public void SetMusicVolume(float volume) {
        Debug.Log("Music Volume" + volume);
        GameAudioMixer.SetFloat("MusicVolume", volume);
    }

}
