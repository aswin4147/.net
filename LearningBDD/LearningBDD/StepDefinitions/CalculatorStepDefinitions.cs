namespace LearningBDD.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        int number1;
        int number2;

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            number1 = number;
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            number2 = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            int result = number1 + number2;
            ThenTheResultShouldBe(result);
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            Console.WriteLine(result);
        }
    }
}
