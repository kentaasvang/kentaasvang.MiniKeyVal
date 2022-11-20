namespace kentaasvang.MiniKeyVal.UnitTests;

using kentaasvang.MiniKeyVal.Controllers;
using Microsoft.AspNetCore.Mvc;

public class KeyValControllerTest
{
  private KeyValController _sut;
  private Mock<IKeyValStore> _keyValStoreMock;

  public KeyValControllerTest()
  {
    _keyValStoreMock = new Mock<IKeyValStore>(); 

    var loggerMock = Mock.Of<ILogger<KeyValController>>();
    _sut = new KeyValController(loggerMock, _keyValStoreMock.Object);
  }

  [Fact]
  public void Insert_ShouldReturn200Ok()
  {
    // Arrange
    var key = "some-random-key";
    var value = "some-random-value";

    _keyValStoreMock
      .Setup(store => store.InsertOrUpdate(key, value))
      .Returns(true);

    // Act
    var result = _sut.Put(value, key);

    // Assert
    Assert.IsType<OkResult>(result);
  }

  [Fact]
  public void Insert_WhenKeyExists_ShouldReturn409Conflict()
  {
    // Arrange
    var key = "some-random-key";
    var value = "some-random-value";

    _keyValStoreMock
      .Setup(store => store.InsertOrUpdate(key, value))
      .Returns(false);

    // Act
    var result = _sut.Put(value, key);

    // Assert
    Assert.IsType<ConflictResult>(result);
  }
}