using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneState : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] float duration = 0.5f;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject satanScale;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Container.SINNER))
        {
            StartCoroutine(RotateCamera());
            returnButton.gameObject.SetActive(true);
            satanScale.gameObject.SetActive(true);
        }
    }

    IEnumerator RotateCamera()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
        Quaternion initialRotation = _camera.transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _camera.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _camera.transform.rotation = targetRotation;
    }
}