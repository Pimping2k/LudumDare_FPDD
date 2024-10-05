using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public IEnumerator RotateCamera()
    {
        float duration = 1f;
        float elapsedTime = 0f;

        Quaternion initialRotation = _camera.transform.rotation;

        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        while (elapsedTime < duration)
        {
            _camera.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _camera.transform.rotation = targetRotation;
    }
}