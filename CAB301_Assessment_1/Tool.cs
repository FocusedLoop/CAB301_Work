using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment1
{
    public partial class Tool : ITool
    {
        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        private string mName;

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        private string[] mBorrowers;

        /// <summary>
        /// Private field containing the maximum number of borrowers.
        /// </summary>
        private int mQuantity;

        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        public string Name { get { return mName; } }

        /// <summary>
        /// Represents the quantity of tools that are tracked by this object.
        /// If there were 10 hammers available, then Quantity would return 10 regardless of
        /// how many were currently being borrowed.
        /// </summary>
        public int Quantity { get { return mQuantity; } }

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        public string[] Borrowers { get { return mBorrowers; } }

        /// <summary>
        /// Property containing the current number of borrowers of the tool.
        /// </summary>
        public int AvailableQuantity { get { return mQuantity - mBorrowers.Length; } }

        /// <summary>
        /// Creates a new tool that tracks borrowers, and can be added to a collection.
        /// </summary>
        /// <param name="name">Name of this tool, must be non-empty otherwise ArgumentException is thrown</param>
        /// <param name="quantity">Quantity to make available to borrowers, must be greater than or equal
        /// to 1, otherwise ArgumentOutOfRangeException should be thrown.</param>
        public Tool(string name, int quantity)
        {
            if (name == null || name.Length == 0)
                throw new System.ArgumentException("name must not be a null or empty string");

            if (quantity < 1)
                throw new System.ArgumentOutOfRangeException("Quantity must be at least 1");

            mName = name;
            mBorrowers = new string[0];
            mQuantity = quantity;
        }

        // throw new System.NotImplementedException("Tool.IncreaseQuantity() not implemented");
        // t(n) = O(1)
        public bool IncreaseQuantity(int num)
        {
            if (num <= 0) { return false; }
            mQuantity += num;
            return true;
        }

        // throw new System.NotImplementedException("Tool.DecreaseQuantity() not implemented");
        // t(n) = O(1)
        public bool DecreaseQuantity(int num)
        {
            if (((AvailableQuantity - num) <= 0 && mBorrowers.Length == 0) || ((AvailableQuantity - num) < 0 && mBorrowers.Length != 0) || num <= 0 ) { return false; }
            mQuantity -= num;
            return true;
        }

        // throw new System.NotImplementedException("Tool.AddBorrower() not implemented");
        // t(n) = O(n)
        public bool AddBorrower(string aBorrower)
        {
            if (AvailableQuantity <= 0 || aBorrower == null) { return false; }
            string[] updatedBorrower = new string[mBorrowers.Length + 1];
            for (int i = 0; i < mBorrowers.Length; i++)
            {
                if (mBorrowers[i] == aBorrower) { return false; }
                updatedBorrower[i] = mBorrowers[i];
            }
            updatedBorrower[mBorrowers.Length] = aBorrower;
            mBorrowers = updatedBorrower;
            return true;
        }

        // throw new System.NotImplementedException("Tool.DeleteBorrower() not implemented");
        // IMPROVE
        // t(n) = O(n)
        public bool DeleteBorrower(string aBorrower)
        {
            int index = 0;
            bool found = false;
            if (mBorrowers.Length == 0) { return found; }
            string[] updatedBorrower = new string[mBorrowers.Length - 1];
            for (; index < mBorrowers.Length; index++)
            {
                if (mBorrowers[index] == aBorrower)
                {
                    found = true;
                    break; 
                }
            }
            if (found)
            {
                for (int i = 0; i < index; i++) { updatedBorrower[i] = mBorrowers[i]; }
                for (int j = index + 1; j < mBorrowers.Length; j++)
                {
                    updatedBorrower[j - 1] = mBorrowers[j];
                }
                mBorrowers = updatedBorrower;
                return found;
            }
            else
            {
                return found;
            }
        }

        //throw new System.NotImplementedException("Tool.SearchBorrower() not implemented");
        // REPLACE SEARCH METHOD
        // t(n) = O(n)
        public bool SearchBorrower(string aBorrower)
        {
            if (aBorrower == null) { return false; }
            for (int i = 0; i < mBorrowers.Length; i++)
            {
                if (mBorrowers[i] == aBorrower) { return true; }
            }
            return false;
        }
    }
}