using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject player, currPlayer;
    public Vector3 initialPosition;
    private static GameScript _instance;
    public bool userHasWon = false;
    public bool userHasPowerUp = false;

    public static GameScript Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            initialPosition = player.transform.position;
            currPlayer = Instantiate(player, new Vector2(-1.67f, -0.906f), Quaternion.identity);

        }
        

        
    }

    void Update(){
        //Press ESC to exit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RestartPlayer()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        //Finally
        Time.timeScale = 1.0f;
	}
    
}
