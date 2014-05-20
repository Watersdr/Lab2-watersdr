using System;
using NUnit.Framework;
using Expedia;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class CarTest
	{	
		private Car targetCar;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetCar = new Car(5);
			mocks = new MockRepository();
		}
		
		[Test()]
		public void TestThatCarInitializes()
		{
			Assert.IsNotNull(targetCar);
		}	
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForFiveDays()
		{
			Assert.AreEqual(50, targetCar.getBasePrice()	);
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForTenDays()
		{
            var target = new Car(10);
			Assert.AreEqual(80, target.getBasePrice());	
		}
		
		[Test()]
		public void TestThatCarHasCorrectBasePriceForSevenDays()
		{
			var target = new Car(7);
			Assert.AreEqual(10*7*.8, target.getBasePrice());
		}
		
		[Test()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestThatCarThrowsOnBadLength()
		{
			new Car(-5);
		}

        [Test()]
        public void TestThatCarGetsCorrectLocation()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();

            String location1 = "Your moms house";
            String location2 = "Rose-Hulman";

            using (mocks.Record())
            {
                mockDatabase.getCarLocation(1);
                LastCall.Return(location1);

                mockDatabase.getCarLocation(2);
                LastCall.Return(location2);
            }

            var target = ObjectMother.BMW();
            target.Database = mockDatabase;

            String result;

            result = target.getCarLocation(1);
            Assert.AreEqual(result, location1);

            result = target.getCarLocation(2);
            Assert.AreEqual(result, location2);
        }

        [Test()]
        public void TestThatCarGetsMileageFromDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();

            mockDatabase.Miles = 20;

            var target = new Car(10);
            target.Database = mockDatabase;

            int mileage = target.Mileage;
            Assert.AreEqual(mileage, mockDatabase.Miles);
        }
	}
}
