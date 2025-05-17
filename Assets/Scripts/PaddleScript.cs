using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [Header("Ruch")]
    public float maxSpeed = 12f;    // maksymalna prędkość
    public float accelTime = 0.1f;   // czas do osiągnięcia prędkości

    [Header("Ograniczenia poziome (ustawiane w Start)")]
    public float xMin;
    public float xMax;

    // wewnętrzne
    float velocity = 0f;  // do SmoothDamp

    void Start()
    {
        // policz granice X na podstawie kamery i szerokości paddle
        float zDist = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, zDist));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, zDist));
        float halfWidth = GetComponent<Renderer>().bounds.extents.x;
        xMin = leftEdge.x + halfWidth;
        xMax = rightEdge.x - halfWidth;
    }

    void Update()
    {
        // 1) pobierz surowy input
        float input = Input.GetAxisRaw("Horizontal");

        // 2) oblicz docelowe przesunięcie (bezclampowane)
        float targetX = transform.position.x + input * maxSpeed * Time.deltaTime;

        // 3) “gładkie” dojście do targetX
        float smoothX = Mathf.SmoothDamp(
            transform.position.x,
            targetX,
            ref velocity,
            accelTime
        );

        // 4) ogranicz do granic
        float clampedX = Mathf.Clamp(smoothX, xMin, xMax);

        // 5) ustaw pozycję
        transform.position = new Vector3(
            clampedX,
            transform.position.y,
            transform.position.z
        );
    }
}
