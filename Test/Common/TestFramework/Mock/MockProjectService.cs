using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ttu.Domain;

namespace Ttu.TestFramework
{
    public class MockProjectService : NullProjectService
    {

        #region Constructors

        public MockProjectService()
        {
            MockUnitOfWork = new MockUnitOfWork();
        }

        #endregion

        #region Properties

        public IUnitOfWork MockUnitOfWork { get; set; }

        #endregion

        #region IProjectService Members

        public override void AddProject(IProject project)
        {
            IProject[] projects = GetProjects();
            if (projects.Length == 0)
            {
                project.RecordId = 1;
            }
            else
            {
                project.RecordId = projects.Max(o => o.RecordId) + 1;
            }
            MockUnitOfWork.Projects.Add(project);
        }

        public override IProject GetProject(int recordId)
        {
            return MockUnitOfWork.Projects.FindByRecordId(recordId);
        }

        public override IProject[] GetProjects()
        {
            return MockUnitOfWork.Projects.FindAll();
        }

        public override void RemoveProject(int recordId)
        {
            // guard clause - not found
            IProject project = GetProject(recordId);
            if (project == null)
            {
                return;
            }

            MockUnitOfWork.Projects.Remove(project);
        }

        public override void RemoveProject(IProject project)
        {
            // guard clause - invalid input
            if (project == null)
            {
                return;
            }

            MockUnitOfWork.Projects.Remove(project);
        }

        #endregion

    }
}
