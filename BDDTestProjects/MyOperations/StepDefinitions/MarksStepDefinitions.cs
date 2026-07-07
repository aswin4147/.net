using System;
using Reqnroll;

namespace MyOperations.StepDefinitions
{
    [Binding]
    public class MarksStepDefinitions
    {
        private int _paper1;
        private int _paper2;
        private int _total;
        private string _message;
        [Given("Paper1 marks are {int}")]
        public void GivenPaper1MarksAre(int marks)
        {
            _paper1 = marks;
        }
        [Given("Paper2 marks are {int}")]
        public void GivenPaper2MarksAre(int marks)
        {
            _paper2 = marks;
        }
        [When("I calculate the total marks")]
        public void WhenICalculateTheTotalMarks()
        {
            if (_paper1 == 50 && _paper2 == 50)
            {
                _total = _paper1 + _paper2;
                _message = string.Empty;
            }
            else
            {
                _message = "Invalid marks";
            }
        }
        [Then("the final result should be {int}")]
        public void ThenTheFinalResultShouldBe(int expected)
        {
            Assert.AreEqual(expected, _total);
        }
        [Then("an {string} message should be displayed")]
        public void ThenAnMessageShouldBeDisplayed(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, _message);
        }

    }
}
