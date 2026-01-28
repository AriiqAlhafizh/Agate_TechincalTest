using UnityEngine;

public class MouseTrackMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private InputReader inputReader;

    [SerializeField] private float speed = 1f;

    private Vector2 mousePos;

    private void Awake()
    {
        inputReader.lookEvent += OnLook;
    }

    private void OnLook(Vector2 vector)
    {
        Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, 0));
        mousePos = worldMousePos;
    }

    void Update()
    {
        
        if ((Vector3)mousePos != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)mousePos, speed * Time.deltaTime);
        }

    }
}
