using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuStart : MonoBehaviour {
    // Start is called before the first frame update
    public Toggle toggle;
    public TMP_Dropdown resolucionDD;
    Resolution[] resoluciones;
    void Start() {
        if (Screen.fullScreen) {
            toggle.isOn = true;
        } else {
            toggle.isOn = false;
        }
        RevisarResolucion();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivarPantallaCompleta(bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
    }
    public void NewGame() {
        SceneManager.LoadScene(1);
    }

    public void CerrarJuego() {
        Application.Quit();
    }

    public void RevisarResolucion() {
        resoluciones = Screen.resolutions;
        resolucionDD.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++) {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width
            && resoluciones[i].height == Screen.currentResolution.height) {
                resolucionActual = i;
            }
        }
        resolucionDD.AddOptions(opciones);
        resolucionDD.value = resolucionActual;
        resolucionDD.RefreshShownValue();
    }

    public void CambiarResolucion(int indiceResolucion) {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
