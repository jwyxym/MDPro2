using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public string bgName;
    static GameObject homeUI;
    //static GameObject bgFront;

    private void Start()
    {
        homeUI = GameObject.Find("UI/HomeUI");
        LoadBgFront(Config.Get("Wallpaper0", "随机"));
    }

    static void LoadDIYBg()
    {
        LoadBgFront("神影依·拿非利");

        Transform transform = GameObject.Find("UI/HomeUI/RootWallpaper/Wallpaper").transform;
        foreach(var t in transform.GetComponentsInChildren<Transform>(true))
            if(t.name == "Front0002_1")
                Destroy(t.gameObject);
        transform = GameObject.Find("UI/Camera_UI").transform;
        GameObject frontLoader = ABLoader.LoadABFolder("spine/u81497285", "Front");
        frontLoader.transform.parent = transform;
        frontLoader.transform.localPosition = new Vector3(1.5f, 0, 0);

        var aniamation = frontLoader.GetComponentInChildren<SkeletonAnimation>();
        aniamation.loop = true;
        aniamation.AnimationName = "idel";

        //ABLoader.ChangeLayer(frontLoader, "UI");
    }

    public static void LoadBgFront(string name)
    {
        if (name == "迷宫城的白银姬")
        {
            LoadDIYBg();
            return;
        }


        name = BgMaping(name);
        Transform transform = GameObject.Find("UI/HomeUI/RootWallpaper/Wallpaper").transform;
        foreach(Transform t in transform.GetComponentsInChildren<Transform>(true))
        {
            if (t.name.StartsWith("Front"))
            {
                Destroy(t.gameObject);
            }
        }
        Transform camera = GameObject.Find("UI/Camera_UI").transform;
        if (camera.GetComponentsInChildren<Transform>(true).Length > 1) Destroy(camera.GetChild(0).gameObject);

        GameObject frontLoader = ABLoader.LoadABFolder("wallpaper/front" + name, "front");
        RectTransform front = frontLoader.transform.GetChild(0).GetComponent<RectTransform>();
        front.parent = transform;
        Destroy(frontLoader);
        front.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0f, front.rect.width);

        foreach (ParticleSystem p in front.GetComponentsInChildren<ParticleSystem>(true))
            p.Play();
    }

    static string BgMaping(string name)
    {
        switch (name)
        {
            case "随机":
                {
                    string re = "";
                    int i = Random.Range(1, 21);
                    if (i > 9)
                        re = "00" + i;
                    else
                        re = "000" + i;
                    return re;
                }
            case "青眼亚白龙":
                return "0001";
            case "神影依·拿非利":
                return "0002";
            case "铁兽战线 凶鸟施莱格":
                return "0003";
            case "宵星之自鸣天琴 丁吉尔苏":
                return "0004";
            case "闪刀姬-篝":
                return "0005";
            case "黄金卿埃尔德里奇":
                return "0006";
            case "双穹之圣骑联盟·机界骑士":
                return "0007";
            case "辉龙机巧降星":
                return "0008";
            case "守护神官玛哈德":
                return "0009";
            case "元素-英雄 真诚新宇侠":
                return "0010";
            case "流天类星龙":
                return "0011";
            case "翼日编号0 未来龙皇霍普":
                return "0012";
            case "异色眼弧灵摆龙":
                return "0013";
            case "访问码语者":
                return "0014";
            case "鬼计节":
                return "0015";
            case "星遗物所引导的前路":
                return "0016";
            case "黑魔导":
                return "0017";
            case "丘与萌芽的春化精":
                return "0018";
            case "北斗天熊放射":
                return "0019";
            case "魔界剧团之谢幕":
                return "0020";
            case "编号41 泥睡魔兽 貘熟梦":
                return "0041";
            default:
                return "0001";
        }
    }
    public static void CloseHomeUI()
    {
        if (homeUI == null)
            return;
        homeUI.SetActive(false);
        Transform camera = GameObject.Find("UI/Camera_UI").transform;
        if (camera.GetComponentsInChildren<Transform>(true).Length > 1) Destroy(camera.GetChild(0).gameObject);
    }

    public static void OpenHomeUI(bool now = true)
    {
        if (homeUI == null)
            return;
        if (now)
        {
            homeUI.SetActive(true);
            LoadBgFront(Config.Get("Wallpaper0", "随机"));
        }
        else
        {
            if (homeUI.activeSelf)
            {
                LoadBgFront(Config.Get("Wallpaper0", "随机"));
            }
        }
    }
}
