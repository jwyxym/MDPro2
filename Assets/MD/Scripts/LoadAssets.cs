using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadAssets : MonoBehaviour
{
    public static Transform field1_;
    public static Transform field2_;
    public static Transform POS_AvatarStand_near;
    public static Transform POS_AvatarStand_far;
    public static Transform POS_Avatar_near;
    public static Transform POS_Avatar_far;
    public static Transform POS_Grave_near;
    public static Transform POS_Grave_far;


    public static Transform avatarstand1_;
    public static Transform avatarstand2_;
    public static Transform mate1_;
    public static Transform mate2_;
    public static Transform grave1_;
    public static Transform grave2_;

    public static BoxCollider fieldCollider1;
    public static BoxCollider fieldCollider2;
    public static BoxCollider mateCollider1;
    public static BoxCollider mateCollider2;

    public GameObject[] cDMates;
    AnimationControl ac;

    static string field1;
    static string field2;

    public static GameObject guide_near;
    public static GameObject guide_far;

    static LoadAssets instance;

    private void Awake()
    {
        instance = this;
        Ini();
    }
    public static LoadAssets I()
    {
        return instance;
    }

    public void Ini()
    {
        ac = GameObject.Find("new_gameField(Clone)/Assets_Loader").GetComponent<AnimationControl>();
        CreateField1(Config.Get("Field0", "随机"));
        CreateField2(Config.Get("Field1", "随机"));
        CreatePhaseButton();
        //Debug.Log(Program.I().ocgcore.condition);
        ABLoader.LoadAB("bg/celestialsphere_c001", transform);
    }

    public static void CreateTimer()
    {
        var timer = ABLoader.LoadAB("bg/timer/timer_c001");
        Transform timerPart = timer.transform.Find("Timer");
        Texture texture = timerPart.GetComponent<Renderer>().material.GetTexture("_Texture2D");
        timerPart.GetComponent<Renderer>().material.SetTexture("_SampleTexture2D_4791db607d671180b2a839392ec5ea21_Texture_1", texture);
        timer.transform.SetParent(field1_.parent, false);
        timer.AddComponent<TimerHandler>();
    }

    static void CreatePhaseButton()
    {
        var phaseButton = ABLoader.LoadAB("bg/timer/phasebutton_c001");
        Transform playerPart = phaseButton.transform.Find("PlayerPart");
        Texture texture = playerPart.GetComponent<Renderer>().material.GetTexture("_Texture2D");
        playerPart.GetComponent<Renderer>().material.SetTexture("_SampleTexture2D_4791db607d671180b2a839392ec5ea21_Texture_1", texture);
        Transform opponentPart = phaseButton.transform.Find("OpponentPart");
        opponentPart.GetComponent<Renderer>().material.SetTexture("_SampleTexture2D_4791db607d671180b2a839392ec5ea21_Texture_1", texture);

        phaseButton.transform.SetParent(field1_.parent, false);
        phaseButton.AddComponent<PhaseButtonHandler>();
    }

    public static void CreateGuide()
    {
        guide_near = ABLoader.LoadAB("bg/timer/playableguide_c001_near");
        guide_near.transform.SetParent(field1_, false);
        guide_near.transform.GetChild(1).gameObject.SetActive(false);
        guide_near.AddComponent<PlayableGuide>();
        guide_far = ABLoader.LoadAB("bg/timer/playableguide_c001_far");
        guide_far.transform.SetParent(field2_, false);
        guide_far.transform.GetChild(1).gameObject.SetActive(false);
        guide_far.AddComponent<PlayableGuide>();
    }

    public static void CreateField1(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        Transform parent = GameObject.Find("new_gameField(Clone)").transform;
        if (field1_ != null) Destroy(field1_.gameObject);
        field1 = MatMap(name);
        string field1_Name = "mat_" + field1 + "_near";
        field1_ = ABLoader.LoadAB("mat/" + field1_Name).transform;
        field1_.parent = parent;
        POS_AvatarStand_near = GetTransform(field1_, "POS_AvatarStand_near");
        POS_Avatar_near = GetTransform(field1_, "POS_Avatar_near");
        POS_Grave_near = GetTransform(field1_, "POS_Grave_near");
        AnimationControl.PlayAnimation(field1_, "StartToPhase1");

        fieldCollider1 = field1_.gameObject.AddComponent<BoxCollider>();
        fieldCollider1.center = new Vector3(38, 5, -10);
        fieldCollider1.size = new Vector3(10, 10, 10);
        AnimationControl.PlayFieldSE(field1_, "_Tap");
        AnimationControl.animationControl1 = AnimationControl.animationControl;

        if (field1_Name == "mat_018_near")
        {
            field1_.Find("fxp_Mat018_brk_ToPhase2_001_near").gameObject.SetActive(false);
            field1_.Find("fxp_Mat018_brk_ToPhase3_001_near").gameObject.SetActive(false);
            field1_.Find("fxp_Mat018_brk_ToPhase4_001_near").gameObject.SetActive(false);
            field1_.Find("fxp_Mat018_brk_End_001_near").gameObject.SetActive(false);
            var particles = field1_.Find("Tap").GetComponentsInChildren<ParticleSystem>();
            foreach(ParticleSystem particle in particles)
            {
                var main = particle.main;
                main.loop = false;
            }
        }
        CreateAvatarStand1(Config.Get("AvatarBase0", "暗游戏"));
        CreateGrave1(Config.Get("Grave0", "暗游戏"));
    }
    public static void CreateField2(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        Transform parent = GameObject.Find("new_gameField(Clone)").transform;
        if (field2_ != null) Destroy(field2_.gameObject);
        field2 = MatMap(name);
        BGMHandler.fieldID = field2;
        string field2_Name = "mat_" + field2 + "_far";
        field2_ = ABLoader.LoadAB("mat/" + field2_Name).transform;
        field2_.parent = parent;
        POS_AvatarStand_far = GetTransform(field2_, "POS_AvatarStand_far");
        POS_Avatar_far = GetTransform(field2_, "POS_Avatar_far");
        POS_Grave_far = GetTransform(field2_, "POS_Grave_far");
        AnimationControl.PlayAnimation(field2_, "StartToPhase1");

        fieldCollider2 = field2_.gameObject.AddComponent<BoxCollider>();
        fieldCollider2.center = new Vector3(-38, 5, 10);
        fieldCollider2.size = new Vector3(10, 10, 10);
        AnimationControl.PlayFieldSE(field2_, "_Tap");
        AnimationControl.animationControl2 = AnimationControl.animationControl;

        if (field2_Name == "mat_018_far")
        {
            field2_.Find("fxp_Mat018_brk_ToPhase2_001_far").gameObject.SetActive(false);
            field2_.Find("fxp_Mat018_brk_ToPhase3_001_far").gameObject.SetActive(false);
            field2_.Find("fxp_Mat018_brk_ToPhase4_001_far").gameObject.SetActive(false);
            field2_.Find("fxp_Mat018_brk_End_001_far").gameObject.SetActive(false);
            field2_.Find("Tap").gameObject.SetActive(false);
            var particles = field2_.Find("Tap").GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem particle in particles)
            {
                var main = particle.main;
                main.loop = false;
            }
        }

        CreateAvatarStand2(Config.Get("AvatarBase1", "暗游戏"));
        CreateGrave2(Config.Get("Grave1", "暗游戏"));
    }
    public static void CreateAvatarStand1(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (avatarstand1_ != null) Destroy(avatarstand1_.gameObject);
        if (name == "无设置")
        {
            POS_Avatar_near = GetTransform(field1_.transform, "POS_Avatar_near");
            ResetMatePandR("me");
            return;
        }
        string avatarstand1_Name = "avatarstand_" + AvatarStandMap(name, true) + "_near";
        avatarstand1_ = ABLoader.LoadAB("avatarstand/" + avatarstand1_Name).transform;
        avatarstand1_.position = POS_AvatarStand_near.position;
        avatarstand1_.parent = field1_;
        POS_Avatar_near = GetTransform(avatarstand1_.transform, "POS_Avatar_near");
        AnimationControl.PlayAnimation(avatarstand1_, "StartToPhase1");
        CreateMate1(Config.Get("Mate0", "随机"));
    }
    public static void CreateAvatarStand2(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (avatarstand2_ != null) Destroy(avatarstand2_.gameObject);
        if (name == "无设置")
        {
            POS_Avatar_far = GetTransform(field2_.transform, "POS_Avatar_far");
            ResetMatePandR("op");
            return;
        }
        string avatarstand2_Name = "avatarstand_" + AvatarStandMap(name, false) + "_far";
        avatarstand2_ = ABLoader.LoadAB("avatarstand/" + avatarstand2_Name).transform;
        avatarstand2_.position = POS_AvatarStand_far.position;
        avatarstand2_.parent = field2_;
        POS_Avatar_far = GetTransform(avatarstand2_.transform, "POS_Avatar_far");
        AnimationControl.PlayAnimation(avatarstand2_, "StartToPhase1");
        ResetMatePandR("op");
        CreateMate2(Config.Get("Mate1", "随机"));
    }
    public static void CreateMate1(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (mate1_ != null) Destroy(mate1_.gameObject);
        if (name == "无设置") return;
        if (name.StartsWith("CD-"))
        {
            mate1_ = LoadCDMate(name).transform;
            ResetMatePandR("me");
            mate1_.parent = field1_;
            mate1_.localScale = new Vector3(5, 5, 5);
            mate1_.gameObject.AddComponent<EventSEPlayer>();
            mateCollider1 = mate1_.gameObject.AddComponent<BoxCollider>();
            mateCollider1.center = new Vector3(0, 1, 0);
            mateCollider1.size = new Vector3(1, 2, 1);
        }
        else
        {
            mate1_ = ABLoader.LoadAB("mate/" + MateMap(name)).transform;
            ResetMatePandR("me");
            mate1_.parent = field1_;
            AnimationControl.PlayAnimation(mate1_, "Entry");
            mate1_.GetChild(0).gameObject.AddComponent<EventSEPlayer>();
            mateCollider1 = mate1_.gameObject.AddComponent<BoxCollider>();
            mateCollider1.center = new Vector3(0, 5, 0);
            mateCollider1.size = new Vector3(5, 10, 5);
        }        

    }
    public static void CreateMate2(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (mate2_ != null) Destroy(mate2_.gameObject);
        if (name == "无设置") return;
        if (name.StartsWith("CD-"))
        {
            mate2_ = LoadCDMate(name).transform;
            ResetMatePandR("op");
            mate2_.parent = field2_;
            mate2_.localScale = new Vector3(5, 5, 5);
            mate2_.gameObject.AddComponent<EventSEPlayer>();
            mateCollider2 = mate2_.gameObject.AddComponent<BoxCollider>();
            mateCollider2.center = new Vector3(0, 1, 0);
            mateCollider2.size = new Vector3(1, 2, 1);
        }
        else
        {
            mate2_ = ABLoader.LoadAB("mate/" + MateMap(name)).transform;
            ResetMatePandR("op");
            mate2_.parent = field2_;
            AnimationControl.PlayAnimation(mate2_, "Entry");
            mate2_.GetChild(0).gameObject.AddComponent<EventSEPlayer>();
            mateCollider2 = mate2_.gameObject.AddComponent<BoxCollider>();
            mateCollider2.center = new Vector3(0, 5, 0);
            mateCollider2.size = new Vector3(5, 10, 5);
        }
    }
    public static void CreateGrave1(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (grave1_ != null) Destroy(grave1_.gameObject);
        string grave1_Name;
        if (GraveMap(name, true) == "001") grave1_Name = "grave_c001_near";
        else grave1_Name = "grave_" + GraveMap(name, true) + "_near";
        grave1_ = ABLoader.LoadAB("grave/" +  grave1_Name).transform;
        grave1_.position = POS_Grave_near.position;
        grave1_.parent = field1_;
        AnimationControl.PlayAnimation(grave1_, "StartToPhase1");
    }
    public static void CreateGrave2(string name)
    {
        if (GameObject.Find("new_gameField(Clone)") == null) return;
        if (grave2_ != null) Destroy(grave2_.gameObject);
        string grave2_Name;
        if (GraveMap(name, false) == "001") grave2_Name = "grave_c001_far";
        else grave2_Name = "grave_" + GraveMap(name, false) + "_far";
        grave2_ = ABLoader.LoadAB("grave/" +  grave2_Name).transform;
        grave2_.position = POS_Grave_far.position;
        grave2_.parent = field2_;
        AnimationControl.PlayAnimation(grave2_, "StartToPhase1");
    }
    public static Transform GetTransform(Transform check, string name)
    {
        Transform forreturn = null;
        foreach (Transform t in check.GetComponentsInChildren<Transform>())
        {
            if (t.name == name)
            {
                return t;
            }
        }
        return forreturn;
    }
    static void ResetMatePandR(string me_Or_op)
    {
        if (me_Or_op == "me")
        {
            if (mate1_ != null)
            {
                mate1_.transform.position = POS_Avatar_near.position;
                mate1_.transform.eulerAngles = POS_Avatar_near.eulerAngles;
            }
        }
        if (me_Or_op == "op")
        {
            if (mate2_ != null)
            {
                mate2_.transform.position = POS_Avatar_far.position;
                mate2_.transform.eulerAngles = POS_Avatar_far.eulerAngles;
            }
        }
    }

    public static GameObject LoadCDMate(string name)
    {
        var la = GameObject.Find("new_gameField(Clone)/Assets_Loader").GetComponent<LoadAssets>();
        for (int i = 0; i < la.cDMates.Length; i++)
        {
            if (la.cDMates[i].name == name)
            {
                var cDMate = Instantiate(la.cDMates[i]);
                return cDMate;
            }
        }
        return null;
    }
    public static string MatMap(string name)
    {
        if (name != null)
        {
            switch (name)
            {
                case "随机": return RandomMap("Mat");
                case "与我方场地相同": return field1;
                case "仪式之间": return "001";
                case "森林": return "002";
                case "魔导书廊": return "003";
                case "齿轮镇": return "004";
                case "火山": return "005";
                case "星遗物沉眠的废墟": return "006";
                case "异国首都": return "007";
                case "角斗场": return "008";
                case "夜晚的摩天楼": return "009";
                case "冰封的世界": return "010";
                case "荒野的神殿": return "011";
                case "未界域–欧玛利亚大陆": return "012";
                case "相剑的灵峰": return "014";
                case "生机盎然的碧蓝大海": return "015";
                case "魔法甜点城堡": return "016";
                case "鬼计之馆": return "017";
                case "电脑宇宙": return "018";
                case "突异变种进化研究所": return "019";
                case "古代决斗回忆": return "020";
                default: return "002";
            }
        }
        else return "002";
    }
    public static string GraveMap(string name, bool me)
    {
        if (name != null)
        {
            switch (name)
            {
                case "随机": return RandomMap("Grave");
                case "与场地相同":
                    if (me)
                        return field1;
                    else
                        return field2;
                case "仪式之间": return "001";
                case "森林": return "002";
                case "魔导书廊": return "003";
                case "齿轮镇": return "004";
                case "火山": return "005";
                case "星遗物沉眠的废墟": return "006";
                case "异国首都": return "007";
                case "角斗场": return "008";
                case "夜晚的摩天楼": return "009";
                case "冰封的世界": return "010";
                case "荒野的神殿": return "011";
                case "未界域–欧玛利亚大陆": return "012";
                case "相剑的灵峰": return "014";
                case "生机盎然的碧蓝大海": return "015";
                case "魔法甜点城堡": return "016";
                case "鬼计之馆": return "017";
                case "电脑宇宙": return "018";
                case "突异变种进化研究所": return "019";
                case "古代决斗回忆": return "020";

                case "落穴": return "u001";
                case "魔术礼帽": return "u002";
                case "召唤限制器": return "u003";
                case "大陷坑": return "u006";
                case "捕食植物奇美拉霸王花": return "u009";
                case "TG1-EM1": return "u010";
                case "与奈落的契约": return "u011";
                case "破坏轮回": return "u016";
                case "u017": return "u017";
                case "攻击无力化": return "u019";
                case "双龙卷": return "u020";
                default: return "002";
            }
        }
        else return "002";
    }
    public static string AvatarStandMap(string name, bool me)
    {
        if (name != null)
        {
            switch (name)
            {
                case "随机": return RandomMap("AvatarStand");
                case "与场地相同":
                    if (me)
                        return field1;
                    else
                        return field2;
                case "仪式之间": return "001";
                case "森林": return "002";
                case "魔导书廊": return "003";
                case "齿轮镇": return "004";
                case "火山": return "005";
                case "星遗物沉眠的废墟": return "006";
                case "异国首都": return "007";
                case "角斗场": return "008";
                case "夜晚的摩天楼": return "009";
                case "冰封的世界": return "010";
                case "荒野的神殿": return "011";
                case "未界域–欧玛利亚大陆": return "012";
                case "相剑的灵峰": return "014";
                case "生机盎然的碧蓝大海": return "015";
                case "魔法甜点城堡": return "016";
                case "鬼计之馆": return "017";
                case "电脑宇宙": return "018";
                case "突异变种进化研究所": return "019";
                case "古代决斗回忆": return "020";

                case "光虫基盘": return "u001";
                case "通灵盘": return "u002";
                case "紫炎的道场": return "u003";
                case "花牌戏": return "u004";
                case "龙棋战术": return "u005";
                case "飞箭龟": return "u006";
                case "星遗物-星键-": return "u008";
                case "升阶魔法-巴利安之力": return "u011";
                case "升阶魔法-阿斯特拉尔之力": return "u012";
                case "H-炽热之心": return "u013";
                case "E-紧急呼救": return "u014";
                case "R-公平正义": return "u015";
                case "O-超越灵魂": return "u016";
                case "命运标记": return "u018";
                case "雷神的夏末": return "u022";
                case "通常怪兽卡": return "u027";
                default: return "002";
            }
        }
        else return "002";
    }
    public static string MateMap(string name)
    {
        if (name != null)
        {
            switch (name)
            {
                case "随机": return RandomMap("Mate");
                case "青眼白龙": return "m04007_model";
                case "黑魔导": return "m04041_model";
                case "龙骑士盖亚": return "m04043_model";
                case "暗黑骑士盖亚": return "m04044_model";
                case "三眼怪": return "m04054_model";
                case "库里波": return "m04064_model";
                case "替罪山羊": return "m04818_model";
                case "强欲之壶": return "m04844_model";
                case "月之书": return "m05432_model";
                case "棉花糖": return "m06000_model";
                case "悠悠": return "m06018_model";
                case "摩艾迎击炮": return "m06323_model";
                case "元素-英雄 大气人": return "m06784_model";
                case "简易结合": return "m06901_model";
                case "仪式的供品": return "m07188_model";
                case "螺丝刺猬": return "m07701_model";
                case "冰结界之龙三叉龙": return "m08732_model";
                case "机偶桶 真九六": return "m09285_model";
                case "齿轮齿轮人": return "m09647_model";
                case "影蜥蜴": return "m09723_model";
                case "救援兔": return "m09755_model";
                case "强欲的碎片": return "m09775_model";
                case "忍者大师 HANZO": return "m09903_model";
                case "圣剑卡里班": return "m10468_model";
                case "鬼计南瓜灯": return "m10747_model";
                case "机壳独立柱": return "m11540_model";
                case "电子龙无限（迷你）": return "m11765_sd_model";
                case "精神骨架装备 伽马": return "m12070_model";
                case "年糕蛙": return "m12642_model";
                case "古代机械齿轮飞龙": return "m12678_model";
                case "DD幽灵": return "m12929_model";
                case "灰流丽": return "m12950_model";
                case "比特创机": return "m13029_model";
                case "星杯守护龙": return "m13060_model";
                case "归魂仇尸·屠魔侠": return "m13208_model";
                case "枪管上膛龙（迷你）": return "m13258_sd_model";
                case "全新的生命-伽拉忒亚-": return "m13636_model";
                case "未界域之鹿角兔": return "m13981_model";
                case "转生炎兽 羚羊": return "m14240_model";
                case "龙女仆·清扫龙女": return "m14759_model";
                case "龙女仆·芙流丝": return "m14760_model";
                case "白骨烤王": return "m15726_model";
                case "鲑鱼子军贯": return "m16201_model";
                case "雷灵放电·蓝": return "m17405_model";

                case "足球": return "v00001_model";
                case "篮球": return "v00002_model";
                case "电唱机": return "v00003_model";
                case "美式足球": return "v00004_model";
                case "橄榄球": return "v00005_model";
                case "车辆": return "v00006_model";
                case "宝箱": return "v00007_model";
                case "拳击": return "v00008_model";
                case "皇冠": return "v00009_model";
                case "直排轮滑鞋": return "v00010_model";
                case "飞镖": return "v00011_model";
                default: return "m04007_model";
            }
        }
        else return "m04007_model";
    }

    static List<string> mats = new List<string>()
    {
        "001",
        "002",
        "003",
        "004",
        "005",
        "006",
        "007",
        "008",
        "009",
        "010",
        "011",
        "012",
        "014",
        "015",
        "016",
        "017",
        "018",
        "019",
        "020"
    };
    static List<string> graves = new List<string>()
    {
        "001",
        "002",
        "003",
        "004",
        "005",
        "006",
        "007",
        "008",
        "009",
        "010",
        "011",
        "012",
        "014",
        "015",
        "016",
        "017",
        "018",
        "019",
        "020",
        "u001",
        "u002",
        "u003",
        "u006",
        "u009",
        "u010",
        "u011",
        "u016",
        "u017",
        "u019",
        "u020",
    };
    static List<string> avatarstands = new List<string>()
    {
        "001",
        "002",
        "003",
        "004",
        "005",
        "006",
        "007",
        "008",
        "009",
        "010",
        "011",
        "012",
        "014",
        "015",
        "016",
        "017",
        "018",
        "019",
        "020",
        "u001",
        "u002",
        "u003",
        "u004",
        "u005",
        "u006",
        "u008",
        "u011",
        "u012",
        "u013",
        "u014",
        "u015",
        "u016",
        "u018",
        "u022",
        "u027",
    };
    static List<string> mates = new List<string>()
    {
        "m04007_model",
        "m04041_model",
        "m04043_model",
        "m04044_model",
        "m04054_model",
        "m04064_model",
        "m04818_model",
        "m04844_model",
        "m05432_model",
        "m06000_model",
        "m06018_model",
        "m06323_model",
        "m06784_model",
        "m06901_model",
        "m07188_model",
        "m07701_model",
        "m08732_model",
        "m09285_model",
        "m09647_model",
        "m09723_model",
        "m09755_model",
        "m09775_model",
        "m09903_model",
        "m10468_model",
        "m10747_model",
        "m11540_model",
        "m11765_sd_model",
        "m12070_model",
        "m12642_model",
        "m12678_model",
        "m12929_model",
        "m12950_model",
        "m13029_model",
        "m13060_model",
        "m13208_model",
        "m13258_sd_model",
        "m13636_model",
        "m13981_model",
        "m14240_model",
        "m14759_model",
        "m14760_model",
        "m15726_model",
        "m16201_model",
        "m17405_model",

        "v00001_model",
        "v00002_model",
        "v00003_model",
        "v00004_model",
        "v00005_model",
        "v00006_model",
        "v00007_model",
        "v00008_model",
        "v00009_model",
        "v00010_model",
        "v00011_model",
    };
    static string RandomMap(string type)
    {
        string returnString = "";
        switch (type)
        {
            case "Mat":
                returnString = mats[Random.Range(0, mats.Count)];
                break;
            case "Grave":
                returnString = graves[Random.Range(0, graves.Count)];
                break;
            case "AvatarStand":
                returnString = avatarstands[Random.Range(0, avatarstands.Count)];
                break;
            case "Mate":
                returnString = mates[Random.Range(0, mates.Count)];
                break;
        }
        return returnString;
    }
}