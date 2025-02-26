using UnityEngine;

public class Cat : MonoBehaviour
{
    public Rigidbody2D rb; // Fizik bileşeni
    private Transform forcePoint; // Kuvvetin uygulanacağı nokta
    private Transform targetPoint; // Kuvvetin yönleneceği hedef nokta
    public float forceAmount = 10f; // Kuvvet büyüklüğü

    private void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        ApplyForce();
    }

    void ApplyForce()
    {
        if (forcePoint == null || targetPoint == null) return;

        // Hedef noktaya doğru yön vektörünü hesapla
        Vector2 direction = (targetPoint.position - forcePoint.position).normalized;

        // Belirlenen noktadan, hedefe doğru kuvvet uygula
        rb.AddForceAtPosition(direction * forceAmount, forcePoint.position, ForceMode2D.Impulse);
    }
}
