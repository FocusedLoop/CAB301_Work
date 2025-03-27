namespace Assignment1
{
    partial class ToolCollection : IToolCollection
    {
        /// <summary>
        /// Storage for the referenced tools in the collection.
        /// </summary>
        private ITool[] mTools = null;

        /// <summary>
        /// Maximum number of tools that can be stored in the collection.
        /// </summary>
        private int mCapacity = 0;

        /// <summary>
        /// Public property that returns the total capacity of the collection.
        /// </summary>
        public int Capacity { get { return mCapacity; } }

        /// <summary>
        /// Property containing the current number of Tools in the collection.
        /// </summary>
        public int Number { get { return mTools.Length; } }

        /// <summary>
        /// Property for read-only access to the tools in the collection.
        /// </summary>
        public ITool[] Tools { get { return mTools; } }

        /// <summary>
        /// Creates a new tool collection with the specified capacity.
        /// The capacity is an upper bound for the number of tools that can be stored
        /// in the collection.
        /// </summary>
        /// <param name="capacity">Maximum number of tools in the collection</param>
        public ToolCollection(int capacity)
        {
            if (capacity < 1)
                throw new System.ArgumentOutOfRangeException("Capacity should be at least 1.");

            // Start with an empty array of no tools.
            mTools = new ITool[0];
            mCapacity = capacity;
        }

        // throw new System.NotImplementedException("ToolCollection.Add() not implemented");
        //add a tool to this tool collection
        //Preconditions:    aTool != null, this tool collection is not full (Number < Capacity), and
        //                  the tool is not in the tool collection
        //Post-conditions:  if the pre-conditions are true, the tool has been added to this tool collection, the tools in this tool collection are still sorted in alphabetical order, New Number = Old Number + 1, and return true;
        //                  otherwise, the tool has not been added to this tool collection, the tools in this tool collection are still sorted in alphabetical order, New Number = Old Number, and return false;
        // t(n) = O(n)
        // Sorted Insertion into an array
        public bool Add(ITool aTool)
        {
            if (aTool != null && !IsFull())
            {
                int index = 0;
                // Compare tools in tool list, count tools with same name
                // Find the position of the tool based on name and create an insert point
                while (index < Number)
                {
                    int comparison = string.Compare(mTools[index].Name, aTool.Name);
                    if (comparison == 0) { return false; }
                    else if (comparison > 0) { break; }
                    index++;
                }
                // Shift tools to make room
                ITool[] updatedmTools = new ITool[mTools.Length + 1];
                for (int i = 0; i < index; i++)
                {
                    updatedmTools[i] = mTools[i];
                }
                updatedmTools[index] = aTool;
                for (int i = index; i < mTools.Length; i++)
                { 
                    updatedmTools[i + 1] = mTools[i];
                }
                mTools = updatedmTools;
                return true;
            }
            return false;
        }

        // throw new System.NotImplementedException("ToolCollection.Clear() not implemented");
        //remove all the tools in this tool collection. 
        //Pre-condition: nil
        //Post-condition: New Number = 0
        // t(n) = O(1)
        public void Clear()
        {
            mTools = new ITool[0];
        }

        // throw new System.NotImplementedException("ToolCollection.Delete() not implemented");
        // t(n) = O(n)
        public bool Delete(ITool aTool)
        {
            if (aTool != null && !IsEmpty())
            {
                int index = 0;
                // Find the tool
                // Index the position
                while (index < Number)
                {
                    int comparison = string.Compare(mTools[index].Name, aTool.Name);
                    if (comparison == 0) { break; }
                    else if (comparison > 0) { return false; }
                    index++;
                }
                ITool[] updatedmTools = new ITool[mTools.Length - 1];
                for (int i = 0; i < index; i++)
                {
                    updatedmTools[i] = mTools[i];
                }
                for (int i = index + 1; i < mTools.Length; i++)
                {
                    updatedmTools[i - 1] = mTools[i];
                }
                mTools = updatedmTools;
                return true;
            }
            return false;
        }

        // throw new System.NotImplementedException("ToolCollection.IsEmpty() not implemented");
        // t(n) = O(1)
        public bool IsEmpty()   
        {
            return Number == 0;
        }

        // throw new System.NotImplementedException("ToolCollection.IsFull() not implemented");
        // t(n) = O(1)
        public bool IsFull()
        {
            return Number == Capacity;

        }

        //throw new System.NotImplementedException("ToolCollection.Search() not implemented");
        // t(n) = O(n)

        // USE BINARY SEARCH
        // Current Sequentail search
        public bool Search(ITool aTool)
        {
            if (aTool == null) { return false; }
            for (int i = 0; i < Number; i++)
            {
                if (aTool.Name == Tools[i].Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
