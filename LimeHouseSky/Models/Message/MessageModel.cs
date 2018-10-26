using LimeHouseSky.Models.Base;
using LimeHouseSky.Models.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models.Message
{
    public enum MessageType
    {
        FromRead,
        FromUnread,
        To
    }

    public class MessageModel : BaseModel
    {
        private PhotoItemModel _mainPhoto;
        public PhotoItemModel MainPhoto
        {
            get => _mainPhoto;
            set => Set(ref _mainPhoto, value);
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        private string _lastMessage;
        public string LastMessage
        {
            get => _lastMessage;
            set => Set(ref _lastMessage, value);
        }

        private DateTime _lastDateMessage;
        public DateTime LastDateMessage
        {
            get => _lastDateMessage;
            set
            {
                Set(ref _lastDateMessage, value);

                OnPropertyChanged(nameof(LastDateMessageString));
                OnPropertyChanged(nameof(LastTimeMessageString));
            }
        }

        public string LastDateMessageString => LastDateMessage.ToString("d");
        public string LastTimeMessageString => LastDateMessage.ToString("HH':'mm");

        private MessageType _messageType;
        public MessageType MessageType
        {
            get => _messageType;
            set
            {
                Set(ref _messageType, value);

                OnPropertyChanged(nameof(IsMessageFromRead));
                OnPropertyChanged(nameof(IsMessageFromUnread));
                OnPropertyChanged(nameof(IsMessageTo));
            }
        }

        public bool IsMessageFromRead => MessageType == MessageType.FromRead;
        public bool IsMessageFromUnread => MessageType == MessageType.FromUnread;
        public bool IsMessageTo => MessageType == MessageType.To;
    }
}
