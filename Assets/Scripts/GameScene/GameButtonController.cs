using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameButtonController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private CameraControl _cameraControl;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;

    private bool isPaused = false;

    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartButton);
        returnButton.onClick.AddListener(OnReturnButton);
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(OnQuitButton);
        mainMenuButton.onClick.AddListener(OnMainMenuButton);
    }

    private void OnRestartButton()
    {
        Container.sinnerCounter = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void OnMainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Container.MAINMENU);
    }

    private void OnQuitButton()
    {
        Application.Quit();
    }
    
    private void OnReturnButton()
    {
        if (_cameraControl != null)
            StartCoroutine(RotateAndDisableButton());
    }

    IEnumerator RotateAndDisableButton()
    {
        yield return StartCoroutine(_cameraControl.RotateCamera());
        returnButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}