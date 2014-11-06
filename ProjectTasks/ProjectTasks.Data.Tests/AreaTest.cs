namespace ProjectTasks.Data.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.EF;
    using ProjectTasks.Data.Interfaces;
    using ProjectTasks.Data.Tests.Extensions;
    using System.Linq;

    /// <summary>
    /// Unit Tests for areas (CRUD operations).
    /// </summary>
    [TestClass]
    public class AreaTest
    {
        #region < Members >

        private static TestContext areaTestContext;

        #endregion < Members >

        #region < Properties >

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        private IRepository<Area, ApplicationDataContext> repository
        {
            get
            {
                return AreaTest.areaTestContext.Properties["Repository"] as IRepository<Area, ApplicationDataContext>;
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            IUnitOfWork<ApplicationDataContext> unitOfWork = new UnitOfWork<ApplicationDataContext>(new ApplicationDataContext());
            IRepository<Area, ApplicationDataContext> areaRepository = unitOfWork.GetRepository<Area>();

            context.Properties.Add("Repository", areaRepository);
            AreaTest.areaTestContext = context;
            
        }

        /// <summary>
        /// Cleanups each test removing all areas in DB.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this.repository.All().ToList().ForEach(item => this.repository.Delete(item));
            this.repository.Context.SaveChanges();
        }

        /// <summary>
        /// Creates the area.
        /// </summary>
        [TestMethod]
        public void CreateArea()
        {
            Area parent = new Area() { Label = "Parent 1" };

            this.repository.Add(new Area() { Label = "Area 1", Parent = parent });
            this.repository.Add(new Area() { Label = "Area 2" });
            this.repository.Add(new Area() { Label = "Area 3" });
            this.repository.Add(new Area() { Label = "Area 4" });
            this.repository.Add(new Area() { Label = "Area 5" });

            this.repository.Context.SaveChanges();
            
            // not equal 6 because of possible creation of other items.
            Assert.IsTrue(this.repository.All().Count() > 5);
        }

        /// <summary>
        /// Gets the area.
        /// </summary>
        [TestMethod]
        public void GetArea()
        {
            this.CreateArea();

            var area = this.repository.All().FirstOrDefault();
            Assert.IsNotNull(area);

            var areaWithParent = this.repository.All().Where(a => a.Parent != null).FirstOrDefault();
            Assert.IsNotNull(areaWithParent);
            Assert.IsNotNull(areaWithParent.Parent);
        }

        /// <summary>
        /// Deletes the area.
        /// </summary>
        [TestMethod]
        public void DeleteArea()
        {
            this.CreateArea();

            var allAreas = this.repository.All().ToList();
            var area = allAreas.FirstOrDefault(a => !allAreas.Any(b => b.ParentId == a.Id));

            this.repository.Delete(area);
            this.repository.Context.SaveChanges();

            Assert.AreEqual(this.repository.All().Count(), 5);
        }

        /// <summary>
        /// Updates the area.
        /// </summary>
        [TestMethod]
        public void UpdateArea()
        {
            this.CreateArea();

            string expected = "Update test";

            var area = this.repository.All().FirstOrDefault();
            area.Label = expected;
            this.repository.Update(area);
            this.repository.Context.SaveChanges();

            var updatedArea = this.repository.All().Single(a => a.Id == area.Id);

            Assert.AreEqual(updatedArea.Label, expected);
        }

        /// <summary>
        /// Updates the area with an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException))]
        public void UpdateFailArea()
        {
            this.CreateArea();

            var area2 = this.repository.All().OrderBy(a => a.Label).Skip(3).FirstOrDefault();
            area2.Label = StringExtension.Generate(70);
            this.repository.Update(area2);
            this.repository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}