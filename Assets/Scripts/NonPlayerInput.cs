using UnityEngine;

public class NonPlayerInput : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private void Awake()
    {
        inputReader.pauseEvent += OnPause;
    }

    private void OnPause()
    {
        GameplayUIController.Instance.pauseScene();
    }
}
