using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound: MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        SetVolume(0);
    }

    public void Play()
    {
        SetVolume(GlobalVariables.music_level);
        _audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }

}
