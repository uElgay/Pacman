using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Audio 
{
    public string name;
    public AudioClip clip;
    public float volume;
    public float pitch;
    public AudioSource source;
    public bool loop;

}
