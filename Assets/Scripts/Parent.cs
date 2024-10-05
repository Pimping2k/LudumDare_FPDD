using UnityEngine;

public class Parent : MonoBehaviour
{
    [SerializeField] public GameObject gameObjectWithoutAnimation;
    [SerializeField] public GameObject animatedObject;
    void Start()
    {
        gameObjectWithoutAnimation.transform.SetParent(animatedObject.transform);
    }
}
