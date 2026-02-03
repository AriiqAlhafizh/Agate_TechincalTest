using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController Instance { get; private set; }

    public UIDocument scoreDocument;
    public UIDocument pauseDocument;

    private Label ScoreLabel;

    private Button resumeBtn;
    private Button restartBtn;
    private Button mainMenuBtn;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        ScoreLabel = scoreDocument.rootVisualElement.Q<Label>("Score");
        ScoreLabel.text = "0";

        pauseDocument.enabled = true;
        resumeBtn = pauseDocument.rootVisualElement.Q<Button>("Resume");
        restartBtn = pauseDocument.rootVisualElement.Q<Button>("Restart");
        mainMenuBtn = pauseDocument.rootVisualElement.Q<Button>("MainMenu");

        if(resumeBtn != null)
        {
            resumeBtn.clicked += resumeScene;
        }
        if (restartBtn != null)
        {
            restartBtn.clicked += restartScene;
        }
        if(mainMenuBtn != null)
        {
            mainMenuBtn.clicked += goToMainMenu;
        }
        pauseDocument.rootVisualElement.style.display = DisplayStyle.None;
    }
    private void OnDisable()
    {
        if (resumeBtn != null)
        {
            resumeBtn.clicked -= resumeScene;
        }
        if (restartBtn != null)
        {
            restartBtn.clicked -= restartScene;
        }
        if (mainMenuBtn != null)
        {
            mainMenuBtn.clicked -= goToMainMenu;
        }
    }

    public void UpdateScore(int score)
    {
        ScoreLabel.text = score.ToString();
    }

    void resumeScene()
    {
        Debug.Log("Resuming Scene");

        pauseDocument.rootVisualElement.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
    }

    public void pauseScene()
    {
        pauseDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
    }
    void restartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    void goToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
