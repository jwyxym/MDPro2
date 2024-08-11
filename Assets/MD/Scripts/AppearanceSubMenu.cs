using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppearanceSubMenu : MonoBehaviour
{
    public UILabel title;
    public UIWidget content;
    UI2DSprite menuBase;
    Collider collider;


    public bool selected;
    bool selectable;
    bool hover;
    void Awake()
    {
        collider = GetComponent<BoxCollider>();
        menuBase = GetComponent<UI2DSprite>();
        title = transform.GetChild(0).GetComponent<UILabel>();
        content = transform.GetChild(1).GetComponent<UIWidget>();
        content.alpha = 0f;
    }

    private void Update()
    {
        if(Program.pointedCollider == collider)
        {
            if (!hover && !selected && selectable)
            {
                hover = true;
                menuBase.sprite2D = Program.I().appearance.hover;
                menuBase.border = new Vector4(15, 15, 15, 15);
            }

            if (Program.InputGetMouseButtonUp_0 && selectable)
            {
                if(!selected)
                {
                    Show();
                }
                SEHandler.PlayInternalAudio("se_sys/SE_MENU_SELECT_01");
            }
        }
        else
        {
            if (hover)
            {
                hover = false;
                if (!selected)
                {
                    menuBase.sprite2D = Program.I().appearance.normal;
                    menuBase.border = new Vector4(7, 5, 3, 5);
                }
            }
        }
    }

    public void Show()
    {
        selected = true;
        collider.enabled = true;

        menuBase.sprite2D = Program.I().appearance.selected;
        menuBase.border = new Vector4(15, 15, 15, 15);
        title.color = Color.black;
        content.alpha = 1f;

        foreach(var menu in Program.I().appearance.subMenus)
            if(menu.gameObject != gameObject)
            {
                menu.Hide();
            }
    }

    public void Preselect(string itemName)
    {
        foreach(var item in GetComponentsInChildren<AppearanceItem>())
            if(item.labelName.text == itemName)
            {
                item.OnSelect();
                break;
            }
    }

    public void Selectable(bool selectable)
    {
        this.selectable = selectable;
        if (selectable)
        {
            title.color = Color.white;
        }
        else
        {
            title.color = Color.gray;
        }
    }

    public void Hide()
    {
        selected = false;

        menuBase.sprite2D = Program.I().appearance.normal;
        menuBase.border = new Vector4(7, 5, 3, 5);
        if(selectable)
            title.color = Color.white;
        else
            title.color = Color.gray;
        content.alpha = 0f;
    }

    public void Save()
    {
        bool saved = false;
        foreach (var item in GetComponentsInChildren<AppearanceItem>())
            if (item.selected)
            {
                Config.Set(name + Program.I().appearance.player, item.labelName.text);
                saved = true;
            }
        if(!saved)
            Config.Set(name + Program.I().appearance.player, transform.GetChild(2).name);
    }
}
