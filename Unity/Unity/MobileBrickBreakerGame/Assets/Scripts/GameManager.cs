using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float ballSpeed;
    private Rigidbody rb;

    public GameObject bottomPaddle;
    public GameObject topPaddle;
    public GameObject topBall;
    public GameObject bottomBall;

    private GameObject cloneTopPaddle;
    private GameObject cloneBottomPaddle;
    private GameObject cloneBottomBall;
    private GameObject cloneTopBall;

    public Text bottomScoreText;
    public Text topScoreText;
    public Text victoryText;

    public int topScore = 0;
    public int bottomScore = 0;

    public static GameManager instance = null;
    void Awake() {
        /*
        -At the start of the game, if there is already an instance of the game running, it will Destroy the instance.
        -Call the Setup() function.
        -Set both texts equal to 0 at the start of the game.
        */
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        bottomPaddle.SetActive(true);
        topPaddle.SetActive(true);
        SetUp();
        setTopScoreText();
        setBottomScoreText();
       
    }

    public void SetUp(){
        /**
        Instantiate both paddles, and their childs.
        */
        cloneBottomPaddle = Instantiate(bottomPaddle, transform.position, Quaternion.Euler( new Vector3(180,0,0))) as GameObject;
        cloneTopPaddle = Instantiate(topPaddle, transform.position, Quaternion.identity) as GameObject;
        
    }
    
    public void CeilingDeathTrigger(){
        /**
        -Destroys the top paddle. 
        -The clone paddle then gets instantiated at the starting position.
        -The bottom score goes up by one and the bottom score text function is called.
        */
        Destroy(cloneTopPaddle);
        cloneTopPaddle = Instantiate(topPaddle, transform.position, Quaternion.identity) as GameObject;
        bottomScore = bottomScore + 1;
        setBottomScoreText();
        setVictoryText();
    }
    public void BottomDeathTrigger(){
        /**
        -Destroys the bottom paddle.
        -The bottom paddle is instantiated via clone in the starting position.
        -The topscore increments and the top score text function is called.
        */
        
        Destroy(cloneBottomPaddle);
        cloneBottomPaddle = Instantiate(bottomPaddle, transform.position, Quaternion.Euler(new Vector3(180, 0, 0))) as GameObject;
        topScore = topScore + 1;
        setTopScoreText();
        setVictoryText();
    }
    void setBottomScoreText(){
        /** 
        -Sets the bottom score text to the proper score.
        */
        bottomScoreText.text = "Score: " + bottomScore.ToString();

    }
    void setTopScoreText() { 
        /**
           -Sets the top score text to the proper score.
        */    
        topScoreText.text = "Score: " + topScore.ToString();
    }
    void setVictoryText(){
        /**
        -When a certain user gets to 7 score, Display a victory text.
        -The victory text will be random from 5 statements placed in an array.
        */
        System.Random rand = new System.Random();
        string[] victoryComments;
        if(bottomScore == 7)
        {
            bottomPaddle.SetActive(false);
            topPaddle.SetActive(false);
            victoryComments = new string[5]{ "Red Team Wins!", "Come on, Blue Team! You can do better!", "Red Team Rocks", "Go Party, Red Team! You Won!", "Red Team All the Way!"};
            victoryText.text = victoryComments[rand.Next(0, 5)];
            victoryText.color = Color.red;
            Invoke("loadNewLevel", 7f);
        }
        else if(topScore == 7)
        {
            bottomPaddle.SetActive(false);
            topPaddle.SetActive(false);
            victoryComments = new string[5] { "Blue Team Wins!", "Come on, Red Team! You can do better!", "Blue Team Rocks", "Go Party, Blue Team! You Won!", "Blue Team All the Way!" };
            victoryText.text = victoryComments[rand.Next(0, 5)];
            victoryText.color = Color.blue;
            Invoke("loadNewLevel", 7f);
        }
    }
    void loadNewLevel()
    {
       
        Application.LoadLevel(Application.loadedLevel);
    }
}
