using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] List<AudioClip> shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Enemy")]

    [SerializeField] AudioClip thunder;
    [SerializeField][Range(0f, 1f)] float thunderVolume = 1f;

    [SerializeField] AudioClip sprayBottle;
    [SerializeField][Range(0f, 1f)] float sprayBottleVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damage;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    AudioSource vacuumAudio;

    void Awake() 
    {
        vacuumAudio = GetComponent<AudioSource>();
    }

    public void PlayShootingClipPlayer() 
    {
        System.Random random = new System.Random();
        int randomNum = random.Next(0, shootingClip.Count);
        if(shootingClip != null) 
        {

            AudioSource.PlayClipAtPoint(shootingClip[randomNum], 
                                        Camera.main.transform.position, 
                                        shootingVolume);
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
            AudioSource.PlayClipAtPoint(thunder,
                                        Camera.main.transform.position,
                                        thunderVolume);
        }

        if (sprayBottle != null && enemy == "sprayBottle")
        {
            AudioSource.PlayClipAtPoint(sprayBottle,
                                        Camera.main.transform.position,
                                        sprayBottleVolume);
        }
    }

    public void PlayDamageClip() 
    {
        if (damage != null)
        {
            AudioSource.PlayClipAtPoint(damage,
                                        Camera.main.transform.position,
                                        damageVolume);
        }
    }

    public void StopAudio() 
    {
        vacuumAudio.Stop();
    }
}
