using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    [SerializeField] float maxTorque = 180;
    [SerializeField] float maxForce = 5;
    [SerializeField] Transform nozzle;
    [SerializeField] GameObject rocket;

    float torque;
    float force;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;
        


        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(rocket, nozzle.position, nozzle.rotation);
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}