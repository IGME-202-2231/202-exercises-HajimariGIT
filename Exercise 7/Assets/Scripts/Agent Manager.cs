using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<agent> agents;

    // Start is called before the first frame update

    public float CountTime = 5;

    public agent ItPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public agent FlockClosestPlayer()
    {
        
        float min = Mathf.Infinity, dis;
        agent nearest = null;


        foreach(agent player in agents)
        {
            if(player != ItPlayer)
            {
                dis = Vector2.Distance(ItPlayer.transform.position, player.transform.position);

                if(dis < min)
                {
                    nearest = player;
                    min = dis;
                }
            }
        }
        return nearest;
    }

    
}



