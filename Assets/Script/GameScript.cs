using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject player, currPlayer;
    public Vector3 initialPosition;
    private static GameController _instance;
    public bool userHasWon = false;

    public static GameController Instance { get { return _instance; } }


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
            currPlayer = Instantiate(player, new Vector2(0f,0f), Quaternion.identity);

        }
}

    // Start is called before the first frame update
    void Start()
    {
        if(player != null)
        {
            initialPosition = player.transform.position;
            currPlayer = Instantiate(player, new Vector2(9.5f, -1f, 23.1f), Quaternion.identity);

        }
    }

    public void RestartPlayer()
    {
        if (userHasWon)
        {
            Destroy(currPlayer);
            userHasWon = false;
            GameObject.Find("EndText").GetComponent<Text>().text = "";
            currPlayer = Instantiate(player, new Vector2(initialPosition.x, -initialPosition.y), Quaternion.identity);
        }
        else {
            if (player && !currPlayer)
            {
                GameObject.Find("EndText").GetComponent<Text>().text = "";
                currPlayer = Instantiate(player, new Vector2(initialPosition.x, -initialPosition.y), Quaternion.identity);
            }
        }

        //Finally
        Time.timeScale = 1.0f;
}
}
