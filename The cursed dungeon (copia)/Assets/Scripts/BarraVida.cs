using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    public float SaludActual = 100;
    public float SaludMax = 100;

    public Image SaludBarra;
    public CanvasGroup PantallaRoja;

    public GameObject Muerto;

    void Update()
    {
        if (PantallaRoja.alpha > 0)
        {
            PantallaRoja.alpha -= Time.deltaTime;
        }
        ActualizarInterfaz();
    }

    void ActualizarInterfaz()
    {
        SaludBarra.fillAmount = SaludActual / SaludMax;
    }

    public void RecibirDano(float Dano)
    {
        SaludActual -= Dano;
        PantallaRoja.alpha = 1;

        if (SaludActual <= 0)
        {
            Instantiate(Muerto);
            Destroy(gameObject);
        }
    }

}
