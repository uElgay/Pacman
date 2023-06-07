using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
   public Audio[] sounds;
   private PlayerDeath thePlayer;

   void Start()
   {
        Play("game");
   }

   void Awake()
   {
    foreach(var s in sounds)
    {
        thePlayer=FindObjectOfType<PlayerDeath>();
        s.source=gameObject.AddComponent<AudioSource>();
        s.source.clip=s.clip;
        s.source.volume=s.volume;
        s.source.pitch=s.pitch;
        s.source.loop=s.loop;
    }
   }

   public void Play(string name)
   {
        Audio s=Array.Find(sounds,sound => sound.name == name);
        s.source.Play();
   }

   public void Stop(string name)
   {
        Audio s=Array.Find(sounds,sound => sound.name == name);
        s.source.Stop();
   }
}
