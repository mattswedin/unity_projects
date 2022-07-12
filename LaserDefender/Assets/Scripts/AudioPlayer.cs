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

    AudioSource vacuumAudio;

    static AudioPlayer instance;

    void Awake() 
    {
        ManageSingleton();
        vacuumAudio = GetComponent<AudioSource>();
    }

    void Update() 
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentScene);
        if (currentScene == 2)
        {
            Debug.Log("why then");
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
}
