using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Assertions;


namespace AI.Path
{
    public class PathMarker : MonoBehaviour
    {

        /**
         * Contains a list with all path markers on the scene
         */
        public static PathMarker[] AllMarkers { get; private set; } = null;

        /**
         * The index of this marker in the all markers list
         */
        private int index = -1;

        /**
         * These are all the children of this object
         */
        public List<PathMarker> connections;

        public void Start()
        {
            // set all markers once
            if (AllMarkers == null)
            {
                AllMarkers = FindObjectsOfType<PathMarker>();
            }
            
            // get the index
            index = Array.IndexOf(AllMarkers, this);
            
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

        private bool BFS(PathMarker target, int[] pred, int[] dist)
        {
            var queue = new Queue<PathMarker>();
            var visited = new HashSet<PathMarker>();

            for (int i = 0; i < AllMarkers.Length; i++)
            {
                dist[i] = int.MaxValue;
                pred[i] = -1;
            }
            
            visited.Add(this);
            dist[index] = 0;
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                PathMarker marker = queue.Dequeue();
                foreach (var child in marker.connections)
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        dist[child.index] = dist[marker.index] + 1;
                        pred[child.index] = marker.index;
                        queue.Enqueue(child);
                        
                        if (child == target)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        
        public List<PathMarker> FindPathTo(PathMarker target)
        {
            // trying to get the path to this place
            if (target == this)
            {
                return new List<PathMarker>();
            }
            
            var path = new List<PathMarker>();
            var dist = new int[AllMarkers.Length];
            var pred = new int[AllMarkers.Length];

            if (BFS(target, pred, dist))
            {
                int crawl = target.index;
                path.Add(AllMarkers[crawl]);
                while (pred[crawl] != -1)
                {
                    path.Add(AllMarkers[pred[crawl]]);
                    crawl = pred[crawl];
                }
                
                path.Reverse();
            }
            else
            {
                Debug.LogError($"Failed to find path from `{this.gameObject.name}` to `{target.gameObject.name}`");
            }

            return path;
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
