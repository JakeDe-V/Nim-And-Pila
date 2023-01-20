using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchCollisions : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] List<GameObject> lights = new List<GameObject>();
    //[SerializeField] GameObject light;

    private void OnTriggerEnter(Collider colliderInfo)
    {
        if(colliderInfo.gameObject.tag == "PlayerTorch")
        {
            //print("torch");

            var emission = collisionParticleSystem.emission;

            emission.enabled = true;
            collisionParticleSystem.Play();

            //turn on lights

            foreach (GameObject tempObject in lights)
            {
                tempObject.GetComponent<Light>().enabled = true;
            }


            //light.GetComponent<Light>().enabled = true;
        }
    }
}
