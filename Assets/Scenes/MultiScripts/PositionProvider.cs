using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Photon.Pun;

public class PositionProvider : MonoBehaviourPun
{
    bool _isInitialized;

    AbstractMap map;
    ILocationProvider _locationProvider;
    ILocationProvider LocationProvider {
        get {
            if (_locationProvider == null) {
                _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
            }

            return _locationProvider;
        }
    }

    Vector3 _targetPos;

    void Start() {
        LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
    }

    void LateUpdate() {
        if (_isInitialized && photonView.IsMine) {
            map = LocationProviderFactory.Instance.mapManager;

            if (map != null) {
                Debug.Log("Updating position...");
                transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
            }           
        }
    }
}
