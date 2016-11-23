using Andtech.Audio;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    public float ballSpeed;
    private Rigidbody rb;
    private bool ballInPlay;

    public GameObject brickParticle;

	private float dotThreshold = 0.8f;
    
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

		bool isBottomBrick = other.gameObject.tag == "BottomBrick";
		bool isTopBrick = other.gameObject.tag == "TopBrick";
		if (isBottomBrick || isTopBrick)
        {
			AudioClip clip = AudioBank.GetSound("mario_ugh");
			AudioPacket2D packet = new AudioPacket2D(clip, 1);
			AudioManager.PlaySound(packet);

			Destroy(Util.FindHighestParent(other.transform, other.gameObject.tag).gameObject);
			var cloneParticle = Instantiate(brickParticle, transform.position, Quaternion.identity);
			ParticleSystem particleSystem = (cloneParticle as GameObject).GetComponent<ParticleSystem>();
			particleSystem.startColor = (isBottomBrick) ? Color.red : Color.blue;
			Destroy(cloneParticle, 0.5f);
        }
		else {
			ContactPoint contact = other.contacts[0];
			Debug.DrawRay(contact.point, 4 * contact.normal, Color.cyan, 1);
			Debug.DrawRay(contact.point, 4 * rb.velocity.normalized, Color.yellow, 0.25f);
			float dot = Vector3.Dot(Vector3.right, rb.velocity.normalized);
			if (Mathf.Abs(dot) >= dotThreshold) {
				Vector3 w = Vector3.ProjectOnPlane(rb.velocity, contact.normal);
				Vector3 bisector = w.normalized + contact.normal;
				rb.velocity = rb.velocity.magnitude * bisector.normalized;
			}
			Debug.DrawRay(contact.point, 4 * rb.velocity.normalized, Color.yellow, 1f);
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
