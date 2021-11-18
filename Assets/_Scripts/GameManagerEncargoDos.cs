using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class GameManagerEncargoDos : MonoBehaviour
{
    public static GameManagerEncargoDos intance;
    public AudioSource musicaFondo;
    public bool canPause = true, gameRunning = true;
    public GameObject screenPause;
    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        gameRunning = true;
        Time.timeScale = 1f;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            ChangedGameRunningState();
        }
    }

    

    
    public void ChangedGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
               
            Time.timeScale = 1f;
            screenPause.SetActive(false);
            musicaFondo.volume *= 2;


        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
            screenPause.SetActive(true);
            musicaFondo.volume /= 2;

        }
    }

    public bool IsGameRunning()
    {
        return gameRunning;
    }
    bool mouseState;
    public void MouseState()
    {
        mouseState = !mouseState;
        if (mouseState)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

    }

}
