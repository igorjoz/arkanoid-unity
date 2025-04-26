using UnityEditor;
using UnityEngine;

public class ArcanoidBall : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        RunBall();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void RunBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(x * speed, speed, 0f);
        //rb.linearVelocity = new Vector3(x * speed, speed, 0f);
    }
    public void StopBall()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "LoseWall")
        {
            // GameManager.instance.EndGame(false);
            Debug.Log("Przegrana!");
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
