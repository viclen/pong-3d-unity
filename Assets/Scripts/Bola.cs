using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public float velocidade = 10;
    public GameObject MainCamera;
    float velocidadeatual;
    public AudioSource piu;
    public AudioSource gol;

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 dir = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y).normalized;
        GetComponent<Rigidbody2D>().velocity = dir * velocidadeatual;

        velocidadeatual += 0.1f;

        if (col.gameObject.name == "ParedeDireita")
        {
            // gol player 1
            MainCamera.GetComponent<Main>().SomarPonto(1);
            MainCamera.GetComponent<Main>().Reiniciar();
            if (!gol.isPlaying)
            {
                gol.Play();
            }
        }
        else if (col.gameObject.name == "ParedeEsquerda")
        {
            // gol player 2
            MainCamera.GetComponent<Main>().SomarPonto(2);
            MainCamera.GetComponent<Main>().Reiniciar();
            if (!gol.isPlaying)
            {
                gol.Play();
            }
        }
        else
        {
            if (!piu.isPlaying)
            {
                piu.Play();
            }
        }

    }

    public void jogar()
    {
        velocidadeatual = velocidade;
        float x = Random.Range(0, 10) > 5 ? 1 : -1;
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, Random.Range(-1, 1)) * velocidadeatual;
    }
}
