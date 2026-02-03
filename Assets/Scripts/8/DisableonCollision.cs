using System.Collections;
using UnityEngine;

public class DisableonCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            SquareObjectPool.Instance.ReactivateObjectWithDelay();
        }
    }
}
