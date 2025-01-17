using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTank : MonoBehaviour, IDamagable
{

    public int ammo = 15;
    [SerializeField] float maxTorque = 180;
    [SerializeField] float maxForce = 5;
    [SerializeField] Transform nozzle;
    [SerializeField] GameObject rocket;
    [SerializeField] TMP_Text ammoText;

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
        


        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Instantiate(rocket, nozzle.position, nozzle.rotation);
            ammo--;
        }

        ammoText.text = "Ammo: " + ammo.ToString();
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }

    public void ApplyDamage(float damage)
    {

    }
}
