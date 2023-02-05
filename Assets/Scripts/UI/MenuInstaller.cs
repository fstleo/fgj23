using System.Collections.Generic;
using UnityEngine;

public class MenuInstaller : Installer
{
    [SerializeField]
    private List<Menu> _menus;

    protected override void Initialize()
    {
        foreach (var menu in _menus)
        {
            menu.Init(GameInstance);
        }
    }
}