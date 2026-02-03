using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuiUiController : MonoBehaviour
{
    [SerializeField] private UIDocument mainMenuDocument;
    [SerializeField] private UIDocument levelSelectionDocument;
    [SerializeField] private UIDocument aboutDocument;

    private Button playButton;
    private Button aboutButton;
    private Button quitButton;

    private Button backButton;

    [SerializeField] private List<string> levelName;

    void Start()
    {
        playButton = mainMenuDocument.rootVisualElement.Q<Button>("Play");
        aboutButton = mainMenuDocument.rootVisualElement.Q<Button>("About");
        quitButton = mainMenuDocument.rootVisualElement.Q<Button>("Quit");
        if (playButton != null)
        {
            playButton.clicked += ShowLevelSelection;
        }
        if (aboutButton != null)
        {
            aboutButton.clicked += ShowAbout;
        }
        if (quitButton != null)
        {
            quitButton.clicked += QuitGame;
        }

        backButton = levelSelectionDocument.rootVisualElement.Q<Button>("Back");
        if (backButton != null)
        {
            backButton.clicked += ShowMainMenu;
        }
        backButton = aboutDocument.rootVisualElement.Q<Button>("Back");
        if (backButton != null)
        {
            backButton.clicked += ShowMainMenu;
        }

        foreach (string level in levelName)
        {
            Button levelButton = levelSelectionDocument.rootVisualElement.Q<Button>(level);
            if (levelButton != null)
            {
                levelButton.clicked += () => UnityEngine.SceneManagement.SceneManager.LoadScene(level);
            }
        }

        ShowMainMenu();
    }

    private void ShowLevelSelection()
    {
        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        levelSelectionDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        aboutDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
    private void ShowMainMenu()
    {
        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        levelSelectionDocument.rootVisualElement.style.display = DisplayStyle.None;
        aboutDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
    private void ShowAbout()
    {
        mainMenuDocument.rootVisualElement.style.display = DisplayStyle.None;
        levelSelectionDocument.rootVisualElement.style.display = DisplayStyle.None;
        aboutDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
