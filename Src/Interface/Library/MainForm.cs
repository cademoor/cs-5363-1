using System;
using System.Windows.Forms;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.Library
{
    public partial class MainForm : Form
    {

        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (ShouldOpenAddUserForm())
            {
                AddUserForm addUserForm = new AddUserForm();
                addUserForm.ShowDialog(this);
            }
            else
            {
                LogOnForm logOnForm = new LogOnForm();
                logOnForm.ShowDialog(this);
            }
        }

        #endregion

        #region Helper Methods

        private bool ShouldOpenAddUserForm()
        {
            // launch user creation form if no users
            // test code

            IUnitOfWork adHocUnitOfWork = NullUnitOfWork.Singleton;
            try
            {
                adHocUnitOfWork = PresentationEnvironment.Singleton.ServiceFactory.CreateAuthenticationService().CreateAdHocUnitOfWork();
                IUser[] users = PresentationEnvironment.Singleton.ServiceFactory.CreateUserService(adHocUnitOfWork).GetUsers();
                return users.Length == 0;
            }
            catch
            {
                // do nothing
            }
            finally
            {
                adHocUnitOfWork.Release();
            }

            return false;
        }

        #endregion

    }
}
