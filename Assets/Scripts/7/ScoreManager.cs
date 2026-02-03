using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int CurrentScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CurrentScore = 0;
    }

    public void AddScore(int score)
    {
        CurrentScore += score;
        GameplayUIController.Instance.UpdateScore(CurrentScore);
    }
}
