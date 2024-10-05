using System.Collections;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float initialTime = 0f;
    private float timeForDestroy = 5f;

    void Start()
    {
        StartCoroutine(DestroyPeople());
    }
    IEnumerator DestroyPeople()
    {
        while (initialTime < timeForDestroy)
        {
            initialTime += Time.deltaTime;
            yield return null;
        }
        Destroy(this.gameObject);
    }
}