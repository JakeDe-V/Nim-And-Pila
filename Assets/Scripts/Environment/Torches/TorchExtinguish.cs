using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchExtinguish : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] List<GameObject> lights = new List<GameObject>();
    //[SerializeField] GameObject light;

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "EnemyGhost")
        {
            //print("extinguish");

            var emission = collisionParticleSystem.emission;

            emission.enabled = false;
            collisionParticleSystem.Stop();
            collisionParticleSystem.Clear();


            //turn off lights

            foreach (GameObject tempObject in lights)
            {
                tempObject.GetComponent<Light>().enabled = false;
            }

            //light.GetComponent<Light>().enabled = false;
        }
    }
}
