using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.User;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void SendMessage_ShouldNotRead_WhenSendToUser()
    {
        // Arrange
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.Important, DateTime.Today);
        var user = new User.User();
        IAddressee addressee = new AddresseeLoggerDecorator(new AddresseeUser(user), new Logger.Logger());
        ITopic topic = new Topic.Topic("nn", addressee);

        // Act
        topic.GetMessage(message);

        // Assert
        Assert.False(user.Messages[0].ReadMessageMarker);
    }

    [Fact]
    public void SendMessage_ShouldChangeStatus_WhenSendUserReadMessage()
    {
        // Arrange
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.Important, DateTime.Today);
        var user = new User.User();
        IAddressee addressee = new AddresseeLoggerDecorator(new AddresseeUser(user), new Logger.Logger());
        ITopic topic = new Topic.Topic("nn", addressee);

        // Act
        topic.GetMessage(message);
        user.ReadMessage("nn");

        // Assert
        Assert.True(user.Messages[0].ReadMessageMarker);
    }

    [Fact]
    public void SendMessage_ShouldReturnError_WhenSendUserReadMessageTwice()
    {
        // Arrange
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.Important, DateTime.Today);
        var user = new User.User();
        IAddressee addressee = new AddresseeLoggerDecorator(new AddresseeUser(user), new Logger.Logger());
        ITopic topic = new Topic.Topic("nn", addressee);
        var result = new MessageIsRead.ErrorRead();

        // Act
        topic.GetMessage(message);
        user.ReadMessage("nn");
        MessageIsRead isRead = user.ReadMessage("nn");

        // Assert
        Assert.Equal(result.GetType(), isRead.GetType());
    }

    [Fact]
    public void SendMessage_ShouldBeIgnored_WhenPriorityIsLow()
    {
        // Arrange
        var user = new User.User();
        AddresseeUser mock = Substitute.For<AddresseeUser>(user);
        var addressee = new AddresseeFilterDecorator(mock, ImportanceLevel.Important);
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.NotImportant, DateTime.Today);

        // Act
        addressee.DeliverMessage(message);

        // Arrange
        mock.DidNotReceive().DeliverMessage(message);
    }

    [Fact]
    public void SendMessage_ShouldLogged_WhenMessageArrived()
    {
        // Arrange
        ILogger? mock = Substitute.For<ILogger>();
        var user = new User.User();
        var addressee = new AddresseeLoggerDecorator(new AddresseeUser(user), mock);
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.Important, DateTime.Today);

        // Act
        addressee.DeliverMessage(message);

        // Arrange
        mock.Received().SetMessage(Arg.Any<string>());
    }

    [Fact]
    public void SendMessage_ShouldDelivered_WhenSendMessageToAddressee()
    {
        IMessengerDriver mock = Substitute.For<IMessengerDriver>();
        IMessenger messenger = new Messenger.Messenger(mock);
        var addressee = new AddresseeLoggerDecorator(new AddresseeMessenger(messenger), new Logger.Logger());
        var message = new Message.Message("nn", "nnnn", ImportanceLevel.Important, DateTime.Today);

        // Act
        addressee.DeliverMessage(message);

        // Arrange
        mock.Received().AddSub();
    }
}