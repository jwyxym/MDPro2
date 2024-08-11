using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YGOSharp.OCGWrapper.Enums;

public class PlayableGuide : MonoBehaviour
{
    Animator animator;
    bool me;
    int currentCondition = 0;
    int updatedCondition = 0;
    void Start()
    {
        if (gameObject.name.StartsWith("PlayableGuide_c001_near"))
            me = true;
        else
            me = false;
        animator = GetComponent<Animator>();
        Guide(0);
    }
    void Update()
    {
        if (Program.I().ocgcore.myTurn)
        {
            if (Program.I().ocgcore.currentMessage == GameMessage.Waiting)
                updatedCondition = 2;
            else
                updatedCondition = 1;
        }
        else
        {
            if (Program.I().ocgcore.currentMessage == GameMessage.SelectChain)
                updatedCondition = 1;
            else
                updatedCondition = 2;
        }
        if (currentCondition != updatedCondition)
        {
            currentCondition = updatedCondition;
            Guide(currentCondition);
        }
    }

    void Guide(int i)
    {
        switch (i)
        {
            case 0:
                animator.SetTrigger("Out");
                break;
            case 1:
                if(me)
                    animator.SetTrigger("Apper");
                else
                    animator.SetTrigger("Out");
                break;
            case 2:
                if (me)
                    animator.SetTrigger("Out");
                else
                    animator.SetTrigger("Apper");
                break;
        }
    }
}
