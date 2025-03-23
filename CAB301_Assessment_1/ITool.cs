//CAB301 assignment 1 - version A
// Maolin Tang

namespace Assignment1
{
    //The specification of Tool ADT

    //Invariants:   (1) Name is immutable;
    //              (2) Quantity => AvailableQuantity >= 0;
    //              (3) Quantity >= 1

    public interface ITool
    {
        // get the name of this tool
        string Name 
        {
            get;
        }

        //get the quantity of this tool
        int Quantity 
        {
            get;
        }

        //get the quantity of this tool currently available to lend
        //pre-condition: value >= Borrowers.Length, throws ArgumentOutOfRangeException if value < Borrowers.Length
        int AvailableQuantity 
        {
            get;
        }

        //Increase the quantity of this tool
        //Pre-condition: nil
        //Post-conditions:  if num > 0, return true, New Quantity = Old Quantity + num, and New AvailableQuantity = Old AvailableQuantity + num;
        //                  otherwise, return false, New Quantity = Old Quantity, and New AvailableQuantity = Old AvailableQuantity.
        bool IncreaseQuantity(int num);
        // to be implemented by students

        //Decrease the quantity of this tool
        //Pre-condition: nil
        //Post-conditions:  if num > 0 and num <= AvailableQuantity, return true, New Quantity = Old Quantity - num, and New AvailableQuantity = Old AvailableQuantity - num;
        //                  otherwise, return false, New Quantity = Old Quantity, and New AvailableQuantity = Old AvailableQuantity.
        bool DecreaseQuantity(int num);
        // to be implemented by students

        //get all the borrowers who are currently holding this tool
        string[] Borrowers  
        {
            get;
        }

        //add a borrower to the borrower list
        //Pre-conditions:   AvailableQuantity > 0 and aBorrower is not in the borrower list, aBorrower is not an empty string.
        //Post-conditions:  New AvailableQuantity = Old AvailableQuantity - 1, the borrower has been added into the borrower list, and return true;
        //                  otherwise, the borrower is not added into the borrower list and return false.
        bool AddBorrower(string aBorrower);
        // to be implemented by students

        //remove a borrower from the borrower list
        //Pre-condition:   aBorrower is in the borrower list, aBorrower is not an empty string.
        //Post-conditions:  New AvailableQuantity = Old AvailableQuantity + 1, the borrower has been removed from the borrower list, and return true;
        //                  otherwise, the borrower list remains unchanged and return false.
        bool DeleteBorrower(string aBorrower);
        // to be implemented by students

        //check if a borrower is in the borrower list
        //Pre-condition:   nil.
        //Post-conditions:  retrun true, if aBorrower is in the borrower list; otherwise, return false. 
        //                  New AvailableQuantity = Old AvailableQuantity, and New Quantity = Old Quantity;
        bool SearchBorrower(string aBorrower);
        // to be implemented by students

    }

}
