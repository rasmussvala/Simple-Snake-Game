using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    public UnityEvent foodCollected;

    private void Start()
    {
        foodCollected.AddListener(GameObject.FindGameObjectWithTag("FoodManager").GetComponent<FoodManager>().SpawnFood);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        
        foodCollected.Invoke();
        Destroy(gameObject);
    }
}