using System.ComponentModel.DataAnnotations;
using Ttu.Domain;

namespace Ttu.Presentation
{
    public class ProjectApplicationModel
    {

        #region Constructors

        public ProjectApplicationModel()
        {
            
        }

        #endregion

        #region Properties

        public int RecordId { get; set; }

        [StringLength(Constants.PROJECT_APPLICATION_NOTE_MAX_LENGTH)]
        [DataType(DataType.Text)]
        [Display(Name = "Note for the organization")]
        public string Note { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Application status")]
        public ProjectApplicationStatus ProjectApplicationStatus { get; set; }

        public UserModel LastChangeUserModel { get; set; }

        public UserModel UserModel { get; set; }

        public ProjectModel ProjectModel { get; set; }

        #endregion

        #region Public Methods

        public void ApplyTo(IProjectApplication projectApplication)
        {
            IUser lastChangeUser = new User();
            LastChangeUserModel.ApplyTo(lastChangeUser);
            projectApplication.LastChangeStatusUser = lastChangeUser;

            projectApplication.Note = Note;
            projectApplication.RecordId = RecordId;
            projectApplication.Status = ProjectApplicationStatus;

            IUser user = new User();
            UserModel.ApplyTo(user);
            projectApplication.User = user;

            IProject project = new Project();
            ProjectModel.ApplyTo(project);
            projectApplication.Project = project;
        }

        public void CopyFrom(IProjectApplication projectApplication)
        {
            LastChangeUserModel = new UserModel();
            LastChangeUserModel.CopyFrom(projectApplication.LastChangeStatusUser);

            Note = projectApplication.Note;
            RecordId = projectApplication.RecordId;
            ProjectApplicationStatus = projectApplication.Status;

            UserModel = new UserModel();
            UserModel.CopyFrom(projectApplication.User);

            ProjectModel = new ProjectModel();
            ProjectModel.CopyFrom(projectApplication.Project);
        }

        #endregion
    }
}