using UnityEngine;

public class Ball : MonoBehaviour
{

    [Range(1, 100), Tooltip("Adjust the speed ;3")]public float speed = 2;

    public GameObject prefab;

    // Constructor equavilant   
    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        Vector3 velocity = Vector3.zero;

        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");

        transform.position += velocity * speed * Time.deltaTime;

        // Creating prefabs

        if (Input.GetKey(KeyCode.Space)) Instantiate(prefab, transform.position + Vector3.up, Quaternion.identity);
    }
}
