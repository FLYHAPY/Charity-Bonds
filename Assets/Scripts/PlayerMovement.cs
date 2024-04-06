using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 vector2 = new Vector2(x * Time.deltaTime, y * Time.deltaTime);

        rb.velocity = vector2.normalized * force;
    } 
}
