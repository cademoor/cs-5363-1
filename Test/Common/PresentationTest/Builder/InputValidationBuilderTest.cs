using NUnit.Framework;
using Ttu.Presentation;

namespace Ttu.PresentationTest
{
    [TestFixture]
    public class InputValidationBuilderTest
    {

        private InputValidationBuilder InputValidationBuilder;

        [SetUp]
        public void SetUp()
        {
            InputValidationBuilder = new InputValidationBuilder();
        }

        # region Blue Sky Tests

        [Test]
        public void TestBlueSky_Alpha_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc", 1, 10, Domain.InputType.Alpha);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_AlphaNumericWithoutDecimal_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123", 1, 10, Domain.InputType.AlphaNumericWithoutDecimal);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_AlphaNumericWithDecimal_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123.50", 1, 10, Domain.InputType.AlphaNumericWithDecimal);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_NumericWithoutDecimal_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "123", 1, 10, Domain.InputType.NumericWithoutDecimal);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_NumericWithDecimal_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "123.50", 1, 10, Domain.InputType.NumericWithDecimal);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_AlphaNumericWithSymbols_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123@", 1, 10, Domain.InputType.AlphaNumericWithSymbols);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        [Test]
        public void TestBlueSky_None_Valid()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "!@#$%^&*()abc123@", 1, 100, Domain.InputType.None);

            // post-conditions
            Assert.IsEmpty(actualValue);
        }

        # endregion

        # region Non Blue Sky Tests

        [Test]
        public void TestNonBlueSky_Alpha_InvalidType()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123", 1, 10, Domain.InputType.Alpha);

            // post-conditions
            Assert.AreEqual("The \"TestField\" must be between 1 and 10 characters and must only contain letters.", actualValue);
        }

        [Test]
        public void TestNonBlueSky_AlphaNumericWithoutDecimal_InvalidType()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123.", 1, 10, Domain.InputType.AlphaNumericWithoutDecimal);

            // post-conditions
            Assert.AreEqual("The \"TestField\" must be between 1 and 10 characters and must only contain letters or numbers.", actualValue);
        }

        [Test]
        public void TestNonBlueSky_AlphaNumericWithDecimal_InvalidType()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "abc123.50@", 1, 10, Domain.InputType.AlphaNumericWithDecimal);

            // post-conditions
            Assert.AreEqual("The \"TestField\" must be between 1 and 10 characters and must only contain letters or numbers or a decimal.", actualValue);
        }

        [Test]
        public void TestNonBlueSky_NumericWithoutDecimal_InvalidType()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "123.", 1, 10, Domain.InputType.NumericWithoutDecimal);

            // post-conditions
            Assert.AreEqual("The \"TestField\" must be between 1 and 10 characters and must only contain numbers.", actualValue);
        }

        [Test]
        public void TestNonBlueSky_NumericWithDecimal_InvalidType()
        {
            // exercise
            string actualValue = InputValidationBuilder.ValidateValue("TestField", "123.50a", 1, 10, Domain.InputType.NumericWithDecimal);

            // post-conditions
            Assert.AreEqual("The \"TestField\" must be between 1 and 10 characters and must only contain numbers or a decimal.", actualValue);
        }

        # endregion

        [TearDown]
        public void TearDown()
        {
        }

        # region Helper Methods



        # endregion

    }
}
