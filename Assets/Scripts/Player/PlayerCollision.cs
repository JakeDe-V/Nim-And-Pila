using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController playerController;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "SolidObject")
        {
            playerController.moveSpeed = 0;
        }
        else
        {
            playerController.moveSpeed = 60;
        }
    }
}
