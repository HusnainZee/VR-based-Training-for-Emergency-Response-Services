﻿using GleyUrbanAssets;
using UnityEngine;

namespace GleyTrafficSystem
{
    public class TrafficWindownNavigationData
    {
        private Road selectedRoad;
        private WaypointSettings selectedWaypoint;
        private GenericIntersectionSettings selectedIntersection;
        private LayerMask roadLayers;

        internal void InitializeData()
        {
            UpdateLayers();
            selectedRoad = null;
        }


        internal Road GetSelectedRoad()
        {
            return selectedRoad;
        }


        internal void SetSelectedRoad(Road road)
        {
            selectedRoad = road;
        }


        internal WaypointSettings GetSelectedWaypoint()
        {
            return selectedWaypoint;
        }


        internal void SetSelectedWaypoint( WaypointSettings waypoint)
        {
            selectedWaypoint = waypoint;
        }


        internal GenericIntersectionSettings GetSelectedIntersection()
        {
            return selectedIntersection;
        }


        internal void SetSelectedIntersection(GenericIntersectionSettings intersection)
        {
            selectedIntersection = intersection;
        }


        internal void UpdateLayers()
        {
            roadLayers = LayerOperations.LoadOrCreateLayers<LayerSetup>(Constants.layerPath).roadLayers;
        }


        internal LayerMask GetRoadLayers()
        {
            return roadLayers;
        }
    }
}
