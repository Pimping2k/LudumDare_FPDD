using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GameButtonController : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private CameraControl _cameraControl;
    private void Start()
    {
        returnButton.onClick.AddListener(OnReturnButton);
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
}
