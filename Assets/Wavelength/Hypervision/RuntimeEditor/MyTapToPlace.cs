// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
namespace HoloToolkit.Unity
{
    public class MyTapToPlace : MonoBehaviour
    {
        [Tooltip("Supply a friendly name for the anchor as the key name for the WorldAnchorStore.")]
        public string SavedAnchorFriendlyName = "SavedAnchorFriendlyName";

        private WorldAnchorManager anchorManager;

        private SpatialMappingManager spatialMappingManager;

        public bool placing;

        private void Start()
        {
            anchorManager = WorldAnchorManager.Instance;
            if (anchorManager == null)
            {
                Debug.LogError("This script expects that you have a WorldAnchorManager component in your scene.");
            }

            spatialMappingManager = SpatialMappingManager.Instance;
            if (spatialMappingManager == null)
            {
                Debug.LogError("This script expects that you have a SpatialMappingManager component in your scene.");
            }

            if (anchorManager != null && spatialMappingManager != null)
            {
                anchorManager.AttachAnchor(this.gameObject, SavedAnchorFriendlyName);
            }
            else
            {
                Destroy(this);
            }
        }

        public void OnSelect()
        {
            placing = !placing;

            if (placing)
            {
                spatialMappingManager.DrawVisualMeshes = true;

                Debug.Log(gameObject.name + " : Removing existing world anchor if any.");

                anchorManager.RemoveAnchor(gameObject);
            }
            else
            {
                spatialMappingManager.DrawVisualMeshes = false;
                anchorManager.AttachAnchor(gameObject, SavedAnchorFriendlyName);
            }
        }

        private void Update()
        {
            if (placing)
            {
                var headPosition = Camera.main.transform.position;
                var gazeDirection = Camera.main.transform.forward;

                RaycastHit hitInfo;
                if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                    30.0f, spatialMappingManager.LayerMask))
                {
                    this.transform.position = hitInfo.point;
                }
            }
        }
    }
}
