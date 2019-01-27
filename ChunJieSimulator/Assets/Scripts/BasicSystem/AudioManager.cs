using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _Instance;
    public static AudioManager Instance {
        get {
            if (_Instance == null) {
                GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("AudioManager"));
                GameObject.DontDestroyOnLoad(go);
                _Instance = go.GetComponent<AudioManager>();
            }
            return _Instance;
        }
    }

    public AudioSource bgmSource;
    public AudioSource effectSource;
    public void PlayBgm(AudioClip clip) {
        bgmSource.clip = clip;
        bgmSource.Play();
    }
    public void PlayEffect(AudioClip clip) {
        effectSource.PlayOneShot(clip);
    }

}
