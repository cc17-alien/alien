using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class InitializeMultiplayerMap : MonoBehaviour
{
    [SerializeField]
    AbstractMap _map;

    ILocationProvider _locationProvider;

    void Awake() {
        _map.InitializeOnStart = false;
    }

    protected virtual IEnumerator Start() {
        yield return null;
        _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
        _locationProvider.OnLocationUpdated += OnLocationUpdated; ;
    }

    void OnLocationUpdated(Mapbox.Unity.Location.Location location) {
        _locationProvider.OnLocationUpdated -= OnLocationUpdated;

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1) {
            _map.Initialize(location.LatitudeLongitude, _map.AbsoluteZoom);

            Hashtable newRoomSettings = new Hashtable();
            newRoomSettings.Add("mapLat", location.LatitudeLongitude.x);
            newRoomSettings.Add("mapLong", location.LatitudeLongitude.y);

            PhotonNetwork.CurrentRoom.SetCustomProperties(newRoomSettings);
        } else {
            Hashtable roomSettings = PhotonNetwork.CurrentRoom.CustomProperties;

            Vector2d latLong = new Vector2d(
                (double) roomSettings["mapLat"],
                (double) roomSettings["mapLong"] 
            );
            _map.Initialize(latLong, _map.AbsoluteZoom);
        }
    }
}
