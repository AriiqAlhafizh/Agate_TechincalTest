using UnityEngine;
using UnityEngine.UIElements;

public class UIScoreController : MonoBehaviour
{
    public static UIScoreController Instance { get; private set; }

    private UIDocument UIDocument;
    private Label ScoreLabel;

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
        UIDocument = GetComponent<UIDocument>();
        ScoreLabel = UIDocument.rootVisualElement.Q<Label>("Score");
        ScoreLabel.text = "0";
    }

    public void UpdateScore(int score)
    {
        ScoreLabel.text = score.ToString();
    }
}
