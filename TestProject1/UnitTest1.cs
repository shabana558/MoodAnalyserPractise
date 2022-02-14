using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserPractise;
using System;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly object factory;

        //MoodAnalyser moodAnalyser;
        //string message = " I am in happy Mood";
        [TestInitialize]
        public void SetUp()
        {
            //moodAnalyser = new MoodAnalyser(message);
        }
        [TestMethod]
        public void TestMethodForHappyMood()

        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForSadMood()

        {
            string expected = "sad";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForNullMood()

        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForCustomizedNullException()

        {
            string expected = "Mood should not be null";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void TestMethodForCustomizedEmptyException()

        {
            string expected = "Mood should not be empty";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(string.Empty);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }

        }
        /// <summary>
        /// Using Reflection-UC4-Default Constructor
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Default_Constructor()
        {
            MoodAnalyser expected = new MoodAnalyser();
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        //Negative Case
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Default_Constructor_No_Class_Found()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        //Negative Case
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Default_Constructor_No_Constructor_Found()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        /// <summary>
        /// Using Reflection-UC5-Parameterized Constructor
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Parameterized_Constructor()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            object actual = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser", message);

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
            actual.Equals(expected);
        }
        //Invalid case
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Parameterized_Class_Invalid()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            object actual = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAna", "MoodAnalyser", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }
        /// <summary>
        /// UC6-Using Reflection-Invoke Method
        /// </summary>
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Method()
        {
            string expected = "happy";
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            string actual = factory.InvokeAnalyserMethod("happy", "AnalyzeMood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [TestCategory("Reflection")]
        public void Reflection_Return_Invalid_Method()
        {
            string expected = "happy";
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            string actual = factory.InvokeAnalyserMethod("happy", "Analyze");

            Assert.AreEqual(expected, actual);
        }

        [TestCategory("Reflection")]
        [TestMethod]
        public void Given_MoodAnalyser_Using_Reflection_Set_Field()
        {
            string value = "Iam in sad mood";
            string fieldName = "message";
            string expected = "I am in sad mood";
            string actual = "";
            try
            {
                // MoodAnalyserFactory=new MoodAnalyserFactory();
                //Act
                actual = factory.SetField(value, fieldName);
            }
            catch (CustomMoodAnalyserException exception)
            {
                //Assert
                throw new Exception(exception.Message);
            }
            Assert.AreEqual(expected, actual);

        }
    }
}
        

    

