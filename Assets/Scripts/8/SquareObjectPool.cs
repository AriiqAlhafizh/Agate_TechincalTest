using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareObjectPool : MonoBehaviour
{
    public static SquareObjectPool Instance { get; private set; }

    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject squarePrefab;

    private const int maxSpawnAttempts = 100;
    private const float spawnCheckRadius = 0.5f;

    [SerializeField] private LayerMask forbiddenLayer;

    private List<GameObject> pool = new List<GameObject>();

    private float minX, maxX, minY, maxY;

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

        setBounds();
    }
    void Start()
    {
        int randomValue = Random.RandomRange(1, 10);
        for (int i = 0; i < randomValue; i++)
        {
            Vector2 randomPoint = GetRandomSafePosition();
            GameObject obj = Instantiate(squarePrefab, randomPoint, Quaternion.identity, this.transform);

            pool.Add(obj);
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
    public Vector2 GetRandomSafePosition()
    {
        Vector2 validPosition = Vector2.zero;
        bool positionFound = false;

        for (int i = 0; i < maxSpawnAttempts; i++)
        {
            Vector2 candidatePos = new Vector2(
                Random.Range(minX + spawnCheckRadius, maxX - spawnCheckRadius), 
                Random.Range(minY + spawnCheckRadius, maxY - spawnCheckRadius)
            );

            Collider2D hit = Physics2D.OverlapCircle(candidatePos, spawnCheckRadius, forbiddenLayer);

            if (hit == null)
            {
                validPosition = candidatePos;
                positionFound = true;
                break; 
            }
        }

        return positionFound ? validPosition : Vector2.zero;
    }
    public GameObject GetPooledObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    public void ReactivateObjectWithDelay()
    {
        StartCoroutine(ReactivateAfterDelay());
    }
    IEnumerator ReactivateAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        GameObject gameObject = GetPooledObject();
        gameObject.transform.position = GetRandomSafePosition();
        gameObject.SetActive(true);
    }
}
