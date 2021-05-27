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
    public AudioSource audioSourceLevelup;
    public AudioSource audioSourceExp;
    public AudioClip LevelUpSound;
    public AudioClip LevellingUpSound;

    public AudioSource MainMenuMusic;

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
        audioSource.volume = 0.1f;

        buttonHitSound = Resources.Load<AudioClip>("buttonHitSound");
        buttonHitSoundError = Resources.Load<AudioClip>("buttonHitSoundError");

        audioSource = GetComponent<AudioSource>();
        audioSourceLevelup = GetComponent<AudioSource>();

        // Main Menu Sounds
        MainMenu.buttonClickedEvent += ButtonHitSoundPlay;
        MainMenu.buttonClickedSuccessEvent += ButtonSuccessSoundPlay;
        MainMenu.buttonClickedErrorEvent += ButtonHitSoundErrorPlay;
        SongSelection.buttonClickAction += ButtonHitSoundPlay;
        Settings.buttonClickedEvent += ButtonHitSoundPlay;

        // Play Scene Sounds
        PlayUILogic.buttonClickedEvent += ButtonHitSoundPlay;
        SongFinished.buttonClickedEvent += ButtonHitSoundPlay;

        

        SongFinished.LevelUpEvent += LevelUpSoundPlay;
        
    }

    private void Update()
    {
        // Level Up Sound
        if (PersistentData.data.isLevellingUp)
        {
            SongFinished.LevellingUpEvent += LevellingUpSoundStart;
        }
        else
        {
            SongFinished.LevellingUpEvent -= LevellingUpSoundStart;
            audioSourceExp.Stop();
            audioSourceExp.loop = false;
        }
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

    public void LevelUpSoundPlay()
    {
        audioSource.volume = 80f;
        audioSourceLevelup.PlayOneShot(LevelUpSound);
    }

    public void LevellingUpSoundStart()
    {
        audioSourceExp.loop = true;
        audioSourceExp.volume = 0.1f;
        audioSourceExp.clip = LevellingUpSound;
        if (audioSourceExp.isPlaying == false)
        {
            audioSourceExp.Play();
        }
        
    }
}
