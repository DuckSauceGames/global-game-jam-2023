using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    public SpriteRenderer spi;
    // Start is called before the first frame update
    void Start()
    {
        spi = GetComponent<SpriteRenderer>();
    }

    //public Vector2 speed = new Vector2(5,5);

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(5 * inputX, 5 * inputY, 0);
        //Vector3 movement = new Vector3(inputX, inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        //transform.Rotate();
        if (inputX < 0) {spi.flipX = true;}
        if (inputX > 0) {spi.flipX = false;}
        //Debug.Log($"{speed.x} {speed.y}");
    }
}
