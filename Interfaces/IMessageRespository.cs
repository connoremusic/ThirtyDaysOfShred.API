using ThirtyDaysOfShred.API.DTOs;
using ThirtyDaysOfShred.API.Entities.Users;
using ThirtyDaysOfShred.API.Helpers;

namespace ThirtyDaysOfShred.API.Interfaces
{
    public interface IMessageRespository
    {
        void AddGroup(Group group);
        void RemoveConnection(Connection connection);
        Task<Connection> GetConnection(string connectionId);
        Task<Group> GetMessageGroup(string groupName);
        Task<Group> GetGroupForConnection(string connectionId);
        void AddMessage(Message message);
        void DeleteMesage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername);
        Task<bool> SaveAllAsync();
    }
}
