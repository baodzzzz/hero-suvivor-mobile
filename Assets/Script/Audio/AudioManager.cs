using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        audioClips.Add(AudioClipName.HitPlayer,
            Resources.Load<AudioClip>("hit"));
        audioClips.Add(AudioClipName.PlayerDeath,
            Resources.Load<AudioClip>("die"));
        audioClips.Add(AudioClipName.BaseAttack,
            Resources.Load<AudioClip>("baseAttack"));
            audioClips.Add(AudioClipName.SkillQ,
            Resources.Load<AudioClip>("skillQ"));
            audioClips.Add(AudioClipName.SKillW,
            Resources.Load<AudioClip>("skillW"));
            audioClips.Add(AudioClipName.SkillE,
            Resources.Load<AudioClip>("skillE"));
            audioClips.Add(AudioClipName.SkillR,
            Resources.Load<AudioClip>("skillR"));
            audioClips.Add(AudioClipName.SkillUlti,
            Resources.Load<AudioClip>("ulti"));
            audioClips.Add(AudioClipName.SKillRock,
            Resources.Load<AudioClip>("stoneSkill"));
            audioClips.Add(AudioClipName.CrepDie,
            Resources.Load<AudioClip>("crepDie"));


            
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
