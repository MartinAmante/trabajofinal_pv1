using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image Vida;

    public float SaludActual = 100;
    public float SaludMax = 100;

    void Update()
    {
        Vida.fillAmount = SaludActual / SaludMax;
    }
}
