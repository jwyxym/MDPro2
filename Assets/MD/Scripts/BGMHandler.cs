using DefaultNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BGMHandler : MonoBehaviour
{
    public static float vol;
    AudioSource audioSource;
    static bool climax;
    static bool keycard;
    public static string fieldID = "001";

    public static int card;
    public static bool cardBGM;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        vol = int.Parse(Config.Get("bgmVol_", "500")) / 1000f;
        PlayBGM("menu");
    }

    public static void PlayBGM(string type)
    {
        AudioSource audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        AudioClip clip = GetClip(GetBgmByType(type));
        audioSource.clip = clip;
        audioSource.PlayScheduled(AudioSettings.dspTime);
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + audioSource.clip.length - 3f);
    }
    public static void PlayCardBGM(AudioClip clip)
    {
        AudioSource audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.PlayScheduled(AudioSettings.dspTime);
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + audioSource.clip.length - 3f);
    }
    public void LoopBGM()
    {
        var clip = audioSource.clip;
        audioSource.PlayScheduled(AudioSettings.dspTime);
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + audioSource.clip.length - 3f);
    }
    private void Update()
    {
        if(!audioSource.isPlaying)
            LoopBGM();
    }

    public static void ChangeCardBGM(int id)
    {
        BGMHandler handler = GameObject.Find("BGM").GetComponent<BGMHandler>();
        AudioClip clip = GetClip("card/" + id);
        if(clip != null && card != id)
        {
            card = id;
            cardBGM = true;
            handler.StartCardBgmChange(clip);
        }
    }
    public static void ChangeBGM(string type)
    {
        BGMHandler handler = GameObject.Find("BGM").GetComponent<BGMHandler>();
        if ((type == "duel_normal" || type == "duel_keycard" || type == "duel_climax") && cardBGM)
            return;
        if (type == "menu" || type == "deck")
        {
            cardBGM = false;
            card = 0;
        }
            
        if (type == "duel_climax" && !climax)
        {
            climax = true;
            handler.StartBgmChange(type);
        }
        else if (type == "duel_climax" && climax) 
        {
        }
        else if (type == "duel_keycard" && !keycard && !climax)
        {
            keycard = true;
            handler.StartBgmChange(type);
        }
        else if (type == "duel_keycard" && (keycard || climax))
        {
        }
        else
        {
            keycard = false;
            climax = false;
            handler.StartBgmChange(type);
        }   

    }

    void StartBgmChange(string type)
    {
        StartCoroutine(ChangeBGMFade(type, vol, vol));
    }
    void StartCardBgmChange(AudioClip clip)
    {
        StartCoroutine(ChangeCardBGMFade(clip, vol, vol));
    }
    public static void ChangeBgmVol(float _vol)
    {
        AudioSource audioSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        audioSource.volume = _vol;
        vol = _vol;
    }

    static AudioClip GetClip(string p)
    {
        var path = "sound/BGM/" + p + ".mp3";
        if (File.Exists(path) == false) path = "sound/BGM/" + p + ".wav";
        if (File.Exists(path) == false) path = "sound/BGM/" + p + ".ogg";
        if (File.Exists(path) == false) return null;
        path = Environment.CurrentDirectory.Replace("\\", "/") + "/" + path;
        path = "file:///" + path;
        WWW www = new WWW(path);
        return www.GetAudioClip(true, true);
    }

    IEnumerator ChangeBGMFade(string type, float vol, float currentVol, bool changed = false)
    {
        if(currentVol > 0 && !changed)
        {
            currentVol = currentVol - 0.01f;
            audioSource.volume = currentVol;
            yield return new WaitForSeconds(0.01f);
            yield return ChangeBGMFade(type, vol, currentVol);
            yield break;
        }
        if(currentVol <= 0 || changed)
        {
            if (!changed)
            {
                PlayBGM(type);
                changed = true;
            }
            currentVol = currentVol + 0.01f;
            audioSource.volume = currentVol;
            if (currentVol < vol)
            {
                yield return new WaitForSeconds(0.01f);
                yield return ChangeBGMFade(type, vol, currentVol, changed);
            }
            else
                audioSource.volume = vol;
        }
    }
    IEnumerator ChangeCardBGMFade(AudioClip clip, float vol, float currentVol, bool changed = false)
    {
        if (currentVol > 0 && !changed)
        {
            currentVol = currentVol - 0.01f;
            audioSource.volume = currentVol;
            yield return new WaitForSeconds(0.001f);
            yield return ChangeCardBGMFade(clip, vol, currentVol);
            yield break;
        }
        if (currentVol <= 0 || changed)
        {
            if (!changed)
            {
                PlayCardBGM(clip);
                changed = true;
            }
            currentVol = currentVol + 0.01f;
            audioSource.volume = currentVol;
            if (currentVol < vol)
            {
                yield return new WaitForSeconds(0.001f);
                yield return ChangeCardBGMFade(clip, vol, currentVol, changed);
            }
            else
                audioSource.volume = vol;
        }
    }
    static string GetBgmByType(string type)
    {
        switch (type)
        {
            case "menu":
                return "BGM_MENU_01";
            case "deck":
                return "BGM_MENU_02";
            case "duel_normal":
                return "BGM_DUEL_NORMAL_" + GetBgmID();
            case "duel_keycard":
                return "BGM_DUEL_KEYCARD_" + GetBgmID();
            case "duel_climax":
                return "BGM_DUEL_CLIMAX_" + GetBgmID();
            case "climax":
                int i = UnityEngine.Random.Range(1, 12);
                return i > 9 ? "BGM_DUEL_CLIMAX_" + i : "BGM_DUEL_CLIMAX_0" + i;
            default:
                return "BGM_MENU_01";
        }
    }
    static string GetBgmID()
    {
        switch (fieldID)
        {
            case "001":
                return "02";
            case "002":
                return "01";
            case "003":
                return "04";
            case "004":
                return "02";
            case "005":
                return "04";
            case "006":
                return "07";
            case "007":
                return "05";
            case "008":
                return "11";
            case "009":
                return "06";
            case "010":
                return "08";
            case "011":
                return "07";
            case "012":
                return "08";
            case "014":
                return "11";
            case "015":
                return "06";
            case "016":
                return "09";
            case "017":
                return "09";
            case "018":
                return "11";
            case "019":
                return "10";
            case "020":
                return "04";
            default:
                return "01";
        }
    }
}
