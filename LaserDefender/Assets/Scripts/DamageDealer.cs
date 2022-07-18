using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
  [SerializeField] int damage = 10;
  [SerializeField] bool isEnemy = false;
  [SerializeField] bool isClaws = false;
  [SerializeField] ParticleSystem scratchspolsion;
  AudioPlayer audioPlayer;


  void Awake() 
  {
    audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  public int GetDamage()
  {
    return damage;
  }

  public void Hit() 
  {

    if (isClaws && !isEnemy)
    {
      if (scratchspolsion != null)
      {
        audioPlayer.PlayShootingExplodeClipPlayer();
        PlayScratchExplosion();
        Destroy(gameObject);
      }
    }
  }

  void PlayScratchExplosion()
  {
      if (scratchspolsion != null)
      {
          ParticleSystem instance = Instantiate(scratchspolsion, transform.position, Quaternion.identity);
          Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
      }
  }

}
