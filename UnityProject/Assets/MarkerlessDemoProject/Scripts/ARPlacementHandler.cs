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
        if (spawnedObject != null) return;

        if (raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            if (hits.Count == 0) return;

            var hit = hits[0];

            var plane = planeManager.GetPlane(hit.trackableId);

            if (plane == null) return;

            var anchor = anchorManager.AttachAnchor(plane, hit.pose);

            if (anchor == null) return;

            spawnedObject = Instantiate(prefabObject, anchor.transform.position, hit.pose.rotation, anchor.transform);

            HidePlanes();

        }

    }

    private void HidePlanes()
    {
        planeManager.enabled = false;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
