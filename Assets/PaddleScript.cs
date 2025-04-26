using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");

        float xSpeed = xMovement * speed * Time.deltaTime;

        transform.position += new Vector3(xSpeed, 0, 0);
    }
}
