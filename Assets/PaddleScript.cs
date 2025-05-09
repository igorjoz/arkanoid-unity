using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    //Pr�dko�� naszej paletki
    public float speed = 5f;

    void Update()
    {
        Move();
    }

    //funkcja odpowiedzialna za ruch
    void Move()
    {
        //Pobranie informacji z strza�ek prawo-lewo lub klawiszy a-d w kt�r� stron� si� poruszamy
        //GetAxisRaw zwraca tylko warto�ci -1, 0 i 1, dzi�ki temu pr�dko�� zawsze b�dzie sta�a
        float x = Input.GetAxisRaw("Horizontal");

        //Przeliczamy pr�dko��, kierunek i r�nic� czasu pomi�dzy klatkami
        float speddDir = x * speed * Time.deltaTime;

        //zmieniamy pozycj� naszej paletki
        transform.position += new Vector3(speddDir, 0, 0);

    }
}