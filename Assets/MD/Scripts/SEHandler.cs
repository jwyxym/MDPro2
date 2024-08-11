using System;
using System.IO;
using UnityEngine;

public class SEHandler : MonoBehaviour
{
    public static void Play(string clip)
    {
        AudioSource audioSource = Instantiate(Program.I().mod_audio_effect).GetComponent<AudioSource>();
        audioSource.volume = Program.I().setting.seVol;
        audioSource.clip = GetClip(clip);
        Destroy(audioSource, 5f);
    }

    public static void PlayInternalAudio(string clip)
    {
        AudioSource audioSource = Instantiate(Program.I().mod_audio_effect).GetComponent<AudioSource>();
        audioSource.volume = Program.I().setting.seVol;
        audioSource.clip = Resources.Load<AudioClip>("Sound/" + clip);
        Destroy(audioSource.gameObject, 5f);
    }

    public static void Stop()
    {
        GameObject.Find("SE").GetComponent<AudioSource>().Stop();
    }

    public static void PlaySingle(string clip)
    {
        AudioSource audioSource = GameObject.Find("SE").GetComponent<AudioSource>();
        //if (audioSource.isPlaying)
        //    return;
        audioSource.volume = Program.I().setting.seVol;
        audioSource.clip = GetClip(clip);
        audioSource.Play();
    }

    static AudioClip GetClip(string p)
    {
        var path = "sound/" + p + ".mp3";
        if (File.Exists(path) == false) path = "sound/" + p + ".wav";
        if (File.Exists(path) == false) path = "sound/" + p + ".ogg";
        if (File.Exists(path) == false) return null;
        path = Environment.CurrentDirectory.Replace("\\", "/") + "/" + path;
        path = "file:///" + path;
        //Debug.Log(path);
        WWW www = new WWW(path);
        return www.GetAudioClip(true, true);
    }
}
