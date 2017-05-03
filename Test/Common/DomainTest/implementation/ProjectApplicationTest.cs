using System;
using System.Security.Permissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class ProjectApplicationTest
    {
        private User TestUser;
        private User LastChangedUser;
        private Project TestProject;
        private ProjectApplication ProjectApplication;

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

            LastChangedUser = new User()
            {
                Description = "other description",
                EmailAddress = "other email",
                FirstName = "other First",
                LastName = "other Last",
                Location = "there",
                PasswordEncrypted = "Password1",
                RecordId = 501,
                UserId = "7000"
            };

            TestProject = new Project()
            {
                CreatedBy = TestUser,
                MaximumVolunteers = 2,
                MinimumVolunteers = 1,
                ProjectDescription = "Test project",
                RecordId = 8001,
                ProjectName = "Test",
                StartTime = DateTime.Today,
                StopTime = DateTime.Today.AddDays(1)
            };

            ProjectApplication = new ProjectApplication();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_ProjectApplication()
        {
            // pre-conditions
            Assert.AreEqual(null, ProjectApplication.LastChangeStatusUser);
            Assert.AreEqual("", ProjectApplication.Note);
            Assert.AreEqual(0, ProjectApplication.RecordId);
            Assert.AreEqual(ProjectApplicationStatus.Submitted, ProjectApplication.Status);
            Assert.AreEqual(null, ProjectApplication.User);
            Assert.AreEqual(null, ProjectApplication.Project);

            // exercise
            ProjectApplication.LastChangeStatusUser = LastChangedUser;
            ProjectApplication.Note = "This is a long note";
            ProjectApplication.RecordId = 1;
            ProjectApplication.Status = ProjectApplicationStatus.Denied;
            ProjectApplication.User = TestUser;
            ProjectApplication.Project = TestProject;

            // post-conditions
            Assert.AreEqual(LastChangedUser, ProjectApplication.LastChangeStatusUser);
            Assert.AreEqual("This is a long note", ProjectApplication.Note);
            Assert.AreEqual(1, ProjectApplication.RecordId);
            Assert.AreEqual(ProjectApplicationStatus.Denied, ProjectApplication.Status);
            Assert.AreEqual(TestUser, ProjectApplication.User);
            Assert.AreEqual(TestProject, ProjectApplication.Project);

        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {

        }
    }
}