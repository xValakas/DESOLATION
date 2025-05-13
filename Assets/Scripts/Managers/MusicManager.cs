using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] UnityEngine.Audio.AudioMixer mixer;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip buttons;
    public AudioClip bestialRoar;
    public AudioClip gunfire;

    [Header("Settings Menu")]
    public UnityEngine.UI.Slider volumeSlider;

    public static MusicManager instance;
    public string MasterVolume;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        float savedVol = PlayerPrefs.GetFloat(MasterVolume, volumeSlider.maxValue);
        SetVolume(savedVol); 
        volumeSlider.value = savedVol;
        volumeSlider.onValueChanged.AddListener((float _) => SetVolume(_));
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void SetVolume(float _value)
    {
        mixer.SetFloat(MasterVolume, ConvertToDecibel(_value / volumeSlider.maxValue));
        PlayerPrefs.SetFloat(MasterVolume, _value);
    }


    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }

        public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
