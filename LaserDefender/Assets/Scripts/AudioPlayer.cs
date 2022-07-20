using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] List<AudioClip> shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    [SerializeField] List<AudioClip> slashingClip;
    [SerializeField][Range(0f, 1f)] float slashingVolume = 1f;
    [SerializeField] AudioClip hitMeow;
    [SerializeField] [Range(0f, 1f)] float hitMeowVolume = .5f;

    [Header("Enemy")]

    [SerializeField] AudioClip thunder;
    [SerializeField][Range(0f, 1f)] float thunderVolume = 1f;

    [SerializeField] AudioClip sprayBottle;
    [SerializeField][Range(0f, 1f)] float sprayBottleVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damage;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    [Header("Music")]
    [SerializeField] AudioSource mainBG;
    [SerializeField] AudioSource finalBossBG;

    bool OneTime = false;

    AudioSource vacuumAudio;

    static AudioPlayer instance;

    void Awake() 
    {
        ManageSingleton();
        vacuumAudio = GetComponent<AudioSource>();
    }

    void Update() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene == SceneManager.GetSceneByName("FinalBoss") && !OneTime)
        {
            FadeoutMainBG();
            OneTime = true;
        }

        if (currentScene == SceneManager.GetSceneByName("GameOver") ||
            currentScene == SceneManager.GetSceneByName("YouWon")) 
            
        {
            Destroy(instance);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void ManageSingleton() 
    { 
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StopAllAudio() 
    {
        Destroy(gameObject);
    }

    public void PlayShootingClipPlayer() 
    {
        
        if(shootingClip != null) 
        {
           PlayRandomClipinList(shootingClip, shootingVolume);
        }
    }

    public void PlayTakeDamage() {
        
        PlayClip(hitMeow, hitMeowVolume);
    }

    public void PlayShootingExplodeClipPlayer() 
    {
        if (slashingClip != null)
        {
            PlayRandomClipinList(slashingClip, slashingVolume);
        }
    }

    public void PlayShootingClipEnemy(string enemy) 
    {
        if (vacuumAudio != null && enemy == "vacuum") 
        {
            vacuumAudio.Play();
        }

        if (thunder != null && enemy == "thunder")
        {
            PlayClip(thunder, thunderVolume);
        }

        if (sprayBottle != null && enemy == "sprayBottle")
        {
            PlayClip(sprayBottle, sprayBottleVolume);
        }
    }

    public void PlayDamageClip() 
    {
        if (damage != null)
        {
            PlayClip(damage, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float speed) 
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, speed);
    }

    void PlayRandomClipinList(List<AudioClip> clips, float clipVolume)
    {
        System.Random random = new System.Random();
        int randomNum = random.Next(0, clips.Count);
        PlayClip(clips[randomNum], clipVolume);

    }

    public void StopVacuumAudio() 
    {
        vacuumAudio.Stop();
    }

    public void FadeoutMainBG()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        
        for(float i = mainBG.volume; i > 0; i -= .01f)
        {
            mainBG.volume = i;
            yield return new WaitForSeconds(.1f);
        }

        yield return new WaitForSeconds(1f);

        finalBossBG.Play();
        for (float i = finalBossBG.volume; i < 0.1f; i += .01f)
        {
            finalBossBG.volume = i;
            yield return new WaitForSeconds(.1f);
        }
    }

    
}
