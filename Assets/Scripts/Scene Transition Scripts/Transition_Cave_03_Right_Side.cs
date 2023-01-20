using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_Cave_03_Right_Side : MonoBehaviour
{
    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player")
        {
            //print("Load Scene Cave_02");
            SceneManager.LoadScene("Cave_02");
        }
    }
}
