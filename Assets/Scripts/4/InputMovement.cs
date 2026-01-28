using System;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    [SerializeField] private float speed = 1f;

    private Vector2 direction;

    private void Awake()
    {
        inputReader.moveEvent += OnMove;
    }

    private void OnMove(Vector2 vector)
    {
        direction = vector.normalized;
    }

    void Update()
    {
        if (direction == Vector2.zero) return;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
