﻿#if UNITY_EDITOR
using GleyUrbanAssets;
using System.Collections.Generic;
using UnityEngine;

namespace GleyUrbanAssets
{
    //Stores all road connections
    public class ConnectionPool : MonoBehaviour
    {
        public List<ConnectionCurve> connectionCurves;

        public void AddConnection(WaypointSettingsBase startPosition, WaypointSettingsBase endPosition, RoadBase fromRoad, int fromIndex, RoadBase toRoad, int toIndex, Vector3 offset)
        {
            if (connectionCurves == null)
            {
                connectionCurves = new List<ConnectionCurve>();
            }
            Path newConnection = new Path(startPosition.transform.position - offset, endPosition.transform.position - offset);
            string name = fromRoad.name + "_" + fromIndex + "->" + toRoad.name + "_" + toIndex;
            Transform connectorsHolder = new GameObject(name).transform;
            connectorsHolder.SetParent(transform);
            connectorsHolder.name = name;
            connectorsHolder.gameObject.tag = Constants.editorTag;
            connectionCurves.Add(new ConnectionCurve(newConnection, fromRoad, fromIndex, toRoad, toIndex, true, connectorsHolder));
        }


        public ConnectionCurve GetLaneConnection(int index)
        {
            return connectionCurves[index];
        }


        public void RemoveConnection(ConnectionCurve curve)
        {
            connectionCurves.Remove(curve);
        }


        public int GetNrOfConnections()
        {
            if (connectionCurves != null)
            {
                return connectionCurves.Count;
            }
            return 0;
        }


        public Path GetCurve(int lane)
        {
            return connectionCurves[lane].curve;
        }


        public int GetLane(int index)
        {
            return connectionCurves[index].fromIndex;
        }


        public Vector3 GetOffset(int index)
        {
            if (connectionCurves[index].fromRoad == null)
            {
                return Vector3.zero;
            }
            return connectionCurves[index].fromRoad.positionOffset;
        }


        public string GetName(int index)
        {
            return connectionCurves[index].name;
        }


        public Transform GetHolder(int index)
        {
            return connectionCurves[index].holder;
        }


        public WaypointSettingsBase GetInConnector(int lane)
        {
            if(connectionCurves[lane].toRoad==null)
            {
                return null;
            }
            try
            {
                return connectionCurves[lane].toRoad.lanes[connectionCurves[lane].toIndex].laneEdges.inConnector;
            }
            catch
            {
                return null;
            }
        }


        public Transform GetOriginRoad(int index)
        {
            return connectionCurves[index].fromRoad.transform;
        }


        public T GetOutConnector<T>(int index) where T : WaypointSettingsBase
        {
            if (connectionCurves[index].fromRoad == null)
                return null;
            try
            {
                return (T)connectionCurves[index].fromRoad.lanes[connectionCurves[index].fromIndex].laneEdges.outConnector;
            }
            catch
            {
                return null;
            }
        }


        public List<ConnectionCurve> ContainsRoad(RoadBase road)
        {
            List<ConnectionCurve> curves = new List<ConnectionCurve>();
            if (connectionCurves != null)
            {
                for (int i = 0; i < connectionCurves.Count; i++)
                {
                    if (connectionCurves[i] != null)
                    {
                        if (connectionCurves[i].toRoad == road || connectionCurves[i].fromRoad == road)
                        {
                            curves.Add(connectionCurves[i]);
                        }
                    }
                }
            }
            return curves;
        }
    }
}
#endif
