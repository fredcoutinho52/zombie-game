using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade = 5;

    // Start is called before the first frame update
    void Start() {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    void FixedUpdate() {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if (distancia > 2) {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao.normalized * Velocidade * Time.deltaTime));
            GetComponent<Animator>().SetBool("Atacando", false);
        } else {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }

    void AtacaJogador() {
        Time.timeScale = 0;
        Jogador.GetComponent<ControleJogador>().TextoPerdeu.SetActive(true);
        Jogador.GetComponent<ControleJogador>().Vivo = false;
    }
}
