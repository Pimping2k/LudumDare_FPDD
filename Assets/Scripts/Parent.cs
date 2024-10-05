using UnityEngine;

public class Parent : MonoBehaviour
{
    [SerializeField] public GameObject gameObjectWithoutAnimation;
    [SerializeField] public GameObject animatedObject;
    void Start()
    {
        // Заставляем объект без анимации следовать за анимированным объектом
        gameObjectWithoutAnimation.transform.SetParent(animatedObject.transform);
    }
}
