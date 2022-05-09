using Utils;
using UnityEngine;
using System.Collections.Generic;

public class MenuManager : Singleton<MenuManager>
{
    public GameObject GameOverMenu;
    public GameObject HomeMenu;

    [HideInInspector]
    public GameObject currentMenu;

    public List<MenuScreen> Menus { get; set; }

    protected override void OnAwake()
    {
        base.OnAwake();

        Menus = new List<MenuScreen>(GetComponentsInChildren<MenuScreen>(true));
        
        // Make sure none of the menus are active.
        Menus.ForEach(m => m.gameObject.SetActive(false));
        ShowHomeMenu();
    }
    private void Start()
    {
        GameTimer.Instance.OnGameEnd += LoadGameOverMenu;
    }

    private void OnDestroy()
    {
        GameTimer.Instance.OnGameEnd -= LoadGameOverMenu;
    }

    public void ShowHomeMenu()
    {
        ShowMenu(HomeMenu, false);
    }

    private void LoadGameOverMenu()
    {
        ShowMenu(GameOverMenu);
    }

    public void HideMenu(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }

    public void ShowMenu(GameObject menu, bool deactivatePreviousMenu = true)
    {
        menu.gameObject.SetActive(true);

        if (deactivatePreviousMenu)
        {
            currentMenu.SetActive(false);
        }

        currentMenu = menu;
    }

}
