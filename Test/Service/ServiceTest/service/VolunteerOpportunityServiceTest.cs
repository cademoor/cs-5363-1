using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class VolunteerOpportunityServiceTest : AbstractServiceTest
    {

        private VolunteerOpportunityService Service;
        private UserService UserService;
        private OrganizationService OrganizationService;

        [TestInitialize]
        public void SetUp()
        {
            Service = new VolunteerOpportunityService(UnitOfWork);
            UserService = new UserService(UnitOfWork);
            OrganizationService = new OrganizationService(UnitOfWork);

            foreach (IVolunteerOpportunity volunteerOpportunity in UnitOfWork.VolunteerOpportunities.FindAll())
            {
                Service.RemoveVolunteerOpportunity(volunteerOpportunity);
            }

            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainVolunteerOpportunities()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetVolunteerOpportunities().Length);
            Assert.AreEqual(0, Service.GetVolunteerOpportunitiesCreatedBy(User).Length);

            // exercise
            IVolunteerOpportunity volunteerOpportunity1 = CreateVolunteerOpportunity();
            Service.AddVolunteerOpportunity(volunteerOpportunity1);

            IVolunteerOpportunity volunteerOpportunity2 = CreateVolunteerOpportunity();
            Service.AddVolunteerOpportunity(volunteerOpportunity2);

            Service.RemoveVolunteerOpportunity(volunteerOpportunity1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetVolunteerOpportunities().Length);
            Assert.IsNull(Service.GetVolunteerOpportunity(volunteerOpportunity1.RecordId));
            Assert.IsNotNull(Service.GetVolunteerOpportunity(volunteerOpportunity2.RecordId));
            Assert.IsNotNull(Service.GetVolunteerOpportunitiesCreatedBy(User));
        }

        [TestMethod]
        public void TestBlueSky_VolunteerOpportunityOwner()
        {
            // set-up
            IUser user1 = new User("TESTUSER1");
            UserService.AddUser(user1);
            UnitOfWork.Commit();
            UnitOfWork.Abort();
            user1 = UserService.GetUser(user1.RecordId);

            IOrganization org1 = new Organization(user1, "MyOrg");

            // pre-conditions
            Assert.AreEqual(0, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);

            // exercise - create opportunities
            IVolunteerOpportunity previousSubmittedOpportunity = new VolunteerOpportunity(user1, org1);
            previousSubmittedOpportunity.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.VolunteerOpportunities.Add(previousSubmittedOpportunity);

            IVolunteerOpportunity previousApprovedOpportunity = new VolunteerOpportunity(user1, org1);
            previousApprovedOpportunity.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.VolunteerOpportunities.Add(previousApprovedOpportunity);

            IVolunteerOpportunity previousDeniedOpportunity = new VolunteerOpportunity(user1, org1);
            previousDeniedOpportunity.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.VolunteerOpportunities.Add(previousDeniedOpportunity);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // exercise - volunteer
            VolunteerOpportunityApplication previousSubmittedOpportunityApplication = new VolunteerOpportunityApplication(user1, previousSubmittedOpportunity);
            previousSubmittedOpportunityApplication.ChangeStatus(user1, OpportunityApplicationStatus.Submitted);
            VolunteerOpportunityApplication previousApprovedOpportunityApplication = new VolunteerOpportunityApplication(user1, previousApprovedOpportunity);
            previousApprovedOpportunityApplication.ChangeStatus(user1, OpportunityApplicationStatus.Approved);
            VolunteerOpportunityApplication previousDeniedOpportunityApplication = new VolunteerOpportunityApplication(user1, previousDeniedOpportunity);
            previousDeniedOpportunityApplication.ChangeStatus(user1, OpportunityApplicationStatus.Denied);

            UnitOfWork.VolunteerOpportunityApplications.Add(previousSubmittedOpportunityApplication);
            UnitOfWork.VolunteerOpportunityApplications.Add(previousApprovedOpportunityApplication);
            UnitOfWork.VolunteerOpportunityApplications.Add(previousDeniedOpportunityApplication);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            user1 = UserService.GetUser(user1.RecordId);

            previousSubmittedOpportunity = UnitOfWork.VolunteerOpportunities.FindByRecordId(previousSubmittedOpportunity.RecordId);
            previousApprovedOpportunity = UnitOfWork.VolunteerOpportunities.FindByRecordId(previousApprovedOpportunity.RecordId);
            previousDeniedOpportunity = UnitOfWork.VolunteerOpportunities.FindByRecordId(previousDeniedOpportunity.RecordId);

            Assert.AreEqual(1, Service.GetAllApplications(previousSubmittedOpportunity).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousApprovedOpportunity).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousDeniedOpportunity).Length);

            // post-conditions
            Assert.AreEqual(1, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetAllAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);

            Assert.AreEqual(1, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedOpportunities(user1, OpportunityApplicationStatus.Denied).Length);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
            foreach (IVolunteerOpportunity volunteerOpportunity in UnitOfWork.VolunteerOpportunities.FindAll())
            {
                Service.RemoveVolunteerOpportunity(volunteerOpportunity);
            }
            UnitOfWork.Commit();
            UnitOfWork.Abort();

            IUser[] users = UnitOfWork.Users.FindBy(u => u.UserId != USER_ID);
            if (users.Length > 1)
            {
                UserService.RemoveUser(users[0]);
            }
            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Helper Methods

        private IVolunteerOpportunity CreateVolunteerOpportunity()
        {
            return new VolunteerOpportunity(User, Org);
        }

        #endregion

    }
}
