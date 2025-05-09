using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksScript : MonoBehaviour
{
    //Zmienna prywatna, kt�r� mo�na zmienia� w inspektorze
    //Ilo�� �ycia naszej cegie�ki
    [SerializeField]
    int life = 1;

    //Za ka�dym razem jak ona si� zetknie z czym�
    private void OnCollisionEnter(Collision collision)
    {
        //Je�eli ma to tag Ball
        if (collision.gameObject.tag == "Ball")
        {
            //usuawamy jedno �ycie
            life--;
            //Je�eli �ycia s� r�wne lub mniejsze od 0
            if (life <= 0)
            {
                GameManager.instance.bricks.Remove(this.gameObject);
                Destroy(gameObject); //Zniszcz obiekt
            }
        }
    }
}