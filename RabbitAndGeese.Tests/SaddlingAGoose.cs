using RabbitAndGeese.Model;
using System;
using Xunit;

namespace RabbitAndGeese.Tests
{
    public class _is_saddled_should_not_accept_another_saddle
    {
        [Fact]

        public void A_goose_and_saddle_of_the_same_size_should_be_compatible()
        {
            //Arrange

            //will need to add a reference to get rabbit
            var bunny = new Rabbit();
            var emotionalState = "Angry and Poop-filled";

            var largeGoose = new Goose
            {
                Name = "Tronothy",
                Sex = Sex.Male,
                Size = Size.Large,
                EmotionalState = emotionalState
            };

            var largeSaddle = new Saddle { Size = Size.Large, InUse = false };
            bunny.OwnedSaddle.Add(largeSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            bunny.SaddleThatGoose(largeGoose, largeSaddle);

            //Assert

            /** var rightsaddle = largeGoose.Saddle == largeSaddle;
            Assert.True(rightsaddle); ONLY FOR REAL BOOLEAN VALUES **/
            Assert.Same(largeSaddle, largeGoose.Saddle);
            Assert.True(largeSaddle.InUse);
            Assert.Equal(emotionalState, largeGoose.EmotionalState);

        }

        [Fact]
        public void A_goose_and_saddle_that_are_not_the_same_size_should_not_be_compatible()
        {
            //Arrange
            var bunny = new Rabbit();
            var largeGoose = new Goose { Name = "Tronothy", Sex = Sex.Male, Size = Size.Large };
            var smallSaddle = new Saddle { Size = Size.Small, InUse = false };
            bunny.OwnedSaddle.Add(smallSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            bunny.SaddleThatGoose(largeGoose, smallSaddle);
            //Assert
            //expect what we arent expecting
            Assert.NotSame(smallSaddle, largeGoose.Saddle);
            Assert.False(smallSaddle.InUse = false);
            Assert.Equal("Distraught by fat shamming", largeGoose.EmotionalState);
        }

        [Fact]

        //Arrange
        public void A_goose_that_is_saddled_should_not_accept_another_saddle()
        {
            var bunny = new Rabbit();
            var emotionalState = "Poop-filled Anger";
            var originalSaddle = new Saddle();
            var largeGoose = new Goose
            {
                Name = "Tronothy",
                Sex = Sex.Male,
                Size = Size.Large,
                EmotionalState = emotionalState,
                Saddle = originalSaddle
            };

            var largeSaddle = new Saddle { Size = Size.Large, InUse = false };
            bunny.OwnedSaddle.Add(largeSaddle);
            bunny.OwnedGeese.Add(largeGoose);

            //Act
            bunny.SaddleThatGoose(largeGoose, largeSaddle);

            //Arrange
            Assert.Equal(originalSaddle, largeGoose.Saddle);
            // Assert.Equal("Exhausted", largeGoose.EmotionalState);
        }

        /** [Theory]
         [InlineData(1,2)]
         public void add_1_number() **/
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(7, 8)]
        [InlineData(12, 13)]
        public void adding_1_to_a_number_adds_1_to_the_number(int firstNumber, int expectedResult)
        {
            //act
            var result = firstNumber + 1;

            //assert 
            Assert.Equal(expectedResult, result);
        }
    }
}
