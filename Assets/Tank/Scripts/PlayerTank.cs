using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{

    public int ammo = 15;
    [SerializeField] float maxTorque = 180;
    [SerializeField] float maxForce = 5;
    [SerializeField] Transform nozzle;
    [SerializeField] GameObject rocket;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Slider healthSlider;

    float torque;
    float force;

    Rigidbody rb;
    Destructable destructable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<Destructable>();
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

        healthSlider.value = destructable.Health;
        if (destructable.Health <= 0)
        {
            GameManager.Instance.SetGameOver();
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
}
