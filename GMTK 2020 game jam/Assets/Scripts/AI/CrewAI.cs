using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AI.CrewTask;
using AI.Path;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = UnityEngine.Random;

namespace AI
{
    public class CrewAI : MonoBehaviour
    {
        
        /**
         * The marker closest to the crew member currently
         */
        public PathMarker ClosestMarker { get; set; }
    
        /**
         * The current path we are going on
         */
        private Queue<ICrewTask> queuedTasks = new Queue<ICrewTask>();
    
        /**
         * The current task we are running
         */
        private ICrewTask currentTask = null;

        /**
         * The speed of the crew member
         */
        public float Speed { get; private set; } = 1.0f;
        
        // Start is called before the first frame update
        void Start()
        {
            // figure closest marker to start with
            ClosestMarker = PathMarker.FindClosest(gameObject.transform.position);
            
            // queue couple of random paths
            var markers = FindObjectsOfType<PathMarker>();
            for (int i = 0; i < 5; i++)
            {
                var marker = markers[Random.Range(0, markers.Length)];
                QueueGoToMarker(marker);
                Debug.Log($"{i}: {marker.gameObject.name}");
            }
        }
    
        void Update()
        {
            // check if we need to get a new task
            if (currentTask == null && queuedTasks.Count != 0)
            {
                currentTask = queuedTasks.Dequeue();
                currentTask.Start(this);
            }
            
            // run the current task
            if (currentTask != null)
            {
                if (currentTask.Update(this))
                {
                    currentTask = null;
                }
            }
        }
    
        /**
         * Tells the crew member to go into another room
         */
        public void QueueTask(ICrewTask task)
        {
            queuedTasks.Enqueue(task);
        }
    
        /**
         * Will tell the crew member to go to the given marker
         * this takes the path marking into account
         */
        public void QueueGoToMarker(PathMarker target)
        {
            QueueTask(new CrewMovementTask(target));
        }
    
    }

}