using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSalud : MonoBehaviour {
    public float Salud = 100;
    public float SaludMax = 100;

    public Image SaludBarra;
    public Text TextoSalud;
    public CanvasGroup PantallaRoja;

    public GameObject Muerto;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (PantallaRoja.alpha > 0) {
            PantallaRoja.alpha -= Time.deltaTime;
        }
        ActualizarInterfaz();

    }
    void ActualizarInterfaz() {
        SaludBarra.fillAmount = Salud / SaludMax;
        TextoSalud.text = "+" + Salud.ToString("f0");
    }
    public void RecibirDanio(float danio) {
        Salud -= danio;
        PantallaRoja.alpha = 1;

        if (Salud <= 0) {
            Instantiate(Muerto);
            Destroy(gameObject);
        }
    }
}
