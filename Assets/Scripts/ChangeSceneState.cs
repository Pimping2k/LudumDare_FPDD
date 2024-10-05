using System.Collections;
using UnityEngine;

public class ChangeSceneState : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] float duration = 10f;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Container.SINNER))
        {
            StartCoroutine(RotateCamera());
        }
    }

    IEnumerator RotateCamera()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _camera.transform.rotation =
                Quaternion.Slerp(_camera.transform.rotation, targetRotation, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _camera.transform.rotation = targetRotation;

        yield return new WaitForSeconds(1f);
    }
}