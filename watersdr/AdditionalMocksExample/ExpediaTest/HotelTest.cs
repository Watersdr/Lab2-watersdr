using System;
using Expedia;
using NUnit.Framework;
using System.Collections.Generic;
using Rhino.Mocks;

namespace ExpediaTest
{
	[TestFixture()]
	public class HotelTest
	{
		private Hotel targetHotel;
		private readonly int NightsToRentHotel = 5;
		private MockRepository mocks;
		
		[SetUp()]
		public void SetUp()
		{
			targetHotel = new Hotel(NightsToRentHotel);
			mocks = new MockRepository();
		}


        [Test()]
        public void TestThatHotelDoesGetRoomOccupantFromTheDatabase()
        {
            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String roomOccupant = "Whale Rider";
            String anotherRoomOccupant = "Raptor Wrangler";

            using (mocks.Record())
            {
                mockDatabase.getRoomOccupant(24);
                LastCall.Return(roomOccupant);
                mockDatabase.getRoomOccupant(1025);
                LastCall.Return(anotherRoomOccupant);
            }
            var target = new Hotel(10);
            target.Database = mockDatabase;
            String result;
            result = target.getRoomOccupant(1025);
            Assert.AreEqual(anotherRoomOccupant, result);
            result = target.getRoomOccupant(24);
            Assert.AreEqual(roomOccupant, result);
        }

        [Test()]
        public void TestThatHotelDoesGetRoomOccupantFromTheDatabaseWithCheck()
        {

            IDatabase mockDatabase = mocks.Stub<IDatabase>();
            String roomOccupant = "Whale Rider";

            using (mocks.Record())
            {
                mockDatabase.isRoomOccupantValid(24);
                LastCall.Return(true);
                mockDatabase.isRoomOccupantValid(11);
                LastCall.Return(false);
                mockDatabase.getRoomOccupant(24);
                LastCall.Return(roomOccupant);
            }
            var target = new Hotel(10);
            target.Database = mockDatabase;
            String result;
            result = target.getRoomOccupantWithCheck(24);
            Assert.AreEqual(roomOccupant, result);

            result = target.getRoomOccupantWithCheck(11);
            Assert.AreEqual("check failed", result);
            mocks.VerifyAll();
        }

        [Test()]
        public void TestThatUpdateOccupandDBIsCalled()
        {
            IDatabase stubDatabase = mocks.Stub<IDatabase>();
            IUpaderService mockService = mocks.DynamicMock<IUpaderService>();

            using (mocks.Record())
            {
                stubDatabase.isRoomOccupantValid(24);
                LastCall.Return(false);

                stubDatabase.isRoomOccupantValid(15);
                LastCall.Return(true);
            }

            var target = new Hotel(10);
            target.Database = stubDatabase;

            target.updateIfInvalid(24, mockService);
            target.updateIfInvalid(15, mockService);
            mocks.VerifyAll();
        }

        #region Don't look here

        //final version of the test using mocks
        public void TestThatHotelDoesGetRoomOccupantFromTheDatabaseWithCheckFinal()
        {
            IDatabase mockDatabase = mocks.DynamicMock<IDatabase>();
            String roomOccupant = "Whale Rider";

            using (mocks.Record())
            {
                mockDatabase.isRoomOccupantValid(24);
                LastCall.Return(true);
                mockDatabase.getRoomOccupant(24);
                LastCall.Return(roomOccupant);
            }
            mocks.ReplayAll();
            var target = new Hotel(10);
            target.Database = mockDatabase;
            String result;
            result = target.getRoomOccupantWithCheck(24);
            Assert.AreEqual(roomOccupant, result);
            mocks.VerifyAll();

        }

        #endregion
    }
}
