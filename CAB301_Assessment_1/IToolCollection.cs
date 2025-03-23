//CAB301 assignment 1 version A
//Maolin Tang

namespace Assignment1
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    //Invariants:   (1) Number >= 0;
    //              (2) Capacity is immutable
    //              (3) Number <= Capacity
    //              (4) Tools are stored in an array in alphabetical order

    interface IToolCollection
    {
        int Capacity // the maximum number of tools that can be stored in this tool collection
        {
            get;
        }

        int Number // get the number of different tools in this tool collection
        {
            get;
        }

        //add a tool to this tool collection
        //Preconditions:    aTool != null, this tool collection is not full (Number < Capacity), and
        //                  the tool is not in the tool collection
        //Post-conditions:  if the pre-conditions are true, the tool has been added to this tool collection, the tools in this tool collection are still sorted in alphabetical order, New Number = Old Number + 1, and return true;
        //                  otherwise, the tool has not been added to this tool collection, the tools in this tool collection are still sorted in alphabetical order, New Number = Old Number, and return false;
        bool Add(ITool aTool);

        //delete a tool from this tool collection
        //Preconditions:    aTool != null, this tool collection is in this tool collection
        //Post-conditions:  if the pre-conditions are true, the tool has been removed out of this tool collection, the remaining tools in this tool collection are still sorted in alphabetical order, New Number = Old Number - 1, and return true;
        //                  otherwise, New Number = Old Number, and return false.
        bool Delete(ITool aTool);

        //search a tool in this tool collection
        //Pre-condition: nil
        //Post-condition: return true if this tool is in this tool collection; otherwise, return false. This tool collection remains unchanged.
        bool Search(ITool aTool);

        //remove all the tools in this tool collection. 
        //Pre-condition: nil
        //Post-condition: New Number = 0
        void Clear();

        //check if this tool collection is empty
        //Pre-condition: nil
        //Post-condition: return true if this tool collection is empty; otherwise, return false. This tool collection remains unchanged. 
        bool IsEmpty();

        //check if this tool collection is full
        //Pre-condition: nil
        //Post-condition: return true if this tool collection is full; otherwise, return false. This tool collection remains unchanged. 
        bool IsFull();
    }
}
