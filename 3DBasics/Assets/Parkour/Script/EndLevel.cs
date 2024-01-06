using UnityEngine.UI;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] Text time=null;
    [SerializeField] Text hooks=null;
    GameObject player;
    float timer;
    int hook;    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = Time.time;        
        hook = player.GetComponent<Player>().hookcount;
        hooks.text = "Hooks used: " + hook.ToString();
        time.text = "Total time taken: " + timer.ToString();
    }

    
}
