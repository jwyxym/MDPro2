using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Policy;
using UnityEngine;

public class TestLoad : MonoBehaviour
{
    void OnEnable()
    {
        var a1 = ABLoader.LoadABFolder("effects/hit");
        //a1.transform.DOMoveZ(10, 1);
    }
}
