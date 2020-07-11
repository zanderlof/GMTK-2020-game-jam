namespace AI.CrewTask
{
    public interface ICrewTask
    {
        
        /**
         * Called when the task starts
         */
        void Start(CrewAI ai);

        /**
         * Updates the task
         *
         * If the task finished returns true, otherwise false
         */
        bool Update(CrewAI ai);
        
    }
}