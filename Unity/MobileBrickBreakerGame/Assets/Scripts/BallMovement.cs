using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    public float ballSpeed;
    private Rigidbody rb;
    private bool ballInPlay;
    private Vector3 velocityPos;
    public GameObject brickParticle;
    public GameObject paddle;
    public Vector3 ballPos;

    public Text  bottomScoreText;
    public int bottomScore = 0;
    // Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        bottomScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && ballInPlay == false) {
            rb.AddForce(new Vector3(ballSpeed + ballSpeed, ballSpeed + ballSpeed, 0));
            ballInPlay = true;
            rb.isKinematic = false;
            transform.parent = null;
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Brick")
        {
            var cloneParticle = Instantiate(brickParticle, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(cloneParticle, 0.5f);
            bottomScore++;
            bottomScoreText.text = "Score: " + bottomScore;

        }
        if(other.gameObject.tag == "DeathTrigger")
        {
           
            GameObject cloneBall = gameObject;
            Destroy(cloneBall);
            
            ballInstantiate(cloneBall);   

        }
    }
    void ballInstantiate(GameObject attachedBall)
    {
        
        attachedBall = Instantiate(gameObject, PaddleMovement.position + new Vector3(0,2f,0),Quaternion.identity) as GameObject;
        ballInPlay = false;
        rb.isKinematic = true;
        GameObject clonePaddle = paddle;
        clonePaddle.transform.parent = attachedBall.transform;
    }
}
