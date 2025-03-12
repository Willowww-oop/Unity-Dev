    using UnityEditor.Rendering;
using UnityEngine;

public class Tank : MonoBehaviour
{

    [SerializeField] float turnRate = 180;
    [SerializeField] float maxSpeed = 5;
    [SerializeField] GameObject rocket;

    void Start()
    {
        
    }

    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        float speed = Input.GetAxis("Vertical");

        transform.rotation = transform.rotation * Quaternion.AngleAxis(rotation * turnRate * Time.deltaTime, Vector3.up);
        //transform.position += transform.rotation *  Vector3.forward * speed * maxSpeed * Time.deltaTime; 
        transform.Translate(Vector3.forward * speed * maxSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(rocket, transform.position + Vector3.up, transform.rotation);
        }
    }
}
