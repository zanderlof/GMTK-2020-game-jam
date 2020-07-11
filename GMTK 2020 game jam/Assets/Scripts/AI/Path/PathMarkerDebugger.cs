using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace AI.Path
{
    public class PathMarkerDebugger : MonoBehaviour
    {
        public bool showConnections = false;

        void DrawConnections()
        {
            var visited = new HashSet<(PathMarker, PathMarker)>();
            foreach (var node in FindObjectsOfType<PathMarker>())
            {
                if (node == null) continue;
                
                foreach (var child in node.connections)
                {
                    if (child == null) continue;
                    
                    // don't draw twice
                    if (visited.Contains((child, node)) || visited.Contains((node, child))) continue;
                    visited.Add((child, node));
                    
                    // change the color based on the special node
                    if (Selection.Contains(child.gameObject) || Selection.Contains(node.gameObject))
                    {
                        Gizmos.color = Color.blue;;
                    }
                    else
                    {
                        Gizmos.color = Color.black;;
                    }
                    Gizmos.DrawLine(node.gameObject.transform.position, child.gameObject.transform.position);
                }
            }
        }
        
        void OnDrawGizmosSelected()
        {
            DrawConnections();
        }

        void OnDrawGizmos()
        {
            if (showConnections)
            {
                DrawConnections();
            }
        }
    }
}