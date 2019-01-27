using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] bgms;
    Dictionary<string, AudioClip> _scene2Bgm;
    Dictionary<string, AudioClip> scene2Bgm {
        get {
            if (_scene2Bgm == null) {
                _scene2Bgm = new Dictionary<string, AudioClip>()
                {
                    { "Test_Main_menu", bgms[1] },
                    { "S10_Dialog5", bgms[2] },
                };
            }
            return _scene2Bgm;
        }
    }
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
        if (clip != null) {
            bgmSource.Play();
        } else {
            bgmSource.Pause();
        }
    }
    public void PlayEffect(AudioClip clip, float volumeScale) {
        effectSource.PlayOneShot(clip, volumeScale);
    }

    internal void PlaySceneBgm(string sceneName) {
        if (scene2Bgm.ContainsKey(sceneName)) {
            PlayBgm(scene2Bgm[sceneName]);
        }
    }
}
