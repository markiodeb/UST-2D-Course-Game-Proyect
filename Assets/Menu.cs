using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void Patrullaje()
    {
        SceneManager.LoadScene(1);
    }

    public void Disparos()
    {
        SceneManager.LoadScene(2);
    }

    public void Efectos()
    {
        SceneManager.LoadScene(3);
    }

    public void Eventos()
    {
        SceneManager.LoadScene(4);
    }

    public void MaquinaEstados()
    {
        SceneManager.LoadScene(5);
    }
    public void Salir()
    {
        Debug.Log("Salimos del game");
        Application.Quit();
    }

}
