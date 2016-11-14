using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    public float ballSpeed;
    private Rigidbody rb;
    private bool ballInPlay;

    public GameObject brickParticle;
 
    
	void Awake () {
        /**
        -Create A Rigidbody Component At the Start of the Game.
        */
        rb = GetComponent<Rigidbody>();
	}
	void Update () {
        /*
        -When the Space Bar is pressed, the ball will launch into the field with a force stated.
        -The ball will detach from its parent.
        */
        if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false) {
            rb.AddForce(new Vector3(ballSpeed + ballSpeed, ballSpeed + ballSpeed, 0));
            ballInPlay = true;
            rb.isKinematic = false;
            transform.parent = null;
        }
    }

    void OnCollisionEnter(Collision other) {
        /*
        -If the ball touches a brick, the brick will be destroyed and a particle system will be instantiated.
        -The particle system will also be destroyed after a specific time.
        */
        if (other.gameObject.tag == "Brick")
        {
            Destroy(Util.FindHighestParent(other.transform, "Brick").gameObject);
            var cloneParticle = Instantiate(brickParticle, transform.position, Quaternion.identity);
            Destroy(cloneParticle, 0.5f); 
        }
    }
    void OnTriggerEnter(Collider other) { 
        /*
        -If the ball touches any DeathTrigger, it will call the function from the GameManager Class.
        */
        if(other.gameObject.tag == "CeilingDeathTrigger")
        {
            GameManager.instance.CeilingDeathTrigger();
        }
        if(other.gameObject.tag == "DeathTrigger")
        {
            GameManager.instance.BottomDeathTrigger();
        }
    }    
}
