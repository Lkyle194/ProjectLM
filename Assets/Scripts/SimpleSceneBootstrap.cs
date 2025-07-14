using UnityEngine;

public class SimpleSceneBootstrap : MonoBehaviour
{
    void Start()
    {
        // Create a simple plane as terrain if none exists
        if (GameObject.Find("GeneratedTerrain") == null)
        {
            GameObject terrain = GameObject.CreatePrimitive(PrimitiveType.Plane);
            terrain.name = "GeneratedTerrain";
            terrain.transform.localScale = new Vector3(10, 1, 10);
        }

        // Create player
        GameObject player = new GameObject("Player");
        player.transform.position = new Vector3(0, 1, 0);
        player.AddComponent<CapsuleCollider>();
        var controller = player.AddComponent<CharacterController>();
        var tpController = player.AddComponent<ThirdPersonController>();

        // Create camera rig
        GameObject camHolder = new GameObject("CameraHolder");
        camHolder.transform.position = player.transform.position + new Vector3(0, 2, -4);
        var follow = camHolder.AddComponent<CameraFollow>();
        follow.target = player.transform;
        follow.offset = new Vector3(0, 2, -4);
        var tpCam = camHolder.AddComponent<ThirdPersonCamera>();

        // Camera object
        GameObject camObj = new GameObject("Main Camera");
        camObj.tag = "MainCamera";
        camObj.transform.SetParent(camHolder.transform);
        camObj.transform.localPosition = Vector3.zero;
        camObj.AddComponent<Camera>();

        tpCam.target = player.transform;
        tpCam.cameraTransform = camObj.transform;
        tpController.cameraTransform = camObj.transform;
    }
}
