using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.Logica;

namespace DefensieTrainer.UnitTests
{
    internal class CreateNewTrainingTests
    {
        [TestFixture]
        public class TrainingServiceTests
        {
            private TrainingCreator _trainingCreator;

            [SetUp]
            public void SetUp()
            {
                _trainingCreator = new TrainingCreator();
            }

            [Test]
            public void GenerateNewTrainingSession_ShouldReturnEmptyList_WhenTrainingsIsNull()
            {
                //Act
                var result = _trainingCreator.GenerateNewTrainingSession(null);

                //Assert
                Assert.IsNotNull(result);
                Assert.IsEmpty(result);
            }

            [Test]
            public void GenerateNewTrainingSession_ShouldReturnEmptyList_WhenTrainingsIsEmpty()
            {
                //Act
                var result = _trainingCreator.GenerateNewTrainingSession(new List<TrainingDto>());

                //Assert
                Assert.IsNotNull(result);
                Assert.IsEmpty(result);
            }

            [Test]
            public void GenerateNewTrainingSession_ShouldGenerateNewTraining_WhenTrainingsAreProvided()
            {
                //Arrange
                var trainings = new List<TrainingDto>
                {
                new TrainingDto { Id = 1, Amount = 1, TimeInSeconds = 600, Meters = 1000, ClusterId = 1, SortTraining = 1, PersonId = 1 },
                new TrainingDto { Id = 2, Amount = 2, TimeInSeconds = 1200, Meters = 2000, ClusterId = 2, SortTraining = 1, PersonId = 1 },
                new TrainingDto { Id = 3, Amount = 3, TimeInSeconds = 1800, Meters = 3000, ClusterId = 5, SortTraining = 1, PersonId = 1 }
                };

                //Act
                var result = _trainingCreator.GenerateNewTrainingSession(trainings);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Count);

                var newTraining = result.First();
                Assert.AreEqual(4, newTraining.Id); 
                Assert.AreEqual("New Training Session", newTraining.Name);
                Assert.AreEqual("Generated training session based on past performance", newTraining.Description);
                Assert.AreEqual(1, newTraining.ClusterId);
                Assert.AreEqual(1, newTraining.SortTraining);
                Assert.AreEqual((int)Math.Ceiling(2 * 1.1), newTraining.Amount); 
                Assert.AreEqual((int)Math.Ceiling(1200 * 1.1), newTraining.TimeInSeconds); 
                Assert.AreEqual((int)Math.Ceiling(2000 * 1.1), newTraining.Meters); 
                Assert.AreEqual(1, newTraining.PersonId);
                Assert.AreEqual(false, newTraining.NeedsFeedback);
                
            }
        }
    }
}
