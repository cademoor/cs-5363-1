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

        private IUser User1;
        private IOrganization Org1;

        [TestInitialize]
        public void SetUp()
        {

            Service = new ProjectService(UnitOfWork);
            UserService = new UserService(UnitOfWork);
            OrganizationService = new OrganizationService(UnitOfWork);

            User1 = new User("TESTUSER1");
            UserService.AddUser(User1);
            Org1 = new Organization(User1, "MyOrg");
            OrganizationService.AddOrganization(Org1);

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
            Assert.AreEqual(0, Service.GetProjects(0).Length);
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
            Assert.AreEqual(1, Service.GetProjects(0).Length);
            Assert.IsNull(Service.GetProject(project1.RecordId));
            Assert.IsNotNull(Service.GetProject(project2.RecordId));
            Assert.IsNotNull(Service.GetProjectsCreatedBy(User));
        }

        [TestMethod]
        public void TestBlueSky_ProjectOwner()
        {
            // set-up
            User1 = UserService.GetUser(User1.RecordId);
            Org1 = OrganizationService.GetOrganization(Org1.RecordId);

            // pre-conditions
            Assert.AreEqual(0, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);

            // exercise - create opportunities
            IProject previousSubmittedProject = new Project(User1);
            previousSubmittedProject.Organization = Org1;
            previousSubmittedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousSubmittedProject);

            IProject previousApprovedProject = new Project(User1);
            previousApprovedProject.Organization = Org1;
            previousApprovedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousApprovedProject);

            IProject previousDeniedProject = new Project(User1);
            previousDeniedProject.Organization = Org1;
            previousDeniedProject.StartTime = DateTime.Today.AddDays(-1);
            UnitOfWork.Projects.Add(previousDeniedProject);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            // exercise - volunteer
            ProjectApplication previousSubmittedProjectApplication = new ProjectApplication(User1, previousSubmittedProject);
            previousSubmittedProjectApplication.ChangeStatus(User1, ProjectApplicationStatus.Submitted);
            ProjectApplication previousApprovedProjectApplication = new ProjectApplication(User1, previousApprovedProject);
            previousApprovedProjectApplication.ChangeStatus(User1, ProjectApplicationStatus.Approved);
            ProjectApplication previousDeniedProjectApplication = new ProjectApplication(User1, previousDeniedProject);
            previousDeniedProjectApplication.ChangeStatus(User1, ProjectApplicationStatus.Denied);

            UnitOfWork.ProjectApplications.Add(previousSubmittedProjectApplication);
            UnitOfWork.ProjectApplications.Add(previousApprovedProjectApplication);
            UnitOfWork.ProjectApplications.Add(previousDeniedProjectApplication);

            UnitOfWork.Commit();
            UnitOfWork.Abort();

            User1 = UserService.GetUser(User1.RecordId);

            previousSubmittedProject = UnitOfWork.Projects.FindByRecordId(previousSubmittedProject.RecordId);
            previousApprovedProject = UnitOfWork.Projects.FindByRecordId(previousApprovedProject.RecordId);
            previousDeniedProject = UnitOfWork.Projects.FindByRecordId(previousDeniedProject.RecordId);

            Assert.AreEqual(1, Service.GetAllApplications(previousSubmittedProject).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousApprovedProject).Length);
            Assert.AreEqual(1, Service.GetAllApplications(previousDeniedProject).Length);

            // post-conditions
            Assert.AreEqual(1, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetAllAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(0, Service.GetCurrentAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);

            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Submitted).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Approved).Length);
            Assert.AreEqual(1, Service.GetPreviousAppliedProjects(User1, ProjectApplicationStatus.Denied).Length);
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

            foreach (IOrganization organization in UnitOfWork.Organizations.FindAll())
            {
                OrganizationService.RemoveOrganization(organization);
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
            return new Project(User1) { Organization =  Org1};
        }

        #endregion

    }
}
