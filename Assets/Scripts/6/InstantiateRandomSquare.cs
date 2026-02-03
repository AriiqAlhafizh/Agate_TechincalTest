using UnityEngine;

public class InstantiateRandomSquare : MonoBehaviour
{
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject squarePrefab;

    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        setBounds();
    }

    void Start()
    {
        int randomValue = Random.Range(1, 11);
        for (int i = 0; i < randomValue; i++)
        {
            InstantiateSquareAtRandomPosition();
        }
    }

    void setBounds()
    {
        Collider2D[] colliders = environment.GetComponentsInChildren<Collider2D>();

        Bounds totalBounds = colliders[0].bounds;

        for (int i = 1; i < colliders.Length; i++)
        {
            totalBounds.Encapsulate(colliders[i].bounds);
        }

        minX = totalBounds.min.x;
        maxX = totalBounds.max.x;
        minY = totalBounds.min.y;
        maxY = totalBounds.max.y;
    }

    private void InstantiateSquareAtRandomPosition()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );
        Instantiate(squarePrefab, randomPoint, Quaternion.identity, this.transform);
    }
}
