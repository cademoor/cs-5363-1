using System;
using System.Windows.Forms;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.Library
{
    public partial class AddUserForm : Form
    {

        # region Constructors

        public AddUserForm()
        {
            InitializeComponent();
        }

        # endregion

        # region Event Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        # endregion

        # region Helper Methods

        private void AddUser()
        {
            // temporarily just add a user
            // test code

            IUnitOfWork adHocUnitOfWork = NullUnitOfWork.Singleton;
            try
            {
                adHocUnitOfWork = PresentationEnvironment.Singleton.ServiceFactory.CreateAuthenticationService().CreateAdHocUnitOfWork();
                PresentationEnvironment.Singleton.ServiceFactory.CreateUserService(adHocUnitOfWork).AddUser(CreateUser());
                adHocUnitOfWork.Commit();
            }
            catch
            {
                // do nothing
            }
            finally
            {
                adHocUnitOfWork.Release();
            }
        }

        private IUser CreateUser()
        {
            IUser user = new User();
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Password = txtPassword.Text;
            user.UserId = txtUserId.Text.ToUpper();
            return user;
        }

        # endregion

    }
}
