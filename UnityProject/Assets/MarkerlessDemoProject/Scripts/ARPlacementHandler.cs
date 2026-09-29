using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacementHandler : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARAnchorManager anchorManager;
    [SerializeField] private GameObject prefabObject;

    private static List<ARRaycastHit> hits = new();
    private GameObject spawnedObject;

    void OnEnable() => TouchInputHandler.OnTouchedScreen += HandleTouch;
    void OnDisable() => TouchInputHandler.OnTouchedScreen -= HandleTouch;

    // Raycast to the screen position and spawn the prefab if a hit is detected
    private void HandleTouch(Vector2 screenPosition)
    {
        // Make sure we haven't already placed our object.
        //
        // Use the player's touch to find a valid location on a detected plane.
        //
        // Find the actual AR plane associated with our raycast hit.
        //
        // Anchor our selected location to the physical environment.
        //
        // Determine which direction the surface is facing.
        //
        // Spawn our object at the anchor and orient it to the surface.
        //
        // Attach our object to the anchor so it follows the tracked location.
        //
        // Placement is finished, so clean up our plane visualization.
    }

    private void HidePlanes()
    {
        // Stop plane detection and hide any planes we've already found.
    }
}
