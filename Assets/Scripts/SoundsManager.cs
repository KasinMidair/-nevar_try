using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    static public SoundsManager instance;
    public SoundClip[] soundList;
    [SerializeField] AudioSource oneShotSounds;

    [System.Serializable]
    public class SoundClip
    {
       public AudioClip sound;
       public SoundType type;
    }
    public enum SoundType
    {
        powerUpSound,
        buttonsSound,
        playerUp_HoverSound,
        playerDieSound
    }
     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private AudioClip GetAudioClipByType(SoundType type)
    {
        for(int i=0;i< soundList.Length; ++i)
        {
            if (soundList[i].type == type)
            {
                return soundList[i].sound;
            }
        }
        return null;
    }
    public void PlayOneShot(SoundType type)
    {
        oneShotSounds.clip = GetAudioClipByType(type);
        oneShotSounds.Play();

    }
    
   
}
