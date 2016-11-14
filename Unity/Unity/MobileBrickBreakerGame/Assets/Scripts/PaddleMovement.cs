using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour {
    public float paddleSpeed;
    public static Vector3 position = new Vector3(10, -14f, 2.1f);
    // Update is called once per frame
    void Update(){
        /**
        Making the movement of the bottom paddle only horizontal and have left and right arrow key controls.
        */
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        position = new Vector3(Mathf.Clamp(xPos, -5.9f, 6.39f), -14f, 2.1f);
        transform.position = position;
        
        
    }
}
