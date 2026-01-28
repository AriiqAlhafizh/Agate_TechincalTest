using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
