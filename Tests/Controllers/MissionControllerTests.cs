
using Microsoft.AspNetCore.Mvc;
using missions.Controllers;
using Moq;
using NUnit.Framework;

namespace missions.Tests
{
    [TestFixture]
    public class MissionControllerTests
    {
        private Mock<IMissionService> _missionServiceMock;
        private MissionController _missionController;

        [SetUp]
        public void Setup()
        {
            _missionServiceMock = new Mock<IMissionService>();
            _missionController = new MissionController(_missionServiceMock.Object);
        }

        [Test]
        public void GetAllMissionsTest()
        {
            var missionsList = new List<Mission>
            {
                new Mission { MissionId = 1, Title = "Test Mission 1", Agent = "Benjamin", Antenna = "Test Antenna 1", Drone = "Drone 1", Location = "HCA Airport"  },
                new Mission { MissionId = 2, Title = "Test Mission 2", Agent = "Benjamin", Antenna = "Test Antenna 2", Drone = "Drone 2", Location = "HCA Airport"  },
            };
            _missionServiceMock.Setup(service => service.GetAll()).Returns(missionsList);

            var result = _missionController.Get() as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;
            var EXPECTED_COUNT = 2;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var missions = result.Value as List<Mission>;
            Assert.IsNotNull(missions);
            Assert.That(EXPECTED_COUNT, Is.EqualTo(missions.Count));
            _missionServiceMock.Verify(service => service.GetAll(), Times.Once);
        }
        [Test]
        public void PostMissionTest()
        {
            var missionCreateRequest = new MissionCreateRequest { Title = "Test Mission", Agent = "Benjamin", Antenna = "Test Antenna", Drone = "Drone1", Location = "HCA Airport" };
            var createdMission = new Mission { MissionId = 1, Title = "Test Mission", Agent = "Benjamin", Antenna = "Test Antenna", Drone = "Drone1", Location = "HCA Airport" };

            _missionServiceMock.Setup(service => service.Create(missionCreateRequest)).Returns(createdMission);
            var result = _missionController.Post(missionCreateRequest) as OkObjectResult;

            // Assertions
            var HTTP_OK = 200;

            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            var mission = result.Value as Mission;

            Assert.IsNotNull(mission);
            Assert.That(createdMission.MissionId, Is.EqualTo(mission.MissionId));
            _missionServiceMock.Verify(service => service.Create(missionCreateRequest), Times.Once);
        }

        [Test]
        public void PutMissionTest()
        {
            int missionId = 1;
            var missionUpdateRequest = new MissionUpdateRequest {};
            var updatedMission = new Mission {};
            _missionServiceMock.Setup(service => service.Update(missionId, missionUpdateRequest)).Returns(updatedMission);

            var result = _missionController.Put(missionId, missionUpdateRequest) as OkObjectResult;

            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));
            var mission = result.Value as Mission;
            Assert.IsNotNull(mission);
            Assert.That(updatedMission.MissionId, Is.EqualTo(mission.MissionId));
            _missionServiceMock.Verify(service => service.Update(missionId, missionUpdateRequest), Times.Once);
        }

        [Test]
        public void DeleteMissionTest()
        {
            int missionId = 1;
            _missionServiceMock.Setup(service => service.Delete(missionId));
            var result = _missionController.Delete(missionId) as OkObjectResult;


            var HTTP_OK = 200;
            Assert.IsNotNull(result);
            Assert.That(HTTP_OK, Is.EqualTo(result.StatusCode));

            _missionServiceMock.Verify(service => service.Delete(missionId), Times.Once);
        }
    }
}