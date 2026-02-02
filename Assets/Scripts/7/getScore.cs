using UnityEngine;

public class getScore : MonoBehaviour
{
    public CircleScoreSO circleScoreSO;

    private int currentScore;

    private void Start()
    {
        currentScore = circleScoreSO.score;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(currentScore);
        }
    }
}
