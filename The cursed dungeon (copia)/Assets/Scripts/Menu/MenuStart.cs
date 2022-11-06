using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour {
    // Start is called before the first frame update
    public Toggle toggle;
    void Start() {
        if (Screen.fullScreen) {
            toggle.isOn = true;
        } else {
            toggle.isOn = false;
        }
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
}
