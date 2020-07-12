using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathfinding : MonoBehaviour
{
    public PathNode targetLocation;
    public PathNode currentLocation;
    public List<PathNode> steps;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
    }

    public void FindPath()
    {
        steps.Add(targetLocation);
        PathNode selectedLocation = targetLocation;
        while(selectedLocation != currentLocation)
        {
            for(int i = 0; i < selectedLocation.neighbors.Count; i++)
            {
                if (Vector2.Distance(selectedLocation.transform.position, currentLocation.transform.position) > Vector2.Distance(selectedLocation.neighbors[i].transform.position, currentLocation.transform.position))
                {
                    selectedLocation = selectedLocation.neighbors[i];
                    steps.Add(selectedLocation);
                }
            }
        }
    }
}
