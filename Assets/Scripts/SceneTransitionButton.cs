using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public string SceneName;
    private Button sceneButton;

    private void Awake()
    {
        sceneButton = GetComponent<Button>();
        sceneButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        MenuManager.Instance.currentMenu.SetActive(false);
        SceneManager.LoadScene(SceneName);

        if (SceneName == MenuManager.Instance.HomeMenu.name)
            MenuManager.Instance.ShowHomeMenu();
    }
}
