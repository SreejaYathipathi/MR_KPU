using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Coin trigger hit by: {other.name}  tag={other.tag}");

        if (!other.CompareTag("Player")) return;

        GameManager.I.money += value;
        Destroy(gameObject);
    }
}