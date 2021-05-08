using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager soundManager;

    public AudioClip buttonHitSound;
    public AudioClip buttonHitSoundError;
    public AudioClip buttonHoverSound;
    public AudioClip buttonSuccessSound;
    public AudioSource audioSource;

    private void Awake()
    {
        if (soundManager != null && soundManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonHitSound = Resources.Load<AudioClip>("buttonHitSound");
        buttonHitSoundError = Resources.Load<AudioClip>("buttonHitSoundError");

        audioSource = GetComponent<AudioSource>();

        MainMenu.buttonClickedEvent += ButtonHitSoundPlay;
        MainMenu.buttonClickedSuccessEvent += ButtonSuccessSoundPlay;
        MainMenu.buttonClickedErrorEvent += ButtonHitSoundErrorPlay;
        SongSelection.buttonClickAction += ButtonHitSoundPlay;
        Settings.buttonClickedEvent += ButtonHitSoundPlay;
    }

    public void ButtonHitSoundPlay()
    {
        audioSource.PlayOneShot(buttonHitSound);
    }

    public void ButtonHitSoundErrorPlay()
    {
        audioSource.PlayOneShot(buttonHitSoundError);
    }
    public void ButtonHoverSoundPlay()
    {
        audioSource.PlayOneShot(buttonHoverSound);
    }
    public void ButtonSuccessSoundPlay()
    {
        audioSource.PlayOneShot(buttonSuccessSound);
    }
}
