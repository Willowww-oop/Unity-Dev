using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float sensitivity = 1; 
    [SerializeField, Range(2, 10)] float distance;

    InputAction lookAction;
    Vector2 lookInput;
    Vector3 rotation = Vector3.zero; // x = pitch, y = yaw, z = roll

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        lookAction.performed += Look;
        lookAction.canceled += Look;

        Quaternion quaternion = Quaternion.LookRotation(target.position - transform.position);
        rotation.x = quaternion.eulerAngles.x;
        rotation.y = quaternion.eulerAngles.y;
    }

    void Update()
    {
        rotation.x += lookInput.x * sensitivity;
        rotation.y += lookInput.y * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, 20, 80);
        Quaternion qrotation = Quaternion.Euler(rotation);

        transform.position = target.position + qrotation * (Vector3.back * distance);
        transform.rotation = qrotation;
    }

    void Look(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
    }
}
