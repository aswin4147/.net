using System;
using NUnit.Framework;
using GradeCalculator;

namespace GradeCalculatorTest
{
    public class Tests
    {
        private Course student;

        [SetUp]
        public void Setup()
        {
            student = new Course();
        }

        [TestCase(-1)]
        [TestCase(101)]
        public void AllMarksInvalidMarkTest(double invalidMark)
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => student.Maths = invalidMark);
                Assert.Throws<ArgumentOutOfRangeException>(() => student.English = invalidMark);
                Assert.Throws<ArgumentOutOfRangeException>(() => student.Science = invalidMark);
                Assert.Throws<ArgumentOutOfRangeException>(() => student.Biology = invalidMark);
                Assert.Throws<ArgumentOutOfRangeException>(() => student.History = invalidMark);
            });
        }
        //[Test]
        //public void AllMarksInvalidInputTest()
        //{
        //    Course student = new Course();
        //    float floatNumber = 123.43f;
        //    string stringText = "hello";
        //    string stringNumber1 = "234";
        //    string stringNumber2 = " 94 ";
        //    string stringNumber3 = " 23r4";
        //    string stringNumber4 = "234f";
        //    Assert.Multiple(() =>
        //    {
        //        bool result = double.TryParse(stringNumber4, out double convertedNumber);
        //    });
        //}
        [TestCase(0)]
        [TestCase(55.5)]
        [TestCase(100)]
        [TestCase(89)]
        [TestCase(90)]
        [TestCase(79)]
        [TestCase(99)]
        [TestCase(1)]
        public void AllMarksValidInput(double Mark)
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => student.Maths = Mark, Throws.Nothing);
                Assert.That(() => student.English = Mark, Throws.Nothing);
                Assert.That(() => student.Science = Mark, Throws.Nothing);
                Assert.That(() => student.Biology = Mark, Throws.Nothing);
                Assert.That(() => student.History = Mark, Throws.Nothing);
            });
        }

        [TestCase(0)]
        [TestCase(55.5)]
        [TestCase(100)]
        [TestCase(89)]
        [TestCase(90)]
        [TestCase(79)]
        [TestCase(99)]
        [TestCase(1)]
        public void TotalTest(double Mark)
        {
            student.Maths = Mark;
            student.English = Mark;
            student.Science = Mark;
            student.Biology = Mark;
            student.History = Mark;

            double total = student.Maths + student.English + student.Science + student.Biology + student.History;

            Assert.That(student.Total(), Is.EqualTo(total));
        }

        [TestCase(0)]
        [TestCase(55.5)]
        [TestCase(100)]
        [TestCase(89)]
        [TestCase(90)]
        [TestCase(79)]
        [TestCase(99)]
        [TestCase(1)]
        public void AverageTest(double Mark)
        {
            student.Maths = Mark;
            student.English = Mark;
            student.Science = Mark;
            student.Biology = Mark;
            student.History = Mark;

            double total = student.Maths + student.English + student.Science + student.Biology + student.History;
            double average = total / 5;

            Assert.That(student.Average(), Is.EqualTo(average));
        }

        [TestCase(100, "A")]
        [TestCase(90, "A")]
        [TestCase(99, "A")]
        [TestCase(89, "B")]
        [TestCase(80, "B")]
        [TestCase(81, "B")]
        [TestCase(70, "C")]
        [TestCase(79, "C")]
        [TestCase(75, "C")]
        [TestCase(60, "D")]
        [TestCase(69, "D")]
        [TestCase(65, "D")]
        [TestCase(0, "F")]
        [TestCase(59, "F")]
        [TestCase(1, "F")]
        public void GradeValidTest(double mark, string expected)
        {
            student.Maths = mark;
            student.English = mark;
            student.Science = mark;
            student.Biology = mark;
            student.History = mark;

            Assert.Multiple(() =>
            {
                Assert.That(Course.Grade(student.Maths), Is.EqualTo(expected));
                Assert.That(Course.Grade(student.English), Is.EqualTo(expected));
                Assert.That(Course.Grade(student.Biology), Is.EqualTo(expected));
                Assert.That(Course.Grade(student.Science), Is.EqualTo(expected));
                Assert.That(Course.Grade(student.History), Is.EqualTo(expected));
            });

        }

        [TestCase(-65)]
        [TestCase(-1)]
        [TestCase(101)]
        [TestCase(6767)]
        public void GradeInValidTest(double mark)
        {
            Assert.That(Course.Grade(mark), Is.EqualTo("Invalid Mark"));
        }
    }
}