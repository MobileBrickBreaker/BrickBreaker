using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives, bricks;
    public GameObject paddle, brickGroup;
    public static GameManager instance = null;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void DestroyBricks()
    {
        bricks--;
    }
    
}
