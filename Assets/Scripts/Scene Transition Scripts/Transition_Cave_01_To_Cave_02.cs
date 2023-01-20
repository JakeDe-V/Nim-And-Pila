using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_Cave_01_To_Cave_02 : MonoBehaviour
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
