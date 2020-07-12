using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathfinding : MonoBehaviour
{
    public float moveSpeed;
    public PathNode targetLocation;
    public PathNode currentLocation;
    public List<PathNode> steps;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
    }

    private void FixedUpdate()
    {
        if(currentLocation != targetLocation)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, steps[steps.Count - 1].transform.position, moveSpeed * Time.deltaTime);
            if(this.transform.position == steps[steps.Count - 1].transform.position)
            {
                currentLocation = steps[steps.Count - 1];
                steps.Remove(steps[steps.Count - 1]);
            }
        } 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Door")
        {
            collision.gameObject.GetComponent<Door>().OpenDoor();
        }
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
