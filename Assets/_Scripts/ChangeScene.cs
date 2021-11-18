using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene intance;
    public int numeroDeEscena;
    public AudioSource musicaFondo;

    public GameObject fondoPantallaDeCarga;
    public Slider slider;

    private void Awake()
    {
        intance = this;
    }
   
    public void CargarNivel(int NumeroDeEscena)
    {
        StartCoroutine(CargarAsync(NumeroDeEscena));
    }
    
    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator CargarAsync(int NumerodeEscena)
    {
        musicaFondo.volume /= 3;
        AsyncOperation Operation = SceneManager.LoadSceneAsync(NumerodeEscena);
       
        fondoPantallaDeCarga.SetActive(true);

        while (!Operation.isDone)
        {
            float Progreso = Mathf.Clamp01(Operation.progress / .9f);
            slider.value = Progreso;

            yield return null;
        }
    }
}