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

        public bool IncreaseQuantity(int num)
        {
            throw new System.NotImplementedException("Tool.IncreaseQuantity() not implemented");
        }

        public bool DecreaseQuantity(int num)
        {
            throw new System.NotImplementedException("Tool.DecreaseQuantity() not implemented");
        }

        public bool AddBorrower(string aBorrower)
        {
            throw new System.NotImplementedException("Tool.AddBorrower() not implemented");
        }

        public bool DeleteBorrower(string aBorrower)
        {
            throw new System.NotImplementedException("Tool.DeleteBorrower() not implemented");
        }

        public bool SearchBorrower(string aBorrower)
        {
            throw new System.NotImplementedException("Tool.SearchBorrower() not implemented");
        }
    }
}