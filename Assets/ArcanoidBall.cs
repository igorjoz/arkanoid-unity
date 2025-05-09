using UnityEngine;

public class ArcanoidBall : MonoBehaviour
{
    //Pr�dko�� pi�ki
    public float speed = 5f;

    //Funkcja nadaj�ca pr�dko��
    public void RunBall()
    {
        //Losowanie kierunku
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().linearVelocity = new Vector3(x * speed, speed, 0f);
    }

    //Zatrzymanie ruchu
    public void StopBall()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        //Uruchomienie na start, potem usuniemy
        //RunBall();
    }

    //Sprawdzenie czy kolidujemy z miejscem zniszczenia
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lose")
        {
            GameManager.instance.EndGame(false);
            Debug.Log("Koniec Gry");
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}