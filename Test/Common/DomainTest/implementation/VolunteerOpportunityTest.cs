using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ttu.Domain;

namespace Ttu.DomainTest.implementation
{
    [TestClass]
    public class VolunteerOpportunityTest
    {
        private VolunteerOpportunity _volunteerOpportunity;

        private static readonly User TestUser = new User()
        {
            Description =  "description",
            EmailAddress = "email",
            FirstName = "First",
            LastName = "Last",
            Location = "here",
            PasswordEncrypted = "Password",
            RecordId = 500,
            UserId = "8000"
        };

        private static readonly Organization TestOrganization = new Organization()
        {
            CreatedBy = TestUser,
            Description = "MyOrg",
            MissionStatement = "Don't be evil",
            Name = "NotGoogle",
            RecordId = 599,
            Website = "www.nowhere.com"
        };

        [TestInitialize]
        public void Setup()
        {
            _volunteerOpportunity = new VolunteerOpportunity(TestUser, TestOrganization);
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_Coverage()
        {
            // pre-conditions
            Assert.AreEqual(TestUser, _volunteerOpportunity.CreatedBy);
            Assert.AreEqual(TestOrganization, _volunteerOpportunity.Organization);
            Assert.AreEqual(0, _volunteerOpportunity.RecordId);
            Assert.AreEqual(string.Empty, _volunteerOpportunity.ProjectName);
            Assert.AreEqual(string.Empty, _volunteerOpportunity.ProjectDescription);
            Assert.AreEqual(DateTime.MinValue, _volunteerOpportunity.StartTime);
            Assert.AreEqual(DateTime.MinValue, _volunteerOpportunity.StopTime);
            Assert.AreEqual(0, _volunteerOpportunity.NumVolunteersNeeded);
            Assert.AreEqual(0, _volunteerOpportunity.MaxNumVolunteers);

            VolunteerOpportunity blankOpportunity = new VolunteerOpportunity();
            Assert.AreEqual(null, blankOpportunity.CreatedBy);
            Assert.AreEqual(null, blankOpportunity.Organization);

            DateTime startTime = DateTime.Now;
            DateTime stopTime = DateTime.Now.AddHours(5);

            _volunteerOpportunity.CreatedBy = TestUser;
            _volunteerOpportunity.Organization = TestOrganization;
            _volunteerOpportunity.RecordId = 502;
            _volunteerOpportunity.ProjectName = "My project";
            _volunteerOpportunity.ProjectDescription = "Super Cool Project";
            _volunteerOpportunity.StartTime = startTime;
            _volunteerOpportunity.StopTime = stopTime;
            _volunteerOpportunity.NumVolunteersNeeded = 5;
            _volunteerOpportunity.MaxNumVolunteers = 1000;

            // post-conditions
            Assert.AreEqual(TestOrganization, _volunteerOpportunity.Organization);
            Assert.AreEqual(502, _volunteerOpportunity.RecordId);
            Assert.AreEqual("My project", _volunteerOpportunity.ProjectName);
            Assert.AreEqual("Super Cool Project", _volunteerOpportunity.ProjectDescription);
            Assert.AreEqual(startTime, _volunteerOpportunity.StartTime);
            Assert.AreEqual(stopTime, _volunteerOpportunity.StopTime);
            Assert.AreEqual(5, _volunteerOpportunity.NumVolunteersNeeded);
            Assert.AreEqual(1000, _volunteerOpportunity.MaxNumVolunteers);
        }


        #endregion

        [TestCleanup]
        public void TearDown()
        {
            
        }

        #region Helper Methods


        #endregion
    }
}