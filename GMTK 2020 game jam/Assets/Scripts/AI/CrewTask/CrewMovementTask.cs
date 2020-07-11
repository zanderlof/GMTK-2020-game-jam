using System.Collections.Generic;
using System.Linq;
using AI.Path;
using UnityEngine;

namespace AI.CrewTask
{
    public class CrewMovementTask : ICrewTask
    {
        
        /**
         * The target of the movement task
         */
        public PathMarker Target { get; private set; }
        
        /**
         * The path we built
         */
        private readonly Queue<(PathMarker, float)> _path = new Queue<(PathMarker, float)>();

        public CrewMovementTask(PathMarker marker)
        {
            Target = marker;
        }
        
        public void Start(CrewAI ai)
        {
            // build out the plan
            foreach (var marker in ai.ClosestMarker.FindPathTo(Target))
            {
                _path.Enqueue((marker, Vector3.Distance(marker.gameObject.transform.position, ai.transform.position)));
            }
        }
        
        public bool Update(CrewAI ai)
        {
            if (_path.Count == 0)
            {
                return true;
            }
            
            // get the item
            var pair = _path.Peek();
            var nextMarker = pair.Item1;
            var nextPosition = nextMarker.gameObject.transform.position;
            var originalDistance = pair.Item2;
            
            // we are now closer to this marker than the other one
            if (originalDistance / 2.0f < Vector3.Distance(ai.gameObject.transform.position, nextPosition))
            {
                ai.ClosestMarker = nextMarker;
            }
            
            // move the object
            ai.transform.position = Vector3.MoveTowards(ai.transform.position, nextPosition, ai.Speed * Time.deltaTime);
            
            // if we are closer than a step size stop
            if (Vector3.Distance(ai.gameObject.transform.position, nextPosition) < ai.Speed * Time.deltaTime)
            {
                // Pop the element and return if we need to check more elements
                _path.Dequeue();
                return _path.Count == 0;
            }
            else
            {
                // we are not finished yet
                return false;
            }
        }

        
    }
}