using System;
using System.Windows.Forms;
using Ttu.Domain;
using Ttu.Presentation;

namespace Ttu.Library
{
    public partial class LogOnForm : Form
    {

        #region Constructors

        public LogOnForm()
        {
            InitializeComponent();

            Presenter = new PresenterFactory(NullUser.Singleton, NullUnitOfWork.Singleton, null).CreateLogOnPresenter();
        }

        #endregion

        #region Properties

        private LogOnPresenter Presenter { get; set; }

        #endregion

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.LogOn(txtUserId.Text, txtPassword.Text);
                Close();
            }
            catch (BusinessException ex)
            {
                MessageBox.Show(this, ex.Message, "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PersistenceException ex)
            {
                MessageBox.Show(this, string.Format("An persistence error occurred:{0}{0}{1}", Environment.NewLine, ex.Message), "Persistence Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format("An unexpected error occurred:{0}{0}{1}", Environment.NewLine, ex.Message), "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
