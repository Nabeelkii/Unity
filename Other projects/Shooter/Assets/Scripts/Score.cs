using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text score;
    public Text totalenemies;
    public Text time;
    public Text total;   
    public int timer = 30;
    GameObject player=null;
    GameObject enemy=null;
    public bool endgame = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " +player.GetComponent<Player>().Score.ToString();
        totalenemies.text = "Enemies: " + enemy.GetComponent<Enemy>().enemies.ToString();        
        total.text = "Total enemies: " + enemy.GetComponent<Enemy>().total.ToString();
        if (Time.time>timer)
        {            
            endgame = true;            
        }
        else
        {
            float tempTime = Time.time;
            tempTime = Mathf.RoundToInt(Time.time);
            tempTime = timer - tempTime;
            time.text = "Time left: " + tempTime.ToString();
        }
        GameOver();
    }

    void GameOver()
    {
        if(endgame)
        {
            Time.timeScale = 0;            
            score.transform.localPosition = Vector3.zero;
            score.fontSize = 45;
            player.GetComponent<Player>().move = false;
        }
    }
}
