using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //Lo que vamos a seguir con la cámara
    public float speed = 0.5f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; //Posicion deseada en la que se quiere ver
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        smoothPosition.y = 0f; //Se bloquea la posición vertical de la cam a 0
        transform.position = smoothPosition;
    }
}
