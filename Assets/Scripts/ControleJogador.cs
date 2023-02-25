using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleJogador : MonoBehaviour {

    public float Velocidade = 10;
    public LayerMask MascaraChao;
    public GameObject TextoPerdeu;
    public bool Vivo = true;

    void Start() {
        Time.timeScale = 1;
    }

    void Update() {
        if (!Vivo & Input.GetButtonDown("Fire1")) {
            SceneManager.LoadScene("game");
        }
    }

    void FixedUpdate() {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        if (direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("Movendo", true);
        } else {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao)) {
            Vector3 posicaoMira = impacto.point - transform.position;
            posicaoMira.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMira);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}
