using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerLocation : MonoBehaviour
{
    [SerializeField] string LocationName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Script_Player player = other.gameObject.GetComponent<Script_Player>();
            if (player != null)
            {
                player.PlayerLocation = LocationName;
            }
        }
    }
}
