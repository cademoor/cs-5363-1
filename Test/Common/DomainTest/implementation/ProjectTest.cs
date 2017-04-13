using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class ProjectTest
    {

        private Organization TestOrganization;
        private User TestUser;
        private Project Project;

        [TestInitialize]
        public void Arrange()
        {
            TestUser = new User()
            {
                Description = "description",
                EmailAddress = "email",
                FirstName = "First",
                LastName = "Last",
                Location = "here",
                PasswordEncrypted = "Password",
                RecordId = 500,
                UserId = "8000"
            };

            TestOrganization = new Organization()
            {
                CreatedBy = TestUser,
                Description = "MyOrg",
                MissionStatement = "Don't be evil",
                Name = "NotGoogle",
                RecordId = 599,
                Website = "www.nowhere.com"
            };

            Project = new Project(TestUser);
            Project.Organization = TestOrganization;
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            DateTime today = DateTime.Today;
            // pre-conditions
            Assert.AreEqual(TestUser, Project.CreatedBy);
            Assert.AreEqual(TestOrganization, Project.Organization);
            Assert.AreEqual(0, Project.RecordId);
            Assert.AreEqual(string.Empty, Project.ProjectName);
            Assert.AreEqual(string.Empty, Project.ProjectDescription);
            Assert.AreEqual(today, Project.StartTime.Date);
            Assert.AreEqual(today, Project.StopTime);
            Assert.AreEqual(0, Project.MinimumVolunteers);
            Assert.AreEqual(0, Project.MaximumVolunteers);
            Assert.AreEqual(true, Project.IsCurrent());
            Assert.AreEqual(false, Project.IsPrevious());

            Project blankProject = new Project();
            Assert.AreEqual(null, blankProject.CreatedBy);
            Assert.AreEqual(null, blankProject.Organization);

            DateTime startTime = DateTime.Now.AddDays(-3);
            DateTime stopTime = DateTime.Now.AddDays(-1);

            Project.CreatedBy = TestUser;
            Project.Organization = TestOrganization;
            Project.RecordId = 502;
            Project.ProjectName = "My project";
            Project.ProjectDescription = "Super Cool Project";
            Project.StartTime = startTime;
            Project.StopTime = stopTime;
            Project.MinimumVolunteers = 5;
            Project.MaximumVolunteers = 1000;

            // post-conditions
            Assert.AreEqual(TestOrganization, Project.Organization);
            Assert.AreEqual(502, Project.RecordId);
            Assert.AreEqual("My project", Project.ProjectName);
            Assert.AreEqual("Super Cool Project", Project.ProjectDescription);
            Assert.AreEqual(startTime, Project.StartTime);
            Assert.AreEqual(stopTime, Project.StopTime);
            Assert.AreEqual(5, Project.MinimumVolunteers);
            Assert.AreEqual(1000, Project.MaximumVolunteers);
            Assert.AreEqual(false, Project.IsCurrent());
            Assert.AreEqual(true, Project.IsPrevious());
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {

        }
    }
}