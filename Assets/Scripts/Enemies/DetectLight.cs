using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLight : MonoBehaviour
{
    private Vector3 firstObjectPosition;
    private Vector3 secondObjectPosition;
    private RaycastHit hit;
    private float distanceBetweenFirstAndSecondPosition;
    [SerializeField] private Light firstObjectLight;
    [SerializeField] private float firstObjectLightIntensityModifier = 2;
    [SerializeField] private GameObject secondObject;
    [SerializeField] private Light secondObjectLight;
    [SerializeField] private float secondObjectLightRangeModifier = 0.5f;
    [SerializeField] float secondObjectLightHeightFromFloor = 17;
    

    // Update is called once per frame
    void Update()
    {
        
        firstObjectPosition = new Vector3(transform.position.x, secondObjectLightHeightFromFloor, transform.position.z);
        secondObjectPosition = new Vector3(secondObject.transform.position.x, secondObjectLightHeightFromFloor, secondObject.transform.position.z);
        Debug.DrawRay(firstObjectPosition, secondObjectPosition - firstObjectPosition);

        if(Physics.Raycast(firstObjectPosition, secondObjectPosition - firstObjectPosition, out hit))
        {
            if(hit.collider.gameObject.name == secondObject.name)
            {
                distanceBetweenFirstAndSecondPosition = hit.distance;
                //print(distanceBetweenFirstAndSecondPosition + " " + hit.collider.gameObject.name);
                firstObjectLight.intensity = secondObjectLight.intensity * firstObjectLightIntensityModifier * ((secondObjectLight.range * secondObjectLightRangeModifier - distanceBetweenFirstAndSecondPosition)/ secondObjectLight.range * secondObjectLightRangeModifier);
            }
            else
            {
                firstObjectLight.intensity = 0;
            }
        }
    }
        
}