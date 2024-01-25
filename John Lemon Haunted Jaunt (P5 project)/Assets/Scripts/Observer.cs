using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;


    bool m_IsplayerInRange;


    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsplayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
     if (other.transform == player)
        {
            m_IsplayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsplayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;


            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }

        }

        }

}
