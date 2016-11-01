using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;
using OSIM.Core.Entities;
using OSIM.Core.Persistence;

namespace OSIM.UnitTests.OSIM.Core
{
    public class when_working_with_the_loginsystem : Specification
    {

        protected Mock<IUser> _user;

        protected override void Establish_context()
        {
            base.Establish_context();
      
            _user= new Mock<IUser>() { UserName = "sist@eal.dk", Password = "!QAZ2wsx" };
            _loginmodule = new LoginModule();
            _loginmodule.login(_user.Object);


        }

    }

    public class and_entering_valid_credentials : when_working_with_the_loginsystem
    {
        private int _result;
        private ItemType _testItemType;
        private int _itemTypeId;

        protected override void Establish_context()
        {
            base.Establish_context();

            var randomNumberGenerator = new Random();
            _itemTypeId = randomNumberGenerator.Next(32000);

            _session.Setup(s => s.Save(_testItemType)).Returns(_itemTypeId);

        }

        protected override void Because_of()
        {
            _result = _itemTypeRepository.Save(_testItemType);
        }

        [Test]
        public void then_the_id_of_the_user_is_returned()
        {
            _result.ShouldEqual(_itemTypeId);
        }
    }
}
