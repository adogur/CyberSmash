using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    public GameObject finalPos;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos.gameObject.transform.position, 0.1f);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}
