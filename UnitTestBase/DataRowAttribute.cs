using System;

namespace UnitTestBase
{
    internal class DataRowAttribute : Attribute
    {
        private string v;

        public DataRowAttribute(string v)
        {
            this.v = v;
        }
    }
}