using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Assertions;


namespace AI.Path
{
    public class PathMarker : MonoBehaviour
    {

        /**
         * These are all the children of this object
         */
        public List<PathMarker> connections;

        /**
         * Contains a list with all path markers on the scene
         */
        public static PathMarker[] AllMarkers { get; private set; } = null;
        
        public void Start()
        {
            // set all markers once
            if (AllMarkers == null)
            {
                AllMarkers = FindObjectsOfType<PathMarker>();
            }
            
            // Make sure all the connections also have us
            foreach (var child in connections)
            {
                // TODO: maybe use hashset instead?
                if (!child.connections.Contains(this))
                {
                    child.connections.Add(this);
                }
            }
        }

        private void BFS()
        {
            
        }
        
        public List<PathMarker> FindPathTo(PathMarker target)
        {
        }

        public static PathMarker FindClosest(Vector3 position)
        {
            float distance = float.MaxValue;
            PathMarker marker = null;
            foreach (var currMarker in AllMarkers)
            {
                float currDist = Vector3.Distance(currMarker.gameObject.transform.position, position);
                if (currDist < distance)
                {
                    distance = currDist;
                    marker = currMarker;
                }
            }
            return marker;
        }
    }
}
