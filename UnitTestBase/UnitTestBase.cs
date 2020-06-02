using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomaition;

namespace UnitTestBase
{
    [TestClass]
    public class UnitTestBase
    {
        protected DBCommunication DBCommunication = new DBCommunication();
        protected RabbitMQLogics RabbitMQLogics = new RabbitMQLogics();
        protected TestCasesProviderCSV CSVTestsCases = new TestCasesProviderCSV();
        protected TestCasesProviderDB DBTestsCases = new TestCasesProviderDB();
        protected TestCasesProviderGeneral GeneralTestsCases = new TestCasesProviderGeneral();

        [TestInitialize]
        public void Initialize()
        {
            DBCommunication.deleteAllPurchases();
        }
    }
}
