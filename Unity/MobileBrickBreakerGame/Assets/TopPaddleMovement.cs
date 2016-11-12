using UnityEngine;
using System.Collections;

public class TopPaddleMovement : MonoBehaviour
{
    public float paddleSpeed;
    public static Vector3 position = new Vector3(0, 11.98f, 2.1f);
    // Update is called once per frame
    void Update()
    {
        
        float xPos = transform.position.x + (Input.GetAxis("Vertical") * paddleSpeed);
        position = new Vector3(Mathf.Clamp(xPos, -5.9f, 6.39f), 11.98f, 2.1f);
        transform.position = position;

    }
}
