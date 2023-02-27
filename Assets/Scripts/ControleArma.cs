using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject CanoArma;

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(Bala, CanoArma.transform.position, CanoArma.transform.rotation);
        }
    }
}
