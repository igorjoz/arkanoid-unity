using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    public int life = 1;

    public void SetBrick(int life)
    {
        this.life = life;

        if (life <= 0)
        {
            Destroy(gameObject);
        }

        SetBrickColor();
    }

    void SetBrickColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color[] colors = { Color.white, Color.blue, Color.red, Color.green };
        int colorIndex = Mathf.Clamp(life - 1, 0, colors.Length);
        renderer.material.color = colors[colorIndex];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            life--;

            if (life <= 0)
            {
                GameManager.instance.bricks.Remove(this.gameObject);
                Destroy(gameObject);
            }

            SetBrickColor();
        }
    }
}
