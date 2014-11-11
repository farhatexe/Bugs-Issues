namespace ProjectTasks.Business.Services.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System;
    using System.Linq;

    [TestClass]
    public class AreaTest
    {
        #region < Members >

        private static TestContext areaTestContext;

        #endregion < Members >

        #region < Properties >

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The requested service.</value>
        private IServices services
        {
            get
            {
                return AreaTest.areaTestContext.Properties["Services"] as IServices;
            }
        }

        #endregion < Properties >
        
        /// <summary>
        /// Initializes the test context setting context properties.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            IServices services = IoCContainer.Default.Resolve<IServices>();

            context.Properties.Add("Services", services);
            AreaTest.areaTestContext = context;

        }

        /// <summary>
        /// Gets all test method.
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            Assert.IsTrue(this.services.GetAllAreas().Any());
        }

        /// <summary>
        /// Gets one area that matches specified id.
        /// </summary>
        [TestMethod]
        public void Get()
        {
            var all = this.services.GetAllAreas();
            var area = this.services.GetArea(all.Select(a => a.Id).First());

            Assert.IsInstanceOfType(area, typeof(Area));
            Assert.IsNotNull(area);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        [TestMethod]
        public void Create()
        {
            string expectedLabel = "Test area";

            var area = new Area() { Label = expectedLabel };
            this.services.CreateArea(area);

            var expected = this.services.GetAllAreas().Where(a => a.Label.Equals(expectedLabel)).FirstOrDefault();
            
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Label, expectedLabel);
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        [TestMethod]
        public void Update()
        {
            string expectedLabel = "Test update area";

            this.Create();
            var area = this.services.GetAllAreas().FirstOrDefault();
            area.Label = expectedLabel;

            var expected = this.services.UpdateArea(area);

            Assert.IsNotNull(expected);
            Assert.AreEqual(expected.Label, expectedLabel);
            Assert.IsTrue(expected.UpdateDate > expected.CreationDate);
        }

        /// <summary>
        /// Create fails test method (missing required fields).
        /// </summary>²
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void CreateFail()
        {
            this.services.CreateArea(new Area());
        }
    }
}
