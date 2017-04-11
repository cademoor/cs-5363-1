using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class VolunteerOpportunityTest
    {
        private VolunteerOpportunity VolunteerOpportunity;

        private User TestUser;

        private Organization TestOrganization;

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

            VolunteerOpportunity = new VolunteerOpportunity(TestUser, TestOrganization);
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            DateTime today = DateTime.Today;
            // pre-conditions
            Assert.AreEqual(TestUser, VolunteerOpportunity.CreatedBy);
            Assert.AreEqual(TestOrganization, VolunteerOpportunity.Organization);
            Assert.AreEqual(0, VolunteerOpportunity.RecordId);
            Assert.AreEqual(string.Empty, VolunteerOpportunity.ProjectName);
            Assert.AreEqual(string.Empty, VolunteerOpportunity.ProjectDescription);
            Assert.AreEqual(today, VolunteerOpportunity.StartTime.Date);
            Assert.AreEqual(today, VolunteerOpportunity.StopTime);
            Assert.AreEqual(0, VolunteerOpportunity.MinimumVolunteers);
            Assert.AreEqual(0, VolunteerOpportunity.MaximumVolunteers);
            Assert.AreEqual(true, VolunteerOpportunity.IsCurrent());
            Assert.AreEqual(false, VolunteerOpportunity.IsPrevious());

            VolunteerOpportunity blankOpportunity = new VolunteerOpportunity();
            Assert.AreEqual(null, blankOpportunity.CreatedBy);
            Assert.AreEqual(null, blankOpportunity.Organization);

            DateTime startTime = DateTime.Now.AddDays(-3);
            DateTime stopTime = DateTime.Now.AddDays(-1);

            VolunteerOpportunity.CreatedBy = TestUser;
            VolunteerOpportunity.Organization = TestOrganization;
            VolunteerOpportunity.RecordId = 502;
            VolunteerOpportunity.ProjectName = "My project";
            VolunteerOpportunity.ProjectDescription = "Super Cool Project";
            VolunteerOpportunity.StartTime = startTime;
            VolunteerOpportunity.StopTime = stopTime;
            VolunteerOpportunity.MinimumVolunteers = 5;
            VolunteerOpportunity.MaximumVolunteers = 1000;

            // post-conditions
            Assert.AreEqual(TestOrganization, VolunteerOpportunity.Organization);
            Assert.AreEqual(502, VolunteerOpportunity.RecordId);
            Assert.AreEqual("My project", VolunteerOpportunity.ProjectName);
            Assert.AreEqual("Super Cool Project", VolunteerOpportunity.ProjectDescription);
            Assert.AreEqual(startTime, VolunteerOpportunity.StartTime);
            Assert.AreEqual(stopTime, VolunteerOpportunity.StopTime);
            Assert.AreEqual(5, VolunteerOpportunity.MinimumVolunteers);
            Assert.AreEqual(1000, VolunteerOpportunity.MaximumVolunteers);
            Assert.AreEqual(false, VolunteerOpportunity.IsCurrent());
            Assert.AreEqual(true, VolunteerOpportunity.IsPrevious());
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
            
        }
    }
}