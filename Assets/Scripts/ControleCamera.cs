using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour {

    public GameObject Jogador;
    Vector3 distancia;

    // Start is called before the first frame update
    void Start() {
        distancia = transform.position - Jogador.transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = Jogador.transform.position + distancia;
    }
}
