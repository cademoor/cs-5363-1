using Ttu.Service;

namespace Ttu.ServiceTest
{
    public class AbstractServiceTest
    {

        # region Constructors

        public AbstractServiceTest()
        {
            Session = new SessionDecorator(null); // TODO:ACM - initialize/provide nhibernate session
        }

        # endregion

        # region Properties

        protected SessionDecorator Session { get; private set; }

        # endregion

    }
}
