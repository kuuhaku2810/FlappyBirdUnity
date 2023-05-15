using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;

    public static SoundManager instance;
    private AudioSource audioSource;

    private void Start()
    {
        Load();
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void OnButtonPress()
    {
        muted = !muted;

        Save();
        UpdateButtonIcon();

        AudioListener.pause = muted;
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetString("muted") == "true";
    }

    private void Save()
    {
        PlayerPrefs.SetString("muted", muted ? "true" : "false");
    }
}
