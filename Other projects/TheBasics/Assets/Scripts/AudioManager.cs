using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach(Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();            
            item.source.clip = item.clip;
            item.source.volume = item.volume;
        }
    }
   
    public void PlaySound(string name)
    {
        bool nullcheck = true;
        foreach (Sound item in sounds)
        {
            if(item.name==name)
            {
                item.source.Play();
                nullcheck = false;
            }
        }
        if(nullcheck)
        {
            print(name + " not found");
        }
    }
}
