using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition_Cave_02_To_Cave_03 : MonoBehaviour
{
    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player")
        {
            //print("Load Scene Main Scene");
            SceneManager.LoadScene("Main Scene");
        }
    }
}
