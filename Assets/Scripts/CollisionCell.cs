using UnityEngine;
using UnityEngine.Events;

public class CollisionCell : MonoBehaviour
{
    public UnityEvent collisionDetected;

    private void Start()
    {
        collisionDetected.AddListener(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>()
            .ResetGame);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        collisionDetected.Invoke();
    }
}