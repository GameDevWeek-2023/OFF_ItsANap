using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer GameAudioMixer;
    [SerializeField] AudioSource lightBackgroundMusic;
    [SerializeField] AudioSource darkBackgroundMusic;
    [SerializeField] float defaultVolume = 1;
    [SerializeField] float transitionTime = 2f;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        AudioSource nowPlaying = lightBackgroundMusic;
        AudioSource target = darkBackgroundMusic;
        if (nowPlaying.isPlaying == false)
        {
            nowPlaying = darkBackgroundMusic;
            target = lightBackgroundMusic;
        }
        StartCoroutine(MixSources(nowPlaying, target));

    }

    IEnumerator MixSources(AudioSource nowPlaying, AudioSource target)
    {
        float percentage = 0;
        while (nowPlaying.volume > 0)
        {
            nowPlaying.volume = Mathf.Lerp(defaultVolume, 0, percentage);
            percentage += Time.deltaTime / transitionTime;
            yield return null;
        }
        nowPlaying.Pause();
        if (target.isPlaying == false) target.Play();
        target.UnPause();
        percentage = 0;
        while (target.volume < defaultVolume)
        {
            target.volume = Mathf.Lerp(0, defaultVolume, percentage);
            percentage += Time.deltaTime / transitionTime;
            yield return null;
        }

    }

}
