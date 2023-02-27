using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

    public GameObject Zumbi;
    float contadorTempo = 0;
    public float TempoGerarZumbi = 1;

    // Update is called once per frame
    void Update() {
        contadorTempo = contadorTempo + Time.deltaTime;

        if (contadorTempo >= TempoGerarZumbi) {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }
    }
}
