using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelComment : MonoBehaviour
{
    public UI2DSprite background;
    public UILabel label;
    public bool isShowed;
    public bool me;
    void Start()
    {
        Hide();
    }

    public void DelaySpeak(float time, string content)
    {
        StartCoroutine(SpeakInDelay(time, content));
    }

    public IEnumerator SpeakInDelay(float time, string content)
    {
        yield return new WaitForSeconds(time);
        Speak(content);
    }

    public void Speak(string content)
    {
        isShowed = true;
        label.text = content;

        background.alpha = 0f;
        background.gameObject.transform.localScale = Vector3.zero;

        if (me)
        {
            if (content.Length > 10)
                background.rightAnchor.absolute = 402;
            else
            {
                int length = 105 + 27 * content.Length;
                if (length < 213) length = 213;
                background.rightAnchor.absolute = length;
            }
        }
        else
        {
            if (content.Length > 10)
                background.leftAnchor.absolute = -402;
            else
            {
                int length = -105 - 27 * content.Length;
                if (length > -213) length = -213;
                background.leftAnchor.absolute = length;
            }
        }

        DOTween.To(() => background.alpha, x => background.alpha = x, 1, 0.1f);
        background.gameObject.transform.DOScale(Vector3.one, 0.1f).OnComplete(()=> 
        {
            label.fontSize = 26;
            label.fontSize = 25;
        });
    }

    public void Hide()
    {
        if (isShowed)
        {
            isShowed = false;
            background.alpha = 0f;
            background.gameObject.transform.localScale = Vector3.zero;
        }
    }
}
