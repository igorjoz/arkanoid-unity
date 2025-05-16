using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ArcanoidBall : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    private Rigidbody rb;

    private void Awake() => rb = GetComponent<Rigidbody>();

    public void RunBall()
    {
        float xDir = Random.value < 0.5f ? -1f : 1f;
        Vector3 dir = new Vector3(xDir, 1f, 0f).normalized;
        rb.linearVelocity = dir * speed;
        Debug.Log($"RunBall → rb.velocity = {rb.linearVelocity}");
    }

    public void StopBall()
    {
        //rb.velocity = Vector3.zero;
        //transform.position = new Vector3(0f, -3f, 0f);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Lose")
        {
            GameManager.instance.lives--;
            GameManager.instance.UpdateUI();
            StopBall();
            GameManager.instance.gameRun = false;

            if (GameManager.instance.lives < 0)
            {
                GameManager.instance.EndGame(false);
                GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
