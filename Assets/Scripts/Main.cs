using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Text pontosPlayer1;
    public Text pontosPlayer2;
    public Text contador;

    public GameObject bola;
    public GameObject player1;
    public GameObject player2;

    public AudioSource plin;
    public AudioSource foi;

    void Start()
    {
        StartCoroutine(JogarCoroutine());
    }

    public void Reiniciar()
    {
        bola.transform.position = new Vector3(0, 0, 0);
        bola.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        player1.transform.position = new Vector3(player1.transform.position.x, 0, 0);
        player2.transform.position = new Vector3(player2.transform.position.x, 0, 0);

        StartCoroutine(JogarCoroutine());
    }

    public void SomarPonto(int player)
    {
        if (player == 1)
        {
            pontosPlayer1.text = (int.Parse(pontosPlayer1.text) + 1) + "";
        }
        else
        {
            pontosPlayer2.text = (int.Parse(pontosPlayer2.text) + 1) + "";
        }
    }

    IEnumerator JogarCoroutine()
    {
        yield return new WaitForSeconds(1);
        plin.Play();
        contador.text = "3";
        yield return new WaitForSeconds(1);
        plin.Play();
        contador.text = "2";
        yield return new WaitForSeconds(1);
        plin.Play();
        contador.text = "1";
        yield return new WaitForSeconds(1);
        foi.Play();
        contador.text = "";
        bola.GetComponent<Bola>().jogar();
    }
}
