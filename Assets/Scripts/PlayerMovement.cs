using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 vector2 = new Vector2(x * Time.deltaTime, y * Time.deltaTime);

        rb.velocity = vector2.normalized * force;
    } 
}
