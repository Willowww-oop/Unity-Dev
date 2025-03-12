using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollerController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform view;

    [SerializeField] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;
 
    Rigidbody rb;
    Vector2 movementInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;
        rb.AddForce(movement * speed);
    }

    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public void OnJump()
    {
        if (onGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private bool onGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, Vector3.down * rayLength);

    }
}
