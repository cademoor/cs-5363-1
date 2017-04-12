using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Ttu.Domain;
using Ttu.Service;

namespace Ttu.ServiceTest.service
{
    [TestClass]
    public class ProjectServiceTest : AbstractServiceTest
    {

        private ProjectService Service;
        private UserService UserService;
        private OrganizationService OrganizationService;

        [TestInitialize]
        public void SetUp()
        {
            Service = new ProjectService(UnitOfWork);
            UserService = new UserService(UnitOfWork);
            OrganizationService = new OrganizationService(UnitOfWork);

            foreach (IProject project in UnitOfWork.Projects.FindAll())
            {
                Service.RemoveProject(project);
            }

            UnitOfWork.Commit();
            UnitOfWork.Abort();
        }

        #region Blue Sky Tests

        [TestMethod]
        public void TestBlueSky_MaintainProjects()
        {
            // pre-conditions
            Assert.AreEqual(0, Service.GetProjects(Org).Length);
            Assert.AreEqual(0, Service.GetProjectsCreatedBy(User).Length);

            // exercise
            IProject project1 = CreateProject();
            Service.AddProject(project1);

            IProject project2 = CreateProject();
            Service.AddProject(project2);

            Service.RemoveProject(project1);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // post-conditions
            Assert.AreEqual(1, Service.GetProjects(Org).Length);
            Assert.IsNull(Service.GetProject(project1.RecordId));
            Assert.IsNotNull(Service.GetProject(project2.RecordId));
            Assert.IsNotNull(Service.GetProjectsCreatedBy(User));
        }

        [TestMethod]
        public void TestBlueSky_ProjectOwner()
        {
            // set-up
            IUser user1 = new User("TESTUSER1");
            UserService.AddUser(user1);
            UnitOfWork.Commit();
            UnitOfWork.Abort();
            user1 = UserService.GetUser(user1.RecordId);

            IOrganization org1 = new Organization(user1, "MyOrg");

            // pre-conditions
            Assert.AreEqual(0, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);

            // exercise - create opportunities
            IProject previousSubmittedProject = new Project(user1, org1);
            previousSubmittedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousSubmittedProject);

            IProject previousApprovedProject = new Project(user1, org1);
            previousApprovedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousApprovedProject);

            IProject previousDeniedProject = new Project(user1, org1);
            previousDeniedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousDeniedProject);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // exercise - volunteer
            ProjectApplication previousSubmittedProjectApplication = new ProjectApplication(user1, previousSubmittedProject);
            previousSubmittedProjectApplication.ChangeStatus(user1, ProjectApplicationStatus.Submitted);
            ProjectApplication previousApprovedProjectApplication = new ProjectApplication(user1, previousApprovedProject);
            previousApprovedProjectApplication.ChangeStatus(user1, ProjectApplicationStatus.Approved);
            ProjectApplication previousDeniedProjectApplication = new ProjectApplication(user1, previousDeniedProject);
            previousDeniedProjectApplication.ChangeStatus(user1, ProjectApplicationStatus.Denied);

            UnitOfWork.ProjectApplications.Add(previousSubmittedProjectApplication);
            UnitOfWork.ProjectApplications.Add(previousApprovedProjectApplication);
            UnitOfWork.ProjectApplications.Add(previousDeniedProjectApplication);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            user1 = UserService.GetUser(user1.RecordId);

            previousSubmittedProject = UnitOfWork.Projects.FindByRecordId(previousSubmittedProject.RecordId);
            previousApprovedProject = UnitOfWork.Projects.FindByRecordId(previousApprovedProject.RecordId);
            previousDeniedProject = UnitOfWork.Projects.FindByRecordId(previousDeniedProject.RecordId);

            Assert.AreEqual(1, Service.GetAllApplications(previousSubmittedProject).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousApprovedProject).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousDeniedProject).Length);

            // post-conditions
            Assert.AreEqual(1, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetAllAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(user1, ProjectApplicationStatus.Denied).Length);
        }

        #endregion

        [TestCleanup]
        public void TearDown()
        {
            foreach (IProject project in UnitOfWork.Projects.FindAll())
            {
                Service.RemoveProject(project);
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

        private IProject CreateProject()
        {
            return new Project(User, Org);
        }

        #endregion

    }
}
