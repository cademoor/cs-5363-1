using Ttu.Domain;

namespace Ttu.PresentationTest
{
    public class MockUnitOfWork : NullUnitOfWork
    {

        #region Constructors

        public MockUnitOfWork()
        {
            _Contacts = new MockUnitOfWorkRepository<IContact>();
            _Users = new MockUnitOfWorkRepository<IUser>();
        }

        #endregion

        #region Properties

        public override string SessionId { get; set; }
        public override IUser User { get; set; }
        public override IUnitOfWorkRepository<IContact> Contacts { get { return Contacts; } }
        public override IUnitOfWorkRepository<IUser> Users { get { return _Users; } }

        #endregion

        #region Variables

        private IUnitOfWorkRepository<IContact> _Contacts;
        private IUnitOfWorkRepository<IUser> _Users;

        #endregion

        #region Public Methods

        public override void Abort()
        {
        }

        public override void Commit()
        {
        }

        public override void Release()
        {
        }

        #endregion

    }
}
