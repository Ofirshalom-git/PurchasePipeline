using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomaition;

namespace UnitTestBase
{
    [TestClass]
    public class UnitTestBase
    {
        protected DBCommunication DBCommunication = new DBCommunication();
        protected RabbitMQLogics RabbitMQLogics = new RabbitMQLogics();
        protected TestCasesProviderCSV CSVTests = new TestCasesProviderCSV();
        protected TestCasesProviderDB DBTests = new TestCasesProviderDB();
        protected TestCasesProviderGeneral GeneralTests = new TestCasesProviderGeneral();

        [TestInitialize]
        public void Initialize()
        {
            DBCommunication.deleteAllPurchases();
        }
    }
}
