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
  public void Put_ShouldReturn200Ok()
  {
    // Arrange
    var key = "some-random-key";
    var value = "some-random-value";

    _keyValStoreMock
      .Setup(store => store.Insert(key, value))
      .Returns(true);

    // Act
    var response = _sut.Put(value, key);

    // Assert
    Assert.IsType<CreatedResult>(response);
  }

  [Fact]
  public void Put_WhenKeyExists_ShouldReturn409Conflict()
  {
    // Arrange
    var key = "some-random-key";
    var value = "some-random-value";

    _keyValStoreMock
      .Setup(store => store.Insert(key, value))
      .Returns(false);

    // Act
    var response = _sut.Put(value, key);

    // Assert
    Assert.IsType<ConflictResult>(response);
  }

  [Fact]
  public void Get_ShouldReturn302Redirect()
  {
    // Arrange
    var key = "some-random-key";

    _keyValStoreMock
      .Setup(store => store.Get(key))
      .Returns(true);

    // Act
    var response = _sut.Get(key);

    // Assert
    Assert.IsType<RedirectResult>(response);
  }

  [Fact]
  public void Get_WhenKeyNotFound_ShouldReturn404NotFound()
  {
    // Arrange
    var key = "some-random-key";

    _keyValStoreMock
      .Setup(store => store.Get(key))
      .Returns(false);

    // Act
    var response = _sut.Get(key);

    // Assert
    Assert.IsType<NotFoundResult>(response);
  }

  [Fact]
  public void Delete_ShouldReturn204NoContent()
  {
    // Arrange
    var key = "some-random-key";

    _keyValStoreMock
      .Setup(store => store.Delete(key))
      .Returns(true);

    // Act
    var response = _sut.Delete(key);

    // Assert
    Assert.IsType<NoContentResult>(response);
  }

  [Fact]
  public void Delete_WhenRecordIsDeleted_ShouldReturn404NotFound()
  {
    // Arrange
    var key = "some-random-key";

    _keyValStoreMock
      .Setup(store => store.Delete(key))
      .Returns(false);

    // Act
    var response = _sut.Delete(key);

    // Assert
    Assert.IsType<NotFoundResult>(response);
  }
}